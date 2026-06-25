using Zenject;

namespace Studio.Sudoku.Systems
{
    public class SudokuDataInstaller : MonoInstaller
    {
        #region Methods
        public override void InstallBindings()
        {
            Container.Bind<SudokuData>().AsSingle();
        }
		#endregion
	}
}
