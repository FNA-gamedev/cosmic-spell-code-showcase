using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Offers;
using UniRx;

namespace _Scripts.GrowthFund.Offer
{
    public class GrowthFundOfferModelProvider : IGrowthFundOfferModelProvider
    {
        private readonly IReactiveCollection<ILiveOfferModel> _growthFundOffers;

        public IReadOnlyReactiveCollection<ILiveOfferModel> GrowthFundOffers => _growthFundOffers;
        
        public GrowthFundOfferModelProvider(ILiveOfferModelProvider liveOfferModelProvider, IDisposable disposer)
        {
            _growthFundOffers = new ReactiveCollection<ILiveOfferModel>().AddTo(disposer as ICollection<IDisposable>);
            
            foreach (var offer in liveOfferModelProvider.LiveOfferModels)
            {
                OnOfferAdded(offer);
            }

            liveOfferModelProvider.LiveOfferModels
                .ObserveAdd()
                .Subscribe(added => OnOfferAdded(added.Value))
                .AddTo(disposer as ICollection<IDisposable>);
        }

        private void OnOfferAdded(ILiveOfferModel liveOfferModel)
        {
            if (liveOfferModel.OfferData.GrowthFundData == null)
            {
                return;
            }
            
            _growthFundOffers.Add(liveOfferModel);
        }
    }
}