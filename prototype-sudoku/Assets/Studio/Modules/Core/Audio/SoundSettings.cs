using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Studio.Modules.Core.Audio
{
    [Serializable]
    public class SoundSettings
    {
		#region Variables
		public AudioMixerGroup mixer;
        public AudioSource player;
        public AudioClip[] clips;
		#endregion
	}
}
