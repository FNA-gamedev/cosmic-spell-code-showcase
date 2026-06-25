using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Studio.Modules.Core.Audio 
{
    public class AudioService 
    {
        #region Variables
        protected readonly MusicSettings _musicSettings;
        protected readonly SoundSettings _soundSettings;
        private float _musicVolume;
        private int _songIndex;
        private bool _musicLoopStarted = false;
        private float _soundVolume;

        protected const string MUSIC_VOLUME_ATTRIBUTE = "MusicVolume";
        protected const string SOUND_VOLUME_ATTRIBUTE = "SoundsVolume";
		#endregion

		#region Properties
		public bool MusicIsMuted
        {
            get => MusicSavedVolume <= 0f;

            set
            {
                if (value)
                {
                    MusicSavedVolume = 0f;
                    MusicVolume = 0f;
                }
                else
                {
                    MusicSavedVolume = 1f;
                    MusicVolume = 1f;
                }
            }
        }
        public float MusicVolume
        {
            get => _musicVolume;

            set
            {
                float volume = MusicIsMuted ? 0f : value;
                _musicSettings.mixer.audioMixer.SetFloat(MUSIC_VOLUME_ATTRIBUTE, volume);
                _musicVolume = volume;
            }
        }
        private float MusicSavedVolume
        {
            get
            {
                if (PlayerPrefs.HasKey(MUSIC_VOLUME_ATTRIBUTE))
                {
                    return PlayerPrefs.GetFloat(MUSIC_VOLUME_ATTRIBUTE);
                }
                else
                {
                    return 1f;
                }
            }

            set => PlayerPrefs.SetFloat(MUSIC_VOLUME_ATTRIBUTE, value);
        }
        public bool SoundIsMuted
        {
            get => SoundSavedVolume <= 0f;

            set
            {
                if (value)
                {
                    SoundSavedVolume = 0f;
                    SoundVolume = 0f;
                }
                else
                {
                    SoundSavedVolume = 1f;
                    SoundVolume = 1f;
                }
            }
        }
        public float SoundVolume
        {
            get => _soundVolume;

            set
            {
                float volume = SoundIsMuted ? 0f : value;
                _soundSettings.mixer.audioMixer.SetFloat(SOUND_VOLUME_ATTRIBUTE, volume);
                _soundVolume = volume;
            }
        }
        private float SoundSavedVolume
        {
            get
            {
                if (PlayerPrefs.HasKey(SOUND_VOLUME_ATTRIBUTE))
                {
                    return PlayerPrefs.GetFloat(SOUND_VOLUME_ATTRIBUTE);
                }
                else
                {
                    return 1f;
                }
            }

            set => PlayerPrefs.SetFloat(SOUND_VOLUME_ATTRIBUTE, value);
        }
		#endregion

		#region Constructor
		public AudioService(MusicSettings musicSettings, SoundSettings soundSettings)
        {
            this._musicSettings = musicSettings;
            this._soundSettings = soundSettings;

            MusicVolume = MusicSavedVolume;
            SoundVolume = SoundSavedVolume;
        }
		#endregion

		#region Methods
		public void SetMusicVolume(float volume)
        {
            _musicSettings.mixer.audioMixer.SetFloat(MUSIC_VOLUME_ATTRIBUTE, volume);
        }

        public void SetSoundsVolume(float volume)
        {
            _soundSettings.mixer.audioMixer.SetFloat(SOUND_VOLUME_ATTRIBUTE, volume);
        }

        public void PlayMusic()
        {
            PlayNextSong();
            if (!_musicLoopStarted) UpdateLoop();
        }

        public void PlayMusicOneShot(AudioClip song)
        {
            if (_musicSettings.player.isPlaying)
            {
                var sequence = DOTween.Sequence();

                sequence.Append(FadeOut(1f));
                sequence.AppendCallback(() => PlaySong(song));
                sequence.Append(FadeIn(1f));
            }
            else
            {
                PlaySong(song);
            }
        }

        public void PauseMusic()
        {
            MusicIsMuted = true;
            _musicSettings.player.Pause();
        }

        public void ResumeMusic()
        {
            MusicIsMuted = false;
            _musicSettings.player.UnPause();
        }

        public void StopMusic()
        {
            MusicIsMuted = true;
            _musicSettings.player.Stop();
        }

        public void PlaySound(string soundName)
        {
            var clip = FindClip(soundName);

            if (clip != default)
            {
                _soundSettings.player.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("#Audio# No audio clip with name " + soundName + " found in sound settings. Ignoring play operation.");
            }
        }

        protected AudioClip FindClip(string name)
        {
            foreach (var clip in _soundSettings.clips)
            {
                if (clip.name == name) return clip;
            }

            return default;
        }

        private int SelectNextSongIndex()
        {
            int index = -1;

            if (_musicSettings.songs.Length > 0) 
            {
                index = (_songIndex + 1) % _musicSettings.songs.Length;
            }

            return index;
        }

        private void PlayNextSong()
        {
            _songIndex = SelectNextSongIndex();

            if (_songIndex < 0) return;
            if (_songIndex >= _musicSettings.songs.Length) return;

            if (_musicSettings.songs.Length > 0)
            {
                CrossFadeToSong(_musicSettings.songs[_songIndex]);
            }
        }

        private void CrossFadeToSong(AudioClip song)
        {
            if (_musicSettings.player.isPlaying)
            {
                Debug.Log("#Audio# Music is already playing. Crossfading to play " + song.name);
                var sequence = DOTween.Sequence();

                sequence.Append(FadeOut(1f));
                sequence.AppendCallback(() =>
                {
                    PlaySong(song);
                });
                sequence.Append(FadeIn(1f));
                sequence.Play();
            }
            else
            {
                PlaySong(song);
            }
        }

        private void PlaySong(AudioClip song)
        {
            Debug.Log("#Audio# Playing " + song.name);

            float songDuration = song.length;

            _musicSettings.player.clip = song;
            _musicSettings.player.Play();
        }

        private async Task UpdateLoop()
        {
            if (_musicLoopStarted) return;

            _musicLoopStarted = true;

            while (true)
            {
                await Task.Delay(1000);

                if (!MusicIsMuted && !_musicSettings.player.isPlaying)
                {
                    OnSongFinished();
                }
            }
        }

        private void OnSongFinished()
        {
            PlayNextSong();
        }

        private Tween FadeIn(float duration)
        {
            float volume = 0f;
            float finalVolume = 1f;

            var tween = DOTween.To(() => volume,
                x =>
                {
                    MusicVolume = x;
                },
                finalVolume,
                duration);

            return tween;
        }

        private Tween FadeOut(float duration)
        {
            float volume = 1f;
            float finalVolume = 0f;

            var tween = DOTween.To(() => volume,
                x =>
                {
                    MusicVolume = x;
                },
                finalVolume,
                duration);

            return tween;
        }
        #endregion
    }
}