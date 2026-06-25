using UniRx;

namespace _Scripts.GrowthFund.Progression
{
    public interface IGrowthFundProgressModelProvider
    {
        IGrowthFundProgressModel GetProgressModelForId(int offerId);
        IReadOnlyReactiveDictionary<int, IGrowthFundProgressModel> AllProgressModels { get; }
    }
}