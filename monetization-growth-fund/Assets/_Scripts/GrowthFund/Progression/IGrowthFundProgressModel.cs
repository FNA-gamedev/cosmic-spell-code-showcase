using _Scripts.GrowthFund._Shared.Offers;
using _Scripts.GrowthFund.Data;
using _Scripts.GrowthFund.Persistence;

namespace _Scripts.GrowthFund.Progression
{
    public interface IGrowthFundProgressModel
    {
        ILiveOfferModel OfferModel { get; }
        IGrowthFundData GrowthFundData { get; }
        IGrowthFundPersistence GrowthFundPersistence { get; }
        void TryClaimRewardsForMilestone(GrowthFundMilestone milestone);
        int GetLastMilestoneUnlockedId();
    }
}