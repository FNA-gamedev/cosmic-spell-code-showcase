using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;

namespace _Scripts.GrowthFund.DataEvents
{
    public interface IGrowthFundEventDataService
    {
        void SendMilestoneRewardCollectedEconomyTransaction(int growthFundId, int milestoneId,
            int lastMilestoneUnlocked, IEnumerable<IConsumablePackage> transactionData);

        void SendMilestoneReachedDataEvent(int growthFundId, int milestoneId, bool isFinalMilestone,
            bool isGrowthFundBought);

        void OnBubbleClicked(int growthFundId, string liveOfferId, bool hasBoughtOffer);
        void OnShopClicked(int growthFundId, string liveOfferId, bool hasBoughtOffer);

        void OnPanelOpen(int growthFundId, string liveOfferId, bool growthFundBought, int lastMilestoneUnlocked,
            string source, bool isOpen);

        void OnPurchasePopupOpen(int growthFundId, string liveOfferId, int milestoneId,
            int lastMilestoneUnlocked, bool isOpen);

        void OnMilestoneClicked(int milestoneId, int growthFundId, string liveOfferId, bool growthFundBought,
            int lastMilestoneUnlocked);

        void OnBuyGrowthFundClicked(int growthFundId, string liveOfferId, bool growthFundBought,
            int lastMilestoneUnlocked);

        void OnInterstitialOpenTriggered(int growthFundId, string liveOfferId, bool growthFundBought,
            int lastMilestoneUnlocked, string source, bool isOpen);
    }
}