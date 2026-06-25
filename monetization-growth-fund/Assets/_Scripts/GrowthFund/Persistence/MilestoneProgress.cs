using System;

namespace _Scripts.GrowthFund.Persistence
{
    [Serializable]
    public class MilestoneProgress
    {
        public int milestoneId;
        public string status;
    }
}