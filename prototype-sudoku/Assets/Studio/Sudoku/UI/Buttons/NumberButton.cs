using Studio.Sudoku.UI.EventListeners;

namespace Studio.Sudoku.UI.Buttons
{
    public class NumberButton : BaseButton
    {
		#region Variables
		public int value = 0;

        private bool _initialized;
        private INumberButtonEventsListener _listener;
		#endregion

		#region Methods
		public override void Initialize()
        {
            if (_initialized) return;

            base.Initialize();
            SubscribeToEvents();

            _initialized = true;
        }

        public override void Dispose()
        {
            UnSubscribeToEvents();
            _listener = default;

            base.Dispose();
            _initialized = false;
        }

        protected void SubscribeToEvents()
        {
            onClick.AddListener(OnNumberButtonClick);
        }

        protected void UnSubscribeToEvents()
        {
            onClick.RemoveListener(OnNumberButtonClick);
        }

        public void SetEventsListener(INumberButtonEventsListener listener) 
        {
            _listener = listener;
        }

        private void OnNumberButtonClick() 
        {
            _listener?.OnNumberButtonSelected(this);
        }
		#endregion
	}
}

