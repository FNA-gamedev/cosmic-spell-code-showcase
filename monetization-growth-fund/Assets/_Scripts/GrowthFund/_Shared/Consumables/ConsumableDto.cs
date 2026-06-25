using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund._Shared.Consumables
{
    [Serializable]
    public class ConsumableDto
    {
        [field: SerializeField]
        [JsonProperty("id")] public int Id { get; set; }
        
        [field: SerializeField]
        [JsonProperty("amount")] public int Amount { get; set; }
    }
}
