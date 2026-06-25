using System;
using System.Collections.Generic;

namespace _Scripts.GrowthFund.Persistence
{
    [Serializable]
    public class GrowthFundProgressSavegame
    {
        public int Id;
        public bool HasBoughtOffer;
        public int FirstMilestoneUnlocked;
        public int LastMilestoneClaimed;
        public List<MilestoneProgress> MilestoneProgresses;
        public bool HasFinishedGrowthFund;
        public bool FeatureUnlockInterstitialShown;
    }
}