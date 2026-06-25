using _Scripts.GrowthFund._Shared.Utility;
using _Scripts.GrowthFund.Data;
using UnityEngine;

namespace _Scripts.GrowthFund.Progression
{
    [CreateAssetMenu(menuName = "Configs/GrowthFund")]
    public class GrowthFundProgressConfig : ScriptableObject, IGrowthFundProgressConfig
    {
        [Header("Functional Settings")] 
        [SerializeField] private int _maxRewardsByMilestone;
        [SerializeField] private int _maxTotalRewards;

        public bool UseTestDummyData
        {
            get
            {
                CheckTestDummyParams();
                return _useTestDummyData;
            }
            
            set
            {
                _useTestDummyData = value;
                CheckTestDummyParams();
            }
        }

        [SerializeField] private bool _useTestDummyData;
        [SerializeField] private GrowthFundData _testDummyData;
        [SerializeField] private Sprite _dummyBubbleSprite;
        [SerializeField] private Sprite _dummyMainPanelHeaderSprite;
        [SerializeField] private Sprite _dummyInterstitialHeaderSprite;
        [SerializeField] private Sprite _dummyRewardPopupHeaderSprite;
        [SerializeField] private int _dummyValueFactor;
        [SerializeField] private int _dummyBubblePriority;

        [Header("UI Settings")]
        [SerializeField] private float _scrollMoveDefaultDuration;
        [SerializeField] private float _scrollOffsetThreshold;
        [SerializeField] private float _scrollMoveOnOffsetThresholdDuration;

        public GrowthFundData TestDummyData => _testDummyData;
        public int MaxMilestoneRewards => _maxRewardsByMilestone;
        public int MaxTotalRewards => _maxTotalRewards;
        public float ScrollMoveDefaultDuration => _scrollMoveDefaultDuration;
        public float ScrollOffsetThreshold => _scrollOffsetThreshold;
        public float ScrollMoveOnOffsetThresholdDuration => _scrollMoveOnOffsetThresholdDuration;

        private void CheckTestDummyParams()
        {
            if (_useTestDummyData)
            {
                TestDummyData.GrowthFundGraphics = new GrowthFundGraphics(
                    () => _dummyBubbleSprite.ToDisposableSprite(),
                    () => _dummyMainPanelHeaderSprite.ToDisposableSprite(),
                    () => _dummyInterstitialHeaderSprite.ToDisposableSprite(),
                    () => _dummyRewardPopupHeaderSprite.ToDisposableSprite()
                );

                TestDummyData.ValueFactor = _dummyValueFactor;
                TestDummyData.BubblePriority = _dummyBubblePriority;
            }
        }
    }
}