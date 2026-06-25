using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;
using UnityEngine;

namespace _Scripts.GrowthFund.Data
{
    [Serializable]
    public class GrowthFundData : IGrowthFundData
    {
        [SerializeField] private List<GrowthFundMilestone> _milestones;
        [SerializeField] private List<ConsumableDto> _totalRewards;
        [SerializeField] private GrowthFundLocaData _growthFundLocaData;
        [SerializeField] private GrowthFundGraphics _growthFundGraphics;
        [SerializeField] private GrowthFundColourPaletteData _growthFundColourPalette;
        [SerializeField] private int _valueFactor;
        [SerializeField] private int _bubblePriority;
        [SerializeField] private bool _dismissibleBubble;

        public int GrowthFundId { get; }
        public List<GrowthFundMilestone> Milestones
        {
            get => _milestones;
            set => _milestones = value;
        }
        public List<ConsumableDto> TotalRewards
        {
            get => _totalRewards;
            set => _totalRewards = value;
        }
        public GrowthFundLocaData GrowthFundLocaData
        {
            get => _growthFundLocaData;
            set => _growthFundLocaData = value;
        }
        public IGrowthFundGraphics GrowthFundGraphics
        {
            get => _growthFundGraphics;
            set => _growthFundGraphics = value as GrowthFundGraphics;
        }
        public GrowthFundColourPaletteData GrowthFundColourPalette
        {
            get => _growthFundColourPalette;
            set => _growthFundColourPalette = value;
        }
        public int ValueFactor
        {
            get => _valueFactor;
            set => _valueFactor = value;
        }
        public int BubblePriority
        {
            get => _bubblePriority;
            set => _bubblePriority = value;
        }
        public bool DismissibleBubble
        {
            get => _dismissibleBubble;
            set => _dismissibleBubble = value;
        }
        
        public GrowthFundData(
            int growthFundId,
            List<GrowthFundMilestone> milestones,
            List<ConsumableDto> totalRewards,
            GrowthFundLocaData growthFundLocaData,
            GrowthFundGraphics growthFundGraphics,
            GrowthFundColourPaletteData growthFundColourPalette,
            int valueFactor,
            int bubblePriority,
            bool dismissibleBubble)
        {
            GrowthFundId = growthFundId;
            Milestones = milestones;
            TotalRewards = totalRewards;
            GrowthFundLocaData = growthFundLocaData;
            GrowthFundGraphics = growthFundGraphics;
            GrowthFundColourPalette = growthFundColourPalette;
            ValueFactor = valueFactor;
            BubblePriority = bubblePriority;
            DismissibleBubble = dismissibleBubble;
        }
    }
}