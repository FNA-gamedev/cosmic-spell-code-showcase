using UniRx;

namespace _Scripts.GrowthFund._Shared.Offers
{
    public interface ILiveOfferModelProvider
    {
        IReadOnlyReactiveCollection<ILiveOfferModel> LiveOfferModels { get; }
    }
}