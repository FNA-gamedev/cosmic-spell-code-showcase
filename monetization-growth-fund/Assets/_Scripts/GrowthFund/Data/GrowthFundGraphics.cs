using System;
using _Scripts.GrowthFund._Shared.Utility;
using UnityEngine;

namespace _Scripts.GrowthFund.Data
{
    public class GrowthFundGraphics : IGrowthFundGraphics
    {
        private Func<DisposableSprite> _bubbleSpriteLazy;
        private Func<DisposableSprite> _mainPanelHeaderSpriteLazy;
        private Func<DisposableSprite> _interstitialHeaderSpriteLazy;
        private Func<DisposableSprite> _rewardPopupHeaderSpriteLazy;
        
        public Sprite BubbleSprite => Lazy.From(_bubbleSpriteLazy).Value.Sprite;
        public Sprite MainPanelHeaderSprite => Lazy.From(_mainPanelHeaderSpriteLazy).Value.Sprite;
        public Sprite InterstitialHeaderSprite => Lazy.From(_interstitialHeaderSpriteLazy).Value.Sprite;
        public Sprite RewardPopupHeaderSprite => Lazy.From(_rewardPopupHeaderSpriteLazy).Value.Sprite;

        public GrowthFundGraphics(
            Func<DisposableSprite> bubbleSpriteLazy,
            Func<DisposableSprite> mainPanelHeaderSpriteLazy,
            Func<DisposableSprite> interstitialHeaderSpriteLazy,
            Func<DisposableSprite> rewardPopupHeaderSpriteLazy)
        {
            _bubbleSpriteLazy = bubbleSpriteLazy;
            _mainPanelHeaderSpriteLazy = mainPanelHeaderSpriteLazy;
            _interstitialHeaderSpriteLazy = interstitialHeaderSpriteLazy;
            _rewardPopupHeaderSpriteLazy = rewardPopupHeaderSpriteLazy;
        }
    }
}