using Studio.Modules.Core.Audio;
using Studio.Modules.Core.Scenes;
using Studio.Modules.Core.Systems;
using UnityEngine;
using Zenject;
using static Studio.Sudoku.Systems.SudokuData;

namespace Studio.Sudoku.Systems
{
	public class GameplaySystem : MonoBehaviour
	{
		#region Injection
		[Inject] protected SceneController _sceneController;
		[Inject] protected AudioService _audioService;
		[Inject] protected ScoreSystem _scoreSystem;
		[Inject] protected GameplaySettings _gameplaySettings;
		[Inject] protected SudokuData _sudokuData;
		#endregion

		#region Variables
		[SerializeField] private UISystem _uiSystem;
		[SerializeField] private int _maxFailuresAllowed;

		protected int selectedGridData = -1;
		protected bool _paused;
		protected bool _gameOver;

		protected const string PAUSE_DEFAULT_SOUND_CLIP = "pause";
		protected const string GAME_OVER_DEFAULT_SOUND_CLIP = "game_over";
		protected const string GAME_FINISHED_DEFAULT_SOUND_CLIP = "game_finished";
		#endregion

		#region Properties
		public UISystem UiSystem { get { return _uiSystem; } }
		#endregion

		#region Methods
		void Start() 
		{
			Initialize();
		}

		void OnDestroy()
		{
			Dispose();
		}

		void Update()
		{
			Tick(Time.deltaTime);
		}

		public void Initialize() 
		{
			_gameplaySettings.SetMaxFailuresAmount(_maxFailuresAllowed);
			_audioService.ResumeMusic();

			_scoreSystem.Initialize();
			_sudokuData.Initialize();
			_uiSystem.Initialize();

			_scoreSystem.InitScoring(_gameplaySettings.MaxFailures, 0f);
		}

		public void Tick(float deltaTime) 
		{
			_scoreSystem.Tick(deltaTime);
			_uiSystem.Tick(deltaTime);
		}

		public void Dispose()
		{
			_uiSystem.Dispose();
			_sudokuData.Dispose();
			_scoreSystem.Dispose();

			selectedGridData = -1;
		}

		public string GetGameMode()
		{
			return _gameplaySettings.GetGameDifficulty();
		}

		public SudokuBoardData GetGameGridData(string level)
		{
			selectedGridData = Random.Range(0, _sudokuData.sudoku_game[level].Count);
			return _sudokuData.sudoku_game[level][selectedGridData];			
		}

		public int GetMaximumFailuresAllowed() 
		{
			return _gameplaySettings.MaxFailures;
		}

		public void OnPlayerFail() 
		{
			_scoreSystem.OnPlayerFail();

			if (_scoreSystem.IsPlayerDead) 
			{
				GameOver();
			}
		}

		public void Pause(bool pause)
		{
			if (_gameOver) return;

			if (pause)
			{
				_scoreSystem.SetTimerState(false);
				_audioService.PauseMusic();
				_audioService.PlaySound(PAUSE_DEFAULT_SOUND_CLIP);
				_uiSystem.ShowPausePopup();

				_paused = true;
			}
			else
			{
				_scoreSystem.SetTimerState(true);
				_audioService.ResumeMusic();

				_paused = false;
			}
		}

		public void GameOver()
		{
			_gameOver = true;

			_audioService.PauseMusic();
			_audioService.PlaySound(GAME_OVER_DEFAULT_SOUND_CLIP);
			_scoreSystem.SetTimerState(false);
			_uiSystem.ShowGameOverPopup();
		}

		public void GameFinished()
		{
			_gameOver = true;

			_audioService.PauseMusic();
			_audioService.PlaySound(GAME_FINISHED_DEFAULT_SOUND_CLIP);
			_scoreSystem.SetTimerState(false);
			_uiSystem.ShowEndOfGamePopup();
		}

		public void Retry() 
		{
			_sceneController.LoadGameScene();
		}

		public void QuitPlaying() 
		{
			_sceneController.LoadStartScene();
		}

		public int GetPlayTimerValue() 
		{
			return Mathf.FloorToInt(_scoreSystem.TimePlaying);
		}
		#endregion
	}
}

