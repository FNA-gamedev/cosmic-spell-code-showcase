using Zenject;

namespace Studio.Modules.Core.Scenes
{
    public class SceneInstaller : MonoInstaller
    {
		#region Methods
		public override void InstallBindings()
        {
            Container.Bind<SceneController>().AsSingle();
        }
		#endregion
	}
}
