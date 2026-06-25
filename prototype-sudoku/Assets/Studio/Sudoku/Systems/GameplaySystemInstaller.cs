using Zenject;

namespace Studio.Sudoku.Systems
{
    public class GameplaySystemInstaller : MonoInstaller
    {
		#region Variables
		public GameplaySystem gameplaySystem;
		#endregion

		#region Methods
		public override void InstallBindings()
        {
            Container.Bind<GameplaySystem>().FromInstance(gameplaySystem).AsSingle();
        }
		#endregion
	}
}
