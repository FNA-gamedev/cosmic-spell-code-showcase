using UnityEngine;

namespace _Scripts.GrowthFund._Shared.Offers
{
    public interface IOfferGraphics
    {
        Sprite HeaderSprite { get; }
        float HeaderSpriteScale { get; }
        Sprite ShopPanelSprite { get; }
        Sprite BackgroundSprite { get; }
        float BackgroundTilingPixelPerUnitMultiplier { get; }
        Sprite BackgroundShopPanelSprite { get; }
        Sprite BubbleSprite { get; }
        Sprite WidgetSprite { get; }
        Color BorderColor { get; set; }
        Color HeaderColor { get; set; }
        Color BgGradientColor { get; set; }
        Color BgGradientOfferColor { get; set; }
        Color MiddleGradientColor { get; set; }
    }
}