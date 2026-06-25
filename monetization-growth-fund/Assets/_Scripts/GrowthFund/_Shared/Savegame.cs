using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.GrowthFund._Shared.Utility;
using _Scripts.GrowthFund.Persistence;
using UnityEngine;

namespace _Scripts.GrowthFund._Shared
{
    [Serializable]
    public class Savegame
    {
        [JsonPath("/")]
        public string Id;

        [JsonPath("/Data")]
        public List<MineSavegame> Mines;

        [JsonPath("/")]
        public int Version;
        
        [JsonPath("/Data")] public GrowthFundSavegame GrowthFundsSavegame;

        private static Guid _prefSavegameId = Guid.Empty;
        private static string _lastSaveVersion = null;

        public static Guid PrefSavegameId
        {
            get
            {
            
                return _prefSavegameId;
            }
            set
            {
                if (PrefSavegameId == value)
                    return;

                _prefSavegameId = value;
            }
        }

        public static string LastSaveVersion
        {
            get
            {
                return _lastSaveVersion;
            }
            set
            {
                if (_lastSaveVersion == value)
                    return;
                
                _lastSaveVersion = value;
            }
        }

        public override string ToString()
        {
            return string.Format("_savegame (Id: {0}, Mines: {1})", Id, string.Join(",", Mines.Select(p => p.ToString()).ToArray()));
        }

        public Savegame()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Savegame(Guid id, List<MineSavegame> mines, GrowthFundSavegame growthFundsSavegame)
            : this()
        {
            if (id == Guid.Empty)
            {
                //This should never happen, but we need a fallback
                Debug.LogException(new ArgumentException("worker must not be empty", "id"));
            }

            Id = id.ToString();
            PrefSavegameId = id;
            Mines = mines;
            GrowthFundsSavegame = growthFundsSavegame;
        }
    }
}