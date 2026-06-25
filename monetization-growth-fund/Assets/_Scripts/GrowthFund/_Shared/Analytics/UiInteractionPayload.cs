using System;
using System.Collections.Generic;

namespace _Scripts.GrowthFund._Shared.Analytics
{
    [Serializable]
    public class UiInteractionPayload : IDataPlatformPayload
    {
        public string GetEventName() { return "UiInteraction"; }
        
        public string GameObjectName { get; set; }
        public string PanelName { get; set; }
        public string Trigger { get; set; }
        public string Source { get; set; }

        public IDictionary<string, string> Context;
    }
}