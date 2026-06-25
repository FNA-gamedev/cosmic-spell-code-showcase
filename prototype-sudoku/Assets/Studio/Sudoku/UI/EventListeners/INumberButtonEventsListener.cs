using Studio.Sudoku.UI.Buttons;

namespace Studio.Sudoku.UI.EventListeners
{
    public interface INumberButtonEventsListener
    {
		#region Methods
		void OnNumberButtonSelected(NumberButton button);
		#endregion
	}
}

