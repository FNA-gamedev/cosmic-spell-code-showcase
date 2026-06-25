using System;

namespace _Scripts.GrowthFund._Shared
{
    [Serializable]
    public class MineSavegame
    {
        public int MineNumber;
        public int PrestigeCount;
        public bool Selected;
        
        public MineSavegame(int mineNumber, bool selected)
        {
            MineNumber = mineNumber;
            Selected = selected;
            PrestigeCount = 0;
        }
        
        public MineSavegame() { }

        public override string ToString()
        {
            return $"MineSavegame( MineNumber: {MineNumber}, PrestigeCount: {PrestigeCount}, Selected: {Selected})";
        }
    }
}