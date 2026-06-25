using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.GrowthFund._Shared.Consumables;
using _Scripts.GrowthFund._Shared.Offers;
using _Scripts.GrowthFund.Data;
using _Scripts.GrowthFund.DataEvents;
using _Scripts.GrowthFund.Persistence;
using UniRx;
using Zenject;

namespace _Scripts.GrowthFund.Progression
{
    public class GrowthFundProgressModel : IGrowthFundProgressModel
    {
        public interface IFactory : IFactory<IGrowthFundPersistence, ILiveOfferModel, IGrowthFundProgressModel> { }

        private readonly IGrowthFundProgressionService _growthFundProgressionService;
        private readonly IConsumableItemModelPool _consumableItemModelPool;
        private readonly IGrowthFundEventDataService _eventDataService;
        private readonly IDisposable _disposer;

        public ILiveOfferModel OfferModel { get; }
        public IGrowthFundData GrowthFundData { get; }
        public IGrowthFundPersistence GrowthFundPersistence { get; }

        public GrowthFundProgressModel(
            IGrowthFundPersistence growthFundPersistence,
            ILiveOfferModel offerModel,
            IGrowthFundProgressionService progressionService,
            IConsumableItemModelPool itemModelPool,
            IGrowthFundEventDataService growthFundEventDataService,
            IDisposable disposer,
            IGrowthFundData overrideProgressionData = default)
        {
            GrowthFundPersistence = growthFundPersistence;
            OfferModel = offerModel;
            GrowthFundData = overrideProgressionData ?? offerModel.OfferData.GrowthFundData;
            _growthFundProgressionService = progressionService;
            _consumableItemModelPool = itemModelPool;
            _eventDataService = growthFundEventDataService;
            _disposer = disposer;

            CheckUnlockForAllMilestones();
            SubscribeToAllMilestonesClaimed();
        }

        public void TryClaimRewardsForMilestone(GrowthFundMilestone milestone)
        {
            if (GrowthFundPersistence.GetMilestoneStatus(milestone.MilestoneId).Value != GrowthFundConstants.MilestoneStatusUnlocked
                || !GrowthFundPersistence.HasBoughtOffer.Value)
            {
                return;
            }

            GrantRewards(milestone);
            GrowthFundPersistence.SetMilestoneStatus(milestone.MilestoneId, GrowthFundConstants.MilestoneStatusClaimed);
        }

        public int GetLastMilestoneUnlockedId()
        {
            if (GrowthFundData.Milestones.All(milestone => GrowthFundPersistence.GetMilestoneStatus(milestone.MilestoneId).Value == GrowthFundConstants.MilestoneStatusClaimed))
                return GrowthFundPersistence.LastMilestoneClaimed.Value;

            return GrowthFundData.Milestones
                .Where(milestone => GrowthFundPersistence.GetMilestoneStatus(milestone.MilestoneId).Value == GrowthFundConstants.MilestoneStatusUnlocked)
                .Select(milestone => milestone.MilestoneId)
                .DefaultIfEmpty(-1)
                .Max();
        }

        private void GrantRewards(GrowthFundMilestone milestone)
        {
            var packagesReceived = new List<ConsumablePackage>();

            foreach (var consumablePackage in from reward in milestone.Rewards
                     let consumable = _consumableItemModelPool.GetConsumableItem(reward.Id).Consumable
                     select new ConsumablePackage(reward.Amount, consumable))
            {
                consumablePackage.Receive(ConsumableContext.GrowthFund);
                packagesReceived.Add(consumablePackage);
            }

            _eventDataService.SendMilestoneRewardCollectedEconomyTransaction(GrowthFundData.GrowthFundId, milestone.MilestoneId, GetLastMilestoneUnlockedId(), packagesReceived);
        }

        private void SubscribeToAllMilestonesClaimed()
        {
            GrowthFundData.Milestones
                .Select(milestone => GrowthFundPersistence.GetMilestoneStatus(milestone.MilestoneId))
                .CombineLatest()
                .Subscribe(milestoneStates =>
                {
                    if (milestoneStates.All(status => status == GrowthFundConstants.MilestoneStatusClaimed))
                    {
                        if (!GrowthFundPersistence.HasFinishedGrowthFund.Value)
                            EndGrowthFund();
                    }
                    else
                    {
                        // This flag must be set to ensure that the growth fund can be re-enabled when new rewards are added for players who already completed the growth fund.
                        GrowthFundPersistence.HasFinishedGrowthFund.Value = false;
                    }
                }).AddTo(_disposer as ICollection<IDisposable>);
        }

        private void EndGrowthFund() { }

        private void CheckUnlockForAllMilestones()
        {
            foreach (var milestone in GrowthFundData.Milestones
                         .Where(milestone => GrowthFundPersistence.GetMilestoneStatus(milestone.MilestoneId).Value == GrowthFundConstants.MilestoneStatusLocked))
            {
                _growthFundProgressionService
                    .GetMilestoneCombinedConditionRx(milestone)
                    .Subscribe(condition =>
                    {
                        if(condition)
                            UnlockMilestone(milestone.MilestoneId);
                    })
                    .AddTo(_disposer as ICollection<IDisposable>);
            }
        }

        private void UnlockMilestone(int milestoneId)
        {
            GrowthFundPersistence.SetMilestoneStatus(milestoneId, GrowthFundConstants.MilestoneStatusUnlocked);
            OfferModel.SetOfferVisualized(false);

            var isFinalMilestone = milestoneId == GrowthFundData.Milestones.Select(milestone => milestone.MilestoneId).Max();

            _eventDataService.SendMilestoneReachedDataEvent(
                GrowthFundData.GrowthFundId,
                milestoneId,
                isFinalMilestone,
                GrowthFundPersistence.HasBoughtOffer.Value);
        }
    }
}