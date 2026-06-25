using UnityEngine;

namespace _Scripts.GrowthFund.Data
{
    public interface IGrowthFundGraphics
    {
        Sprite BubbleSprite { get; }
        Sprite MainPanelHeaderSprite { get; }
        Sprite InterstitialHeaderSprite { get; }
        Sprite RewardPopupHeaderSprite { get; }
    }
}