using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.GrowthFund._Shared;
using _Scripts.GrowthFund._Shared.Utility;
using _Scripts.GrowthFund.Data;
using _Scripts.GrowthFund.DTOs;
using UniRx;

namespace _Scripts.GrowthFund.Progression
{
    public class GrowthFundProgressionService : IGrowthFundProgressionService
    {
        private readonly IMineshaftUnlockProvider _mineshaftUnlockProvider;
        private readonly Savegame _savegame;
        private readonly IEventBus _eventBus;
        private readonly IDisposable _disposer;

        public GrowthFundProgressionService(IMineshaftUnlockProvider mineshaftUnlockProvider, Savegame savegame, IEventBus eventBus,
            IDisposable disposer)
        {
            _mineshaftUnlockProvider = mineshaftUnlockProvider;
            _savegame = savegame;
            _eventBus = eventBus;
            _disposer = disposer;
        }

        public IReadOnlyReactiveProperty<bool> GetMilestoneCombinedConditionRx(GrowthFundMilestone milestone)
        {
            var combinedConditionRx = milestone.Conditions
                .Select(condition => GetConditionRx(milestone.TargetMineId, condition))
                .Aggregate((agg, next) => agg.CombineLatest(next, (a, b) => a && b))
                .ToReadOnlyReactiveProperty()
                .AddTo(_disposer as ICollection<IDisposable>);

            return combinedConditionRx;
        }

        public string GetMilestoneDescriptionByConditions(GrowthFundMilestone milestone)
        {
            string milestoneDesc = GrowthFundConstants.LK_DefaultMilestoneDescTemplate;
            var targetMineId = milestone.TargetMineId;
            ConditionDto mineshaftCondition = milestone.Conditions
                .FirstOrDefault(c => c.ConditionKey == GrowthFundConstants.UnlockMilestone_MineshaftId);

            if (mineshaftCondition != default)
            {
                var targetMineName = targetMineId.ToString();
                milestoneDesc = string.Format(
                    milestoneDesc,
                    mineshaftCondition.ConditionValue,
                    $"{targetMineName} mine"
                );
            }

            return milestoneDesc;
        }

        private IObservable<bool> GetConditionRx(int mineId, ConditionDto conditionData)
        {
            switch (conditionData.ConditionKey)
            {
                case GrowthFundConstants.UnlockMilestone_MineshaftId:
                    return _mineshaftUnlockProvider.GetMineshaftUnlockedReactiveProperty(mineId, conditionData.ConditionValue);
                case GrowthFundConstants.UnlockMilestone_PrestigeId:
                    var mineSavegame = _savegame.Mines.First(mineSave => mineSave.MineNumber == mineId);
                    var hasReachedPrestige = new ReactiveProperty<bool>(mineSavegame.PrestigeCount == conditionData.ConditionValue).AddTo(_disposer as ICollection<IDisposable>);

                    return hasReachedPrestige;
                default:
                    throw new Exception($"Trying to check unsupported condition {conditionData.ConditionKey}");
            }
        }
    }
}