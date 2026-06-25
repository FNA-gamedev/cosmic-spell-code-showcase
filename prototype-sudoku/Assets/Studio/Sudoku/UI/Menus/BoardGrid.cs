using Studio.Modules.Core.Audio;
using Studio.Sudoku.Systems;
using Studio.Sudoku.UI.Buttons;
using Studio.Sudoku.UI.EventListeners;
using Studio.Sudoku.UI.Widgets;
using Studio.Utils.ExtensionMethods;
using Studio.Utils.Pools;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using static Studio.Sudoku.Systems.Enums;
using static Studio.Sudoku.Systems.SudokuData;

namespace Studio.Sudoku.UI.Menus
{
    public class BoardGrid : MenuController, IGridSquareButtonEventsListener, INumberButtonEventsListener
    {
		#region Injection
		[Inject] protected DiContainer _zenject;
        [Inject] protected GameplaySystem _gameplaySystem;
        [Inject] protected AudioService _audioService;
		#endregion

		#region Variables
		[Header("Header")]
        [SerializeField] private FailMarkerContainer _failuresContainer;
        [SerializeField] private TextMeshProUGUI _timerLabel;

        [Header("Body")]
        [SerializeField] private RectTransform _gridWidgetsParent;
        [SerializeField] private GridSquare _gridWidgetsSource;

        [Header("Footer")]
        [SerializeField] private List<NumberButton> _numberButtons;
        [SerializeField] private BaseButton _backButton;
        [SerializeField] private SwitchButton _eraserButton;
        [SerializeField] private SwitchButton _notesButton;
        [SerializeField] private BaseButton _pauseButton;

        protected bool _initialized;
        protected InternalPool<GridSquare> _gridWidgetsPool;
        protected List<GridSquare> _gridWidgets;
        protected const string ERASE_DEFAULT_SOUND_CLIP = "clear_info";

        private GridSquare selectedSquare;
        private int selectedNumber;
        private eGameMode gameMode = eGameMode.NONE;
        private const int GRID_DEFAULT_DIMENSION = 9;
        private const int GROUP_DEFAULT_DIMENSION = 3;
		#endregion

		#region Properties
		protected eGameMode GameMode 
        { 
            get { return gameMode; }
            set 
            {
                gameMode = value;

				switch (gameMode)
				{
					case eGameMode.ERASER:
                        if (!_eraserButton.Active) _eraserButton.Active = true;
                        if (_notesButton.Active) _notesButton.Active = false;
                        break;
					case eGameMode.NOTES:
                        if (_eraserButton.Active) _eraserButton.Active = false;
                        if (!_notesButton.Active) _notesButton.Active = true;
                        break;
					default:
                        if (_eraserButton.Active) _eraserButton.Active = false;
                        if (_notesButton.Active) _notesButton.Active = false;
                        break;
				}
			}
        }
		#endregion

		#region Methods
		protected override void InitializeInternal()
        {
            if (_initialized) return;

            _failuresContainer.Initialize();

            _gridWidgetsPool = new InternalPool<GridSquare>(_gridWidgetsSource, _gridWidgetsParent, 4, _zenject);
            _gridWidgets = new List<GridSquare>();

            CreateGrid();

            string gameMode = _gameplaySystem.GetGameMode();

            if (string.IsNullOrEmpty(gameMode))
                SetGridData(eGameDifficulty.EASY.ToString());
            else
                SetGridData(gameMode);

            InitializeInputs();

            _initialized = true;
        }

        protected override void DisposeInternal()
        {
            DisposeInputs();
            DisposeGrid();
            _failuresContainer.Dispose();

            _initialized = false;
        }

        protected override void SubscribeToEventsInternal()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
            _eraserButton.onClick.RemoveAllListeners();
            _eraserButton.onClick.AddListener(OnEraserButtonClick);
            _notesButton.onClick.RemoveAllListeners();
            _notesButton.onClick.AddListener(OnNotesButtonClick);
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        protected override void UnSubscribeToEventsInternal()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClick);
            _eraserButton.onClick.RemoveListener(OnEraserButtonClick);
            _notesButton.onClick.RemoveListener(OnNotesButtonClick);
            _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }

        protected override void TickInternal(float deltaTime)
        {
            RefreshTimer();
        }

        public void OnGridSquareSelected(GridSquare square)
        {
            if (selectedSquare != square) 
            {
                if (selectedSquare != default) 
                {
                    selectedSquare.Highlight(false);
                    selectedSquare.IsSelected = false;
                }

                selectedSquare = square;
                selectedSquare.IsSelected = !selectedSquare.IsBlockedByDefault;
                selectedSquare.NotesEnabled = GameMode == eGameMode.NOTES;

                if (GameMode == eGameMode.ERASER) 
                {
                    _audioService.PlaySound(ERASE_DEFAULT_SOUND_CLIP);
                    selectedSquare.Clear();
                } 

                if (selectedSquare != default)
                {
                    int selectedSquareRow = selectedSquare.RowIndex;
                    int selectedSquareColumn = selectedSquare.ColumnIndex;
                    int selectedSquareGroup = selectedSquare.GroupIndex;

                    foreach (GridSquare squareWidget in _gridWidgets)
                    {
                        bool shouldBeHighlighted = (selectedSquareRow == squareWidget.RowIndex
                                                    || selectedSquareColumn == squareWidget.ColumnIndex
                                                    || selectedSquareGroup == squareWidget.GroupIndex);

                        squareWidget.Highlight(shouldBeHighlighted);
                    }
                }
            }                        		
        }

        public void OnNumberButtonSelected(NumberButton button)
        {
            selectedNumber = button.value;
 
            if (selectedSquare != default)
            {
                bool gameInNotesMode = GameMode == eGameMode.NOTES;
                selectedSquare.NotesEnabled = gameInNotesMode;

                if (gameInNotesMode)
                {
                    selectedSquare.SetNote(selectedNumber);
                }
                else 
                {
                    selectedSquare.SetNumber(selectedNumber);
                    CheckLevelCompletion();
                }
            }
        }

        public void OnPlayerFail()
        {
            _gameplaySystem.OnPlayerFail();
            _failuresContainer.OnPlayerFail();
        }

        private void RefreshTimer()
        {
            int timeElapsed = _gameplaySystem.GetPlayTimerValue();
            string timerValue = TimeSpan.FromSeconds(timeElapsed).ToCronometer(TIME_UNIT.SECOND, TIME_UNIT.HOUR);

            _timerLabel.text = timerValue;
        }

        private void CreateGrid()
        {
            _gridWidgets.Clear();
            int squareIndex = 0;

            for (int row = 0; row < GRID_DEFAULT_DIMENSION; ++row)
            {
                for (int column = 0; column < GRID_DEFAULT_DIMENSION; ++column)
                {
                    int groupRow = Mathf.FloorToInt(row / GROUP_DEFAULT_DIMENSION);
                    int groupColumn = Mathf.FloorToInt(column / GROUP_DEFAULT_DIMENSION);
                    int groupIndex = (groupRow * GROUP_DEFAULT_DIMENSION) + groupColumn;

                    GridSquare square = _gridWidgetsPool.Spawn();
                    square.Initialize();
                    square.SetData(this, squareIndex, row, column, groupIndex);

                    _gridWidgets.Add(square);
                    squareIndex++;
                }
            }
        }

        private void DisposeGrid()
        {
            foreach (GridSquare widget in _gridWidgets)
            {
                widget.Dispose();
                _gridWidgetsPool.Despawn(widget);
            }

            _gridWidgets.Clear();
        }

        private void SetGridData(string level)
        {
            SudokuBoardData gridData = _gameplaySystem.GetGameGridData(level);

            for (int index = 0; index < _gridWidgets.Count; ++index)
            {
                _gridWidgets[index].ConfigValues(gridData.unsolved_data[index], gridData.solved_data[index]);
            }
        }

        private void InitializeInputs() 
        {
			foreach (NumberButton button in _numberButtons)
			{
                button.Initialize();
                button.SetEventsListener(this);
            }
        }

        private void DisposeInputs()
        {
            foreach (NumberButton button in _numberButtons)
            {
                button.Dispose();
            }
        }

        private void OnBackButtonClick()
        {
            _gameplaySystem.UiSystem.ShowQuitConfirmationPopup();
        }

        private void OnEraserButtonClick()
        {
            if (GameMode == eGameMode.ERASER)
                GameMode = eGameMode.NONE;
            else
                GameMode = eGameMode.ERASER;

            if (GameMode == eGameMode.ERASER && selectedSquare != default) 
            {
                _audioService.PlaySound(ERASE_DEFAULT_SOUND_CLIP);
                selectedSquare.Clear();
            }
        }

        private void OnNotesButtonClick() 
        {
            if (GameMode == eGameMode.NOTES)
                GameMode = eGameMode.NONE;
            else
                GameMode = eGameMode.NOTES;

            if (GameMode == eGameMode.NOTES && selectedSquare != default)
            {
                selectedSquare.NotesEnabled = true;
            }
        }

        private void OnPauseButtonClick() 
        {
            _gameplaySystem.Pause(true);
        }

        private void CheckLevelCompletion() 
        {
            bool isGameFinished = true;

			foreach (GridSquare square in _gridWidgets)
			{
                isGameFinished &= square.HasCorrectValue;
            }

            if (isGameFinished)
                _gameplaySystem.GameFinished();        
        }
		#endregion
	}
}

