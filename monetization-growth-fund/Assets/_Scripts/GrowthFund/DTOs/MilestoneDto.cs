using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund.DTOs
{
    [Serializable]
    public class MilestoneDto
    {
        [field: SerializeField]
        [JsonProperty("milestoneId")] public int MilestoneId { get; set; }
        
        [field: SerializeField]
        [JsonProperty("milestoneIcon")] public string MilestoneIcon { get; set; }
        
        [field: SerializeField]
        [JsonProperty("targetMineId")] public int TargetMineId { get; set; }
        
        [field: SerializeField]
        [JsonProperty("rewards")] public List<ConsumableDto> Rewards { get; set; }
        
        [field: SerializeField]
        [JsonProperty("conditions")] public List<ConditionDto> Conditions { get; set; }
    }
}