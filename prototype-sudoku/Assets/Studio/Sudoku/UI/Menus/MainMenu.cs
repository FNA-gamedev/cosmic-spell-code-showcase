using Studio.Modules.Core.Audio;
using Studio.Modules.Core.Scenes;
using Studio.Modules.Core.Systems;
using Studio.Sudoku.UI.Buttons;
using UnityEngine;
using Zenject;
using static Studio.Sudoku.Systems.Enums;

namespace Studio.Sudoku.UI.Menus
{
    public class MainMenu : MenuController
    {
		#region Injection
		[Inject] protected SceneController _sceneController;
        [Inject] protected AudioService _audioService;
        [Inject] protected GameplaySettings _gameplaySettings;
		#endregion

		#region Variables
		[Header("Main buttons")]
        [SerializeField] private CanvasGroup _mainCanvas;
        [SerializeField] private BaseButton _playButton;
        [SerializeField] private BaseButton _quitButton;

        [Header("Game mode buttons")]
        [SerializeField] private CanvasGroup _gameModesCanvas;
        [SerializeField] private BaseButton _easyModeButton;
        [SerializeField] private BaseButton _mediumModeButton;
        [SerializeField] private BaseButton _hardModeButton;
        [SerializeField] private BaseButton _challengeModeButton;
		#endregion

		#region Methods
		void Start() 
        {
            Initizalize();
        }

        void OnDestroy() 
        {
            Dispose();
        }

        protected override void InitializeInternal()
        {
            _audioService.PlayMusic();
            _mainCanvas.gameObject.SetActive(true);
            _gameModesCanvas.gameObject.SetActive(false);
        }

        protected override void DisposeInternal()
        {

        }

        protected override void TickInternal(float deltaTime)
        {

        }

        protected override void SubscribeToEventsInternal()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _quitButton.onClick.AddListener(OnExitButtonClick);

            _easyModeButton.onClick.AddListener(() => StartGame(eGameDifficulty.EASY));
            _mediumModeButton.onClick.AddListener(() => StartGame(eGameDifficulty.MEDIUM));
            _hardModeButton.onClick.AddListener(() => StartGame(eGameDifficulty.HARD));
            _challengeModeButton.onClick.AddListener(() => StartGame(eGameDifficulty.CHALLENGE));
        }

        protected override void UnSubscribeToEventsInternal()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _quitButton.onClick.RemoveListener(OnExitButtonClick);

            _easyModeButton.onClick.RemoveAllListeners();
            _mediumModeButton.onClick.RemoveAllListeners();
            _hardModeButton.onClick.RemoveAllListeners();
            _challengeModeButton.onClick.RemoveAllListeners();
        }

        private void OnPlayButtonClick() 
        {
            _mainCanvas.gameObject.SetActive(false);
            _gameModesCanvas.gameObject.SetActive(true);
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
        }

        private void StartGame(eGameDifficulty mode) 
        {
            _gameplaySettings.SetGameDifficulty(mode);
            _sceneController.LoadGameScene();
        }
		#endregion
	}
}

