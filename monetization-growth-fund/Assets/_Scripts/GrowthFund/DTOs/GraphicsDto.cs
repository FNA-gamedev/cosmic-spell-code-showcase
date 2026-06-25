using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund.DTOs
{
    [Serializable]
    public class GraphicsDto
    {
        [field: SerializeField]
        [JsonProperty("bubbleSprite")] public string BubbleSprite { get; set; }
        
        [field: SerializeField]
        [JsonProperty("mainPanelHeaderSprite")] public string MainPanelHeaderSprite { get; set; }
        
        [field: SerializeField]
        [JsonProperty("interstitialHeaderSprite")] public string InterstitialHeaderSprite { get; set; }
        
        [field: SerializeField]
        [JsonProperty("rewardPopupHeaderSprite")] public string RewardPopupHeaderSprite { get; set; }
    }
}