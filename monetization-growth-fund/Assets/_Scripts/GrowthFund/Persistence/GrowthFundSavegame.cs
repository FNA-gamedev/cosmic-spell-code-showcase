using System;
using System.Collections.Generic;

namespace _Scripts.GrowthFund.Persistence
{
    [Serializable]
    public class GrowthFundSavegame
    {
        public List<GrowthFundProgressSavegame> GrowthFundProgress = new();
    }
}