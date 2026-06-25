using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund.DTOs
{
    [Serializable]
    public class ConditionDto
    {
        [field: SerializeField]
        [JsonProperty("key")] public string ConditionKey { get; set; }
        
        [field: SerializeField]
        [JsonProperty("value")] public int ConditionValue { get; set; }
    }
}