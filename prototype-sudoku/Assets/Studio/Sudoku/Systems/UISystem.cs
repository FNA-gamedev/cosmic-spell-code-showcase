using Studio.Sudoku.UI.Menus;
using Studio.Sudoku.UI.Popups;
using UnityEngine;

namespace Studio.Sudoku.Systems
{
	public class UISystem : MonoBehaviour
	{
		#region Variables
		[Header("Menus")]
		[SerializeField] private BoardGrid _board;

		[Header("Popups")]
		[SerializeField] private PausePopup _pausePopup;
		[SerializeField] private QuitConfirmationPopup _quitConfirmationPopup;
		[SerializeField] private GameOverPopup _gameOverPopup;
		[SerializeField] private GameFinishedPopup _gameFinishedPopup;
		#endregion

		#region Methods
		public void Initialize() 
		{
			_board.Initizalize();
			_pausePopup.Initizalize();
			_quitConfirmationPopup.Initizalize();
			_gameOverPopup.Initizalize();
			_gameFinishedPopup.Initizalize();

			_pausePopup.Hide();
			_quitConfirmationPopup.Hide();
			_gameOverPopup.Hide();
			_gameFinishedPopup.Hide();
		}

		public void Tick(float deltaTime) 
		{
			_board.Tick(deltaTime);
			_pausePopup.Tick(deltaTime);
			_quitConfirmationPopup.Tick(deltaTime);
			_gameOverPopup.Tick(deltaTime);
			_gameFinishedPopup.Tick(deltaTime);
		}

		public void Dispose()
		{
			_gameFinishedPopup.Dispose();
			_gameOverPopup.Dispose();
			_quitConfirmationPopup.Dispose();
			_pausePopup.Dispose();
			_board.Dispose();
		}

		public void HideMenu(MenuController menu)
		{
			menu?.Hide();
		}

		public void HidePopup(MenuController popup)
		{
			popup?.Hide();
		}

		public void ShowPausePopup()
		{
			_pausePopup.Show();
		}

		public void ShowQuitConfirmationPopup()
		{
			_quitConfirmationPopup.Show();
		}

		public void ShowGameOverPopup()
		{
			_gameOverPopup.Show();
		}

		public void ShowEndOfGamePopup()
		{
			_gameFinishedPopup.Show();
		}
		#endregion
	}
}