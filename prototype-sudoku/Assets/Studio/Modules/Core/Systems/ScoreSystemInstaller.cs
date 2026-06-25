using Zenject;

namespace Studio.Modules.Core.Systems
{
    public class ScoreSystemInstaller : MonoInstaller
    {
        #region Methods
        public override void InstallBindings()
        {
            Container.Bind<ScoreSystem>().AsSingle();
        }
		#endregion
	}
}
