namespace _Scripts.GrowthFund.Persistence
{
    public interface IGrowthFundPersistenceProvider
    {
        IGrowthFundPersistence GetGrowthFundPersistence(int growthFundId);
    }
}