using Studio.Sudoku.UI.EventListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Studio.Sudoku.UI.Widgets
{
    [RequireComponent(typeof(Button))]
    public class GridSquare : BaseWidget 
    {
        [Serializable]
        protected struct SquareNote
        {
            public int value;
            public RectTransform note_obj;
        }

		#region Variables
		[SerializeField] private TextMeshProUGUI value;
        [SerializeField] private Color defaultSquareColor;
        [SerializeField] private Color highlightSquareColor;
        [SerializeField] private Color wrongAnswerColor;
        [SerializeField] private List<SquareNote> squareNotes;

        private Button _uiButton;
        private IGridSquareButtonEventsListener _listener;
        private int _gridIndex = -1;
        private int _rowIndex = -1;
        private int _columnIndex = -1;
        private int _groupIndex = -1;
        private bool _selected;
        private int _currentValue = 0;
        private int _correctValue = 0;
        private bool _blockedByDefault;
        private bool _notesEnabled;
		#endregion

		#region Properties
		public bool IsSelected 
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public int GridIndex 
        { 
            get { return _gridIndex; } 
            set { _gridIndex = value; } 
        }
        public int RowIndex
        {
            get { return _rowIndex; }
        }
        public int ColumnIndex
        {
            get { return _columnIndex; }
        }
        public int GroupIndex
        {
            get { return _groupIndex; }
        }
        public bool IsBlockedByDefault
        {
            get { return _blockedByDefault; }
        }
        public bool NotesEnabled
        {
            get { return _notesEnabled; }
            set 
            {
                if (IsBlockedByDefault) return;
                if (_notesEnabled == value) return;

                _notesEnabled = value;
            }
        }
        public bool HasCorrectValue { get { return _currentValue == _correctValue; } }
		#endregion

		#region Methods
		protected override void InitializeInternal()
        {
            _uiButton = GetComponent<Button>();
        }

        protected override void DisposeInternal()
        {
            _listener = default;
        }

        protected override void SubscribeToEventsInternal()
        {
            _uiButton.onClick.AddListener(OnGridSquareClick);
        }

        protected override void UnSubscribeToEventsInternal()
        {
            _uiButton.onClick.RemoveListener(OnGridSquareClick);
        }

        public void SetData(IGridSquareButtonEventsListener listener, int index, int rowIndex, int columnIndex, int groupIndex)
        {
            _listener = listener;
            _gridIndex = index;
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
            _groupIndex = groupIndex;
        }

        public void ConfigValues(int initialValue, int expectedValue) 
        {
            _currentValue = initialValue;
            _correctValue = expectedValue;

            ClearNotes();
            DisplayText();
            OnSetNumber();

            if (_currentValue == _correctValue) 
            {
                _blockedByDefault = true;
            } 
        }

        public void Clear() 
        {
            if (!IsBlockedByDefault) 
            {
                if (!NotesEnabled)
                    SetNumber(0);
                else
                    ClearNotes();
            }
        }

        public void SetNumber(int number)
        {
            if (IsBlockedByDefault) return;
            if (_currentValue == number) return;

            _currentValue = number;
            ClearNotes();
            DisplayText();
            OnSetNumber();
        }

        public void OnSetNumber()
        {
            if (_selected)
            {
                var colors = _uiButton.colors;

                if (_currentValue != 0 && _currentValue != _correctValue)
                {
                    colors.normalColor = wrongAnswerColor;
                    _listener.OnPlayerFail();
                }
                else
                {
                    colors.normalColor = highlightSquareColor;
                }

                _uiButton.colors = colors;
            }
        }

        public void SetNote(int number)
        {
            if (IsBlockedByDefault) return;
            if (!NotesEnabled) return;
            SetNumber(0);

            SquareNote selectedNote = squareNotes.Where(n => n.value == number).FirstOrDefault();

            if (!selectedNote.Equals(default(SquareNote))) 
            {
                RectTransform noteObject = selectedNote.note_obj;

                if (noteObject != default) 
                {
                    bool noteIsActive = noteObject.gameObject.activeInHierarchy;
                    noteObject.gameObject.SetActive(!noteIsActive);
                }
            }
        }

        public void Highlight(bool shouldBeHighlighted)
        {
            if (!_selected)
            {
                var colors = _uiButton.colors;
                bool hasWrongValue = _currentValue != 0 && _currentValue != _correctValue;

                if (hasWrongValue) return;

                if (shouldBeHighlighted)
                    colors.normalColor = highlightSquareColor;
                else
                    colors.normalColor = defaultSquareColor;

                _uiButton.colors = colors;
            }
        }

        private void OnGridSquareClick()
        {
            _listener?.OnGridSquareSelected(this);
        }

        private void DisplayText() 
        {
            if (_currentValue <= 0)
            {
                value.text = string.Empty;
            }
            else
            {
                value.text = _currentValue.ToString();
            }
        }

        private void ClearNotes()
        {
            foreach (SquareNote note in squareNotes)
            {
                RectTransform noteObject = note.note_obj;
                if (noteObject != default) noteObject.gameObject.SetActive(false);
            }
        }
		#endregion
	}
}