namespace _Scripts.GrowthFund
{
    public class GrowthFundConstants
    {
        // Unlock conditions (enum)
        public const string UnlockMilestone_MineId = "UnlockCondition_Milestone_MineId";
        public const string UnlockMilestone_MineshaftId = "UnlockCondition_Milestone_MineshaftId";
        public const string UnlockMilestone_PrestigeId = "UnlockCondition_Milestone_PrestigeId";

        // Milestone status options (enum)
        public const string MilestoneStatusLocked = "MilestoneLocked";
        public const string MilestoneStatusUnlocked = "MilestoneUnlocked";
        public const string MilestoneStatusClaimed = "MilestoneClaimed";

        // Loca keys
        public const string LK_DefaultMilestoneDescTemplate = "SuperManagersUnlock";
        public const string LK_MilestoneReadyToClaim = "TapToCollect";
        public const string LK_DefaultRecapDescription = "GrowthFundGetUpTo";

        // Data events - GameObjectNames
        public const string K_growthFundBubbleEventName = "GrowthFundBubble";
        public const string K_growthFundShopEventName = "GrowthFundShopPanel";
        public const string K_growthFundBuyIapEventName = "BuyIap";
        public const string K_growthFundMilestoneName = "Milestone_{0}";

        // Data events - Panels
        public const string K_growthFundMainPanelName = "GrowthFundPanel";
        public const string K_growthFundInsterstitialPanelName = "GrowthFundInterstitialPanel";

        // Data events - Triggers
        public const string K_growthFundBubbleClicked = "GrowthFund:Bubble:Click";
        public const string K_growthFundShopClicked = "GrowthFund:ShopPanel:Click";
        public const string K_growthFundMilestoneClicked = "GrowthFundPanel:MilestoneClick";
        public const string K_growthFundBuyIapClicked = "GrowthFundPanel:IapClick";

        public const string K_growthFundMainPanelOpen = "GrowthFundPanel:Open";
        public const string K_growthFundMainPanelClose = "GrowthFundPanel:Close";
        public const string K_growthFundInterstitialPanelOpen = "GrowthFundInterstitialPanel:Open";
        public const string K_growthFundInterstitialPanelClose = "GrowthFundInterstitialPanel:Close";
        public const string K_growthFundPurchasePanelOpen = "GrowthFundPurchasePanel:Open";
        public const string K_growthFundPurchasePanelClosed = "GrowthFundPurchasePanel:Closed";
        
        // Loca keys
        public const string K_growthFundMultiplier = "Multiplier";
        public const string K_growthFundPassConsumable = "PassConsumable";
        public const string K_growthFundMilestoneReached = "GrowthFundMilestoneReached";
    }
}