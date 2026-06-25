using _Scripts.GrowthFund._Shared.Offers;
using UniRx;

namespace _Scripts.GrowthFund.Offer
{
    public interface IGrowthFundOfferModelProvider
    {
        IReadOnlyReactiveCollection<ILiveOfferModel> GrowthFundOffers { get; }
    }
}