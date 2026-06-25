using System.Collections.Generic;

namespace _Scripts.GrowthFund._Shared.Analytics
{
    public static class AnalyticsContextGenerator
    {
        public static IDictionary<string, string> GrowthFundRewardCollected(int growthFundId, int milestoneId, int lastMilestoneUnlocked)
        {
            return new Dictionary<string, string>
            {
                { AnalyticsContextKeys.GrowthFundId.ToString(), growthFundId.ToString() },
                { AnalyticsContextKeys.GrowthFundMilestone.ToString(), milestoneId.ToString() },
                { AnalyticsContextKeys.GrowthFundHighestMilestoneToClaim.ToString(), lastMilestoneUnlocked.ToString()}
            };
        }

    }
}