using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Offers;
using _Scripts.GrowthFund.Offer;
using _Scripts.GrowthFund.Persistence;
using UniRx;
using Zenject;

namespace _Scripts.GrowthFund.Progression
{
    public class GrowthFundProgressModelProvider : IInitializable, IGrowthFundProgressModelProvider
    {
        private readonly IGrowthFundOfferModelProvider _offerModelProvider;
        private readonly GrowthFundProgressModel.IFactory _progressModelFactory;
        private readonly IGrowthFundPersistenceProvider _persistenceProvider;
        private readonly IDisposable _disposer;

        private readonly ReactiveDictionary<int, IGrowthFundProgressModel> _progressModels = new ();
        public IReadOnlyReactiveDictionary<int, IGrowthFundProgressModel> AllProgressModels => _progressModels;

        public GrowthFundProgressModelProvider(IGrowthFundOfferModelProvider offerModelProvider,
            IGrowthFundPersistenceProvider persistenceProvider,
            GrowthFundProgressModel.IFactory progressModelFactory, IDisposable disposer)
        {
            _offerModelProvider = offerModelProvider;
            _progressModelFactory = progressModelFactory;
            _persistenceProvider = persistenceProvider;
            _disposer = disposer;
        }

        public void Initialize()
        {
            _offerModelProvider.GrowthFundOffers.ObserveAdd()
                .Select(addEvent => addEvent.Value)
                .Subscribe(CreateGrowthFundProgressModel)
                .AddTo(_disposer as ICollection<IDisposable>);
        }

        public IGrowthFundProgressModel GetProgressModelForId(int growthFundId)
        {
            return _progressModels.TryGetValue(growthFundId, out var progressModel)
                ? progressModel
                : null;
        }

        private void CreateGrowthFundProgressModel(ILiveOfferModel liveOfferModel)
        {
            var growthFundId = liveOfferModel.OfferData.GrowthFundData.GrowthFundId;
            var persistence = _persistenceProvider.GetGrowthFundPersistence(growthFundId);
            var model = _progressModelFactory.Create(persistence, liveOfferModel);
            _progressModels.TryAdd(growthFundId, model);
        }
    }
}