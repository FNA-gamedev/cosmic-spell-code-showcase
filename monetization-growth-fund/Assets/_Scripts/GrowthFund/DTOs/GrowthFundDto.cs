using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund.DTOs
{
    [Serializable]
    public class GrowthFundDto
    {
        [field: SerializeField]
        [JsonProperty("growthFundId")] public int GrowthFundId { get; set; }

        [field: SerializeField]
        [JsonProperty("milestones")] public List<MilestoneDto> Milestones { get; set; }
        
        [field: SerializeField]
        [JsonProperty("totalRewards")] public List<ConsumableDto> TotalRewards { get; set; }
        
        [field: SerializeField]
        [JsonProperty("graphics")] public GraphicsDto Graphics { get; set; }

        [field: SerializeField]
        [JsonProperty("colourPalette")] public ColourPaletteDto ColourPalette { get; set; }
        
        [field: SerializeField]
        [JsonProperty("valueFactor")] public int ValueFactor { get; set; }
        
        [field: SerializeField]
        [JsonProperty("bubblePriority")] public int BubblePriority { get; set; }
        
        [field: SerializeField]
        [JsonProperty("dismissibleBubble")] public bool DismissibleBubble { get; set; }
    }
}