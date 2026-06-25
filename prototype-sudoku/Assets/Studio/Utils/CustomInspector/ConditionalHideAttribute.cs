using System;
using UnityEngine;

namespace Studio.Utils.CustomInspector 
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
                    AttributeTargets.Class | AttributeTargets.Struct |
                    AttributeTargets.Enum, Inherited = true)]
    public class ConditionalHideAttribute : PropertyAttribute
    {
		#region Variables
		public string ConditionalSourceField = "";
        public bool HideInInspector = true;
		#endregion

		#region Constructor
		public ConditionalHideAttribute(string conditionalSourceField)
        {
            this.ConditionalSourceField = conditionalSourceField;
            this.HideInInspector = true;
        }

        public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector)
        {
            this.ConditionalSourceField = conditionalSourceField;
            this.HideInInspector = hideInInspector;
        }
		#endregion
	}
}