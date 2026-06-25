using _Scripts.GrowthFund.Data;
using UniRx;

namespace _Scripts.GrowthFund.Progression
{
    public interface IGrowthFundProgressionService
    {
        IReadOnlyReactiveProperty<bool> GetMilestoneCombinedConditionRx(GrowthFundMilestone milestone);
        string GetMilestoneDescriptionByConditions(GrowthFundMilestone milestone);
    }
}