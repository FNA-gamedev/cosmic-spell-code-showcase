using UniRx;

namespace _Scripts.GrowthFund._Shared.Offers
{
    public interface IOfferAppearance
    {
        string Header { get; }
        ILiveOfferData OfferData { get; }
        IReadOnlyReactiveProperty<long> RemainingTime { get; }
        int ValueFactor { get; }
        int StockCount { get; set; }
        IReadOnlyReactiveProperty<int> AvailableStock {get; set; }
    }
}