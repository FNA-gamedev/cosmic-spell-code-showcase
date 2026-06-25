using Studio.Sudoku.Systems;
using Studio.Sudoku.UI.Buttons;
using Studio.Sudoku.UI.Menus;
using UnityEngine;
using Zenject;

namespace Studio.Sudoku.UI.Popups
{
    public class QuitConfirmationPopup : MenuController
    {
		#region Injection
		[Inject] protected GameplaySystem _gameplaySystem;
		#endregion

		#region Variables
		[SerializeField] private BaseButton _continueButton;
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
            _continueButton.onClick.AddListener(OnGameResume);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        protected override void UnSubscribeToEventsInternal()
        {
            _continueButton.onClick.AddListener(OnGameResume);
            _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        }

        private void OnGameResume()
        {
            _gameplaySystem.Pause(false);
            Hide();
        }

        private void OnQuitButtonClick() 
        {
            _gameplaySystem.QuitPlaying();
        }
		#endregion
	}
}

