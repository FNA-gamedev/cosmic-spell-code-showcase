using System.Collections.Generic;
using UniRx;

namespace _Scripts.GrowthFund.Persistence
{
    public interface IGrowthFundPersistence
    {
        IReactiveProperty<bool> HasBoughtOffer { get; }
        IReactiveProperty<int> LastMilestoneClaimed { get; }
        IReactiveProperty<int> FirstMilestoneUnlocked { get; }
        IReactiveProperty<string> GetMilestoneStatus(int milestoneId);
        IReadOnlyDictionary<int, IReactiveProperty<string>> MilestonesStatus { get; }
        IReactiveProperty<bool> HasFinishedGrowthFund { get; }
        IReactiveProperty<bool> FeatureUnlockInterstitialShown { get; }
        void SetMilestoneStatus(int milestoneId, string status);
    }
}