using _Scripts.GrowthFund._Shared.Analytics;

namespace _Scripts.GrowthFund.DataEvents
{
    public class GrowthFundMilestoneReachedPayload : IDataPlatformPayload
    {
        public int GrowthFundId;
        public int GrowthFundMilestoneID;
        public bool GrowthFundFinalMilestone;
        public bool GrowthFundBought;
        
        public string GetEventName()
        {
            return GrowthFundConstants.K_growthFundMilestoneReached;
        }
    }
}