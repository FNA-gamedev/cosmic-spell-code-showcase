using _Scripts.GrowthFund.Data;

namespace _Scripts.GrowthFund._Shared.Offers
{
    public interface ILiveOfferData
    {
        bool HasBubble { get; }
        bool IsBubbleDismissible { get; }
        bool BubbleHasNotification { get; }
        bool HasWidget { get; }
        bool ShowPopup { get; }
        bool HasFullScreenView { get; }
        bool IsRushMineOffer { get; }
        IOfferGraphics Graphics { get; }
        IGrowthFundData GrowthFundData { get; }
    }
}