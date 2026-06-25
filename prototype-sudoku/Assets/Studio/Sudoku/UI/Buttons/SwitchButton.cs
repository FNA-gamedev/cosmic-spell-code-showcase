using UnityEngine;

namespace Studio.Sudoku.UI.Buttons
{
    public class SwitchButton : BaseButton
    {
		#region Variables
		[SerializeField] private RectTransform _activeState;
        [SerializeField] private RectTransform _inactiveState;

        protected bool button_active;
		#endregion

		#region Properties
		public bool Active 
        { 
            get { return button_active; }
            set 
            {
                if (button_active == value) return;

                button_active = value;
                RefreshVisuals();
            }
        }
		#endregion

		#region Methods
		public override void Initialize()
        {
            base.Initialize();
            button_active = false;
            RefreshVisuals();
            SubscribeToEvents();
        }

        public override void Dispose()
        {
            button_active = false;
            UnSubscribeToEvents();
            base.Dispose();
        }

        protected void SubscribeToEvents()
        {
            onClick.AddListener(SwitchState);
        }

        protected void UnSubscribeToEvents()
        {
            onClick.RemoveListener(SwitchState);
        }

        private void SwitchState() 
        {
            Active = !Active;
        }

        private void RefreshVisuals() 
        {
            _activeState.gameObject.SetActive(button_active);
            _inactiveState.gameObject.SetActive(!button_active);
        }
		#endregion
	}
}

