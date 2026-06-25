using System;
using UnityEngine;

namespace _Scripts.GrowthFund.Data
{
    [Serializable]
    public class GrowthFundColourPaletteData
    {
        [field: SerializeField] 
        public Color DefaultItemBorder { get; set; }
        
        [field: SerializeField] 
        public Color DefaultBannerBorder { get; set; }
        
        [field: SerializeField] 
        public Color DefaultGraphicBorder { get; set; }
        
        [field: SerializeField] 
        public Color DefaultItemBackground { get; set; }
        
        [field: SerializeField] 
        public Color DefaultPanelBackground { get; set; }
        
        [field: SerializeField] 
        public Color DefaultPanelGradient { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundFooterBg { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundFooterItemBg { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundHeaderBg { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundBodyInfoBg { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundBodyInfoBorder { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundItemBg { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundProgressionBar { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundProgressionBarBg { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundProgressionBarBorder { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundProgressionBarGradient { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundProgressionMarkerNotReached { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundProgressionMarkerReached { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundSeparatorLineBottom { get; set; }
        
        [field: SerializeField] 
        public Color GrowthFundSeparatorLineTop { get; set; }
        
        [field: SerializeField] 
        public Color PopupInterstitialBgDark { get; set; }
        
        [field: SerializeField] 
        public Color PopupInterstitialTitle { get; set; }
    }
}