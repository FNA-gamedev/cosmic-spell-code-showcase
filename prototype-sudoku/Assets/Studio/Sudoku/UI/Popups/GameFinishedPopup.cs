using Studio.Sudoku.Systems;
using Studio.Sudoku.UI.Buttons;
using Studio.Sudoku.UI.Menus;
using Studio.Utils.ExtensionMethods;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Studio.Sudoku.UI.Popups
{
    public class GameFinishedPopup : MenuController
    {
		#region Injection
		[Inject] protected GameplaySystem _gameplaySystem;
		#endregion

		#region Variables
		[SerializeField] private TextMeshProUGUI _timePlayingLabel;
        [SerializeField] private BaseButton _retryButton;
        [SerializeField] private BaseButton _quitButton;
		#endregion

		#region Methods
		protected override void InitializeInternal()
        {

        }

        protected override void DisposeInternal()
        {

        }

        protected override void TickInternal(float deltaTime)
        {

        }

        protected override void SubscribeToEventsInternal()
        {
            _retryButton.onClick.AddListener(OnRetryButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        protected override void UnSubscribeToEventsInternal()
        {
            _retryButton.onClick.RemoveListener(OnRetryButtonClick);
            _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        }

        protected override void PreShow()
        {
            Refresh();
        }

        protected void Refresh() 
        {
            int timeElapsedPlaying = _gameplaySystem.GetPlayTimerValue();
            string timerValue = TimeSpan.FromSeconds(timeElapsedPlaying).ToCronometer(TIME_UNIT.SECOND, TIME_UNIT.HOUR);

            _timePlayingLabel.text = timerValue;
        }

        private void OnRetryButtonClick()
        {
            _gameplaySystem.Retry();
        }

        private void OnQuitButtonClick() 
        {
            _gameplaySystem.QuitPlaying();
        }
		#endregion
	}
}

