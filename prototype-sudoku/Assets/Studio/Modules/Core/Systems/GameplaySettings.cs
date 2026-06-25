using System;
using UnityEngine;
using static Studio.Sudoku.Systems.Enums;

namespace Studio.Modules.Core.Systems
{
    public class GameplaySettings
    {
        #region Variables
        private eGameDifficulty _gameDifficulty = eGameDifficulty.NONE;
        private int _maxFailuresAllowed;
		#endregion

		#region Properties
        public int MaxFailures { get { return _maxFailuresAllowed; } }
		#endregion

		#region Methods
		public void SetGameDifficulty(eGameDifficulty mode)
        {
            _gameDifficulty = mode;
        }

        public void SetGameDifficulty(string mode)
        {
            eGameDifficulty gameMode;

            if (Enum.TryParse<eGameDifficulty>(mode, out eGameDifficulty modeEnum))
            {
                gameMode = modeEnum;
            }
            else
            {
                gameMode = eGameDifficulty.NONE;
            }

            SetGameDifficulty(gameMode);
        }

        public string GetGameDifficulty()
        {
            if (_gameDifficulty == eGameDifficulty.NONE)
            {
                Debug.LogError("Game mode is not set!");
                return default;
            }

            return _gameDifficulty.ToString();
        }

        public void SetMaxFailuresAmount(int amount)
        {
            _maxFailuresAllowed = amount;
        }
        #endregion
    }
}