using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;

namespace _Scripts.GrowthFund._Shared.Offers
{
    public interface ILiveOfferModel
    {
        int Id { get; }
        ILiveOffer LiveOffer { get; }
        ILiveOfferData OfferData { get; }
        IOfferAppearance Appearance { get; }
        IOfferGraphics Graphics { get; }
        List<IConsumablePackage> Packages { get; }
        
        void SetOfferVisualized(bool visualized);
        void AddAdditionalEconomyTransactionParams(string key, string value);
    }
}