using Zenject;

namespace Studio.Modules.Core.Audio
{
    public class AudioInstaller : MonoInstaller
    {
		#region Variables
		public MusicSettings musicSettings;
        public SoundSettings soundSettings;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            Container.BindInstance(musicSettings);
            Container.BindInstance(soundSettings);

            Container.Bind<AudioService>().AsSingle();
        }
		#endregion
	}
}
