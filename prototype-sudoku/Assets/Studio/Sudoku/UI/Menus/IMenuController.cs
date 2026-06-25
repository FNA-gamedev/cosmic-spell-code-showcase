using DG.Tweening;

namespace Studio.Sudoku.UI.Menus
{
    public interface IMenuController
    {
		#region Methods
		void Initizalize();
        void Dispose();
        void Tick(float deltaTime);
        void SubscribeToEvents();
        void UnsubscribeToEvents();
        Sequence Show();
        void ShowInstantly();
        Sequence Hide();
        void HideInstantly();
		#endregion
	}
}
