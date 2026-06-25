namespace _Scripts.GrowthFund._Shared.Analytics
{
    public enum TransactionType
    {
        PremiumCurrency,
        SoftCurrency
    }

    public enum TransactionSource
    {
        GrowthFundMilestone,
    }

    public enum AnalyticsContextKeys
    {
        GrowthFundId,
        GrowthFundBought,
        GrowthFundMilestone,
        GrowthFundHighestMilestoneToClaim,
        GrowthFundLastMilestoneUnlocked,
    }

    public enum AnalyticsContextTypes
    {
        PremiumCurrency,
    }
}