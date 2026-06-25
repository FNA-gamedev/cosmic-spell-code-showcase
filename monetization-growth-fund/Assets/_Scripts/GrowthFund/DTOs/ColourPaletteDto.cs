using System;
using _Scripts.GrowthFund._Shared.Utility;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.GrowthFund.DTOs
{
    [Serializable]
    public class ColourPaletteDto
    {
        [field: SerializeField]
        [JsonProperty("defaultItemBorder"), JsonConverter(typeof(HexColorJsonConverter))] public Color DefaultItemBorder { get; set; }

        [field: SerializeField]
        [JsonProperty("defaultBannerBorder"), JsonConverter(typeof(HexColorJsonConverter))] public Color DefaultBannerBorder { get; set; }

        [field: SerializeField]
        [JsonProperty("defaultGraphicBorder"), JsonConverter(typeof(HexColorJsonConverter))] public Color DefaultGraphicBorder { get; set; }

        [field: SerializeField]
        [JsonProperty("defaultItemBackground"), JsonConverter(typeof(HexColorJsonConverter))] public Color DefaultItemBackground { get; set; }

        [field: SerializeField]
        [JsonProperty("defaultPanelBackground"), JsonConverter(typeof(HexColorJsonConverter))] public Color DefaultPanelBackground { get; set; }

        [field: SerializeField]
        [JsonProperty("defaultPanelGradient"), JsonConverter(typeof(HexColorJsonConverter))] public Color DefaultPanelGradient { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundFooterBg"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundFooterBg { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundFooterItemBg"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundFooterItemBg { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundHeaderBg"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundHeaderBg { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundBodyInfoBg"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundBodyInfoBg { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundBodyInfoBorder"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundBodyInfoBorder { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundItemBg"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundItemBg { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundProgressionBar"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundProgressionBar { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundProgressionBarBg"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundProgressionBarBg { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundProgressionBarBorder"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundProgressionBarBorder { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundProgressionBarGradient"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundProgressionBarGradient { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundProgressionMarkerNotReached"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundProgressionMarkerNotReached { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundProgressionMarkerReached"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundProgressionMarkerReached { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundSeparatorLineBottom"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundSeparatorLineBottom { get; set; }

        [field: SerializeField]
        [JsonProperty("growthFundSeparatorLineTop"), JsonConverter(typeof(HexColorJsonConverter))] public Color GrowthFundSeparatorLineTop { get; set; }

        [field: SerializeField]
        [JsonProperty("popupInterstitialBgDark"), JsonConverter(typeof(HexColorJsonConverter))] public Color PopupInterstitialBgDark { get; set; }

        [field: SerializeField]
        [JsonProperty("popupInterstitialTitle"), JsonConverter(typeof(HexColorJsonConverter))] public Color PopupInterstitialTitle { get; set; }
    }
}