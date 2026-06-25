using _Scripts.GrowthFund.Data;

namespace _Scripts.GrowthFund.Progression
{
    public interface IGrowthFundProgressConfig
    {
        int MaxMilestoneRewards { get; }
        int MaxTotalRewards { get; }
        bool UseTestDummyData { get; set; }
        GrowthFundData TestDummyData { get; }
        float ScrollMoveDefaultDuration { get; }
        float ScrollOffsetThreshold { get; }
        float ScrollMoveOnOffsetThresholdDuration { get; }
    }
}