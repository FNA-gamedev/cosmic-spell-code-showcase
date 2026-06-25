using Zenject;

namespace Studio.Modules.Core.Systems
{
    public class SettingsInstaller : MonoInstaller
    {
		#region Methods
		public override void InstallBindings()
        {
            Container.Bind<GameplaySettings>().AsSingle();
        }
		#endregion
	}
}
