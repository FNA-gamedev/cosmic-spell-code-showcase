using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UniRx;
using Zenject;

namespace _Scripts.GrowthFund.Persistence
{
    public class GrowthFundPersistence : IGrowthFundPersistence
    {
        public interface IFactory : IFactory<GrowthFundProgressSavegame, IGrowthFundPersistence> { }

        private readonly Dictionary<int, IReactiveProperty<string>> _milestonesStatus = new();
        private readonly GrowthFundProgressSavegame _savegame;
        private readonly IDisposable _disposer;

        public IReactiveProperty<bool> HasBoughtOffer { get; }
        public IReactiveProperty<int> LastMilestoneClaimed { get; }
        public IReactiveProperty<int> FirstMilestoneUnlocked { get; }
        public IReactiveProperty<bool> HasFinishedGrowthFund { get; }
        public IReactiveProperty<bool> FeatureUnlockInterstitialShown { get; }
        public IReadOnlyDictionary<int, IReactiveProperty<string>> MilestonesStatus => _milestonesStatus;

        public GrowthFundPersistence([NotNull] GrowthFundProgressSavegame savegame, IDisposable disposer)
        {
            HasBoughtOffer = new ReactiveProperty<bool>(savegame.HasBoughtOffer).AddTo(disposer as ICollection<IDisposable>);
            HasBoughtOffer.Subscribe(offerBought => savegame.HasBoughtOffer = offerBought).AddTo(disposer as ICollection<IDisposable>);

            FirstMilestoneUnlocked = new ReactiveProperty<int>(savegame.FirstMilestoneUnlocked).AddTo(disposer as ICollection<IDisposable>);
            FirstMilestoneUnlocked.Subscribe(value => savegame.FirstMilestoneUnlocked = value).AddTo(disposer as ICollection<IDisposable>);

            LastMilestoneClaimed = new ReactiveProperty<int>(savegame.LastMilestoneClaimed).AddTo(disposer as ICollection<IDisposable>);
            LastMilestoneClaimed.Subscribe(value => savegame.LastMilestoneClaimed = value).AddTo(disposer as ICollection<IDisposable>);

            HasFinishedGrowthFund = new ReactiveProperty<bool>(savegame.HasFinishedGrowthFund).AddTo(disposer as ICollection<IDisposable>);
            HasFinishedGrowthFund.Subscribe(value => savegame.HasFinishedGrowthFund = value).AddTo(disposer as ICollection<IDisposable>);

            FeatureUnlockInterstitialShown = new ReactiveProperty<bool>(savegame.FeatureUnlockInterstitialShown).AddTo(disposer as ICollection<IDisposable>);
            FeatureUnlockInterstitialShown.Subscribe(value => savegame.FeatureUnlockInterstitialShown = value).AddTo(disposer as ICollection<IDisposable>);

            _savegame = savegame;
            _disposer = disposer;
        }

        public IReactiveProperty<string> GetMilestoneStatus(int milestoneId) =>
            _milestonesStatus.TryGetValue(milestoneId, out var milestoneStatus) ? milestoneStatus : GetMilestoneStatusRx(milestoneId);

        public void SetMilestoneStatus(int milestoneId, string status)
        {
            UpdateMilestonesFlags();
        }

        private IReactiveProperty<string> GetMilestoneStatusRx(int milestoneId)
        {
            var milestone = _savegame.MilestoneProgresses
                .FirstOrDefault(milestoneProgress => milestoneProgress.milestoneId == milestoneId);

            if (milestone == null)
            {
                var progress = new MilestoneProgress
                {
                    milestoneId = milestoneId,
                    status = GrowthFundConstants.MilestoneStatusLocked
                };
                    
                _savegame.MilestoneProgresses ??= new List<MilestoneProgress>();
                _savegame.MilestoneProgresses.Add(progress);

                return new ReactiveProperty<string>(progress.status).AddTo(_disposer as ICollection<IDisposable>); progress.status.ToReactiveCollection();
            }

            return new ReactiveProperty<string>(milestone.status).AddTo(_disposer as ICollection<IDisposable>);
        }

        private void UpdateMilestonesFlags()
        {
            var firstMilestoneUnlockedId = -1;
            var lastMilestoneClaimedId = -1;

            foreach (var status in MilestonesStatus)
            {
                int milestoneId = status.Key;
                string milestoneStatus = status.Value.Value;

                if (milestoneStatus == GrowthFundConstants.MilestoneStatusUnlocked
                    && (firstMilestoneUnlockedId < 0 || milestoneId < firstMilestoneUnlockedId))
                {
                    firstMilestoneUnlockedId = milestoneId;
                }

                if (milestoneStatus == GrowthFundConstants.MilestoneStatusClaimed 
                    && milestoneId > lastMilestoneClaimedId)
                {
                    lastMilestoneClaimedId = milestoneId;
                }
            }

            FirstMilestoneUnlocked.Value = firstMilestoneUnlockedId;
            LastMilestoneClaimed.Value = lastMilestoneClaimedId;
        }
    }
}