using System;
using UnityEngine;

namespace _Scripts.GrowthFund.Data
{
    [Serializable]
    public class GrowthFundLocaData
    {
        [field: SerializeField]
        public string MainPanelHeadline { get; set; }
        [field: SerializeField]
        public string MainPanelDescription { get; set; }
        [field: SerializeField]
        public string InterstitialHeadline { get; set; }
        [field: SerializeField]
        public string InterstitialDescription { get; set; }
        [field: SerializeField]
        public string MoreInfoButton { get; set; }
        [field: SerializeField]
        public string InfoPopupHeader { get; set; }
        [field: SerializeField]
        public string InfoPopupTitle1 { get; set; }
        [field: SerializeField]
        public string InfoPopupTitle2 { get; set; }
        [field: SerializeField]
        public string InfoPopupTitle3 { get; set; }
        [field: SerializeField]
        public string InfoPopupBody1 { get; set; }
        [field: SerializeField]
        public string InfoPopupBody2 { get; set; }
        [field: SerializeField]
        public string InfoPopupBody3 { get; set; }
        [field: SerializeField]
        public string RecapDescription { get; set; }
        [field: SerializeField]
        public string GrowthFundCompleteDescription { get; set; }
    }
}