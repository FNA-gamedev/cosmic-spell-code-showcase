using Studio.Sudoku.UI.Widgets;

namespace Studio.Sudoku.UI.EventListeners
{
    public interface IGridSquareButtonEventsListener
    {
		#region Methods
		void OnGridSquareSelected(GridSquare square);
        void OnPlayerFail();
		#endregion
	}
}

