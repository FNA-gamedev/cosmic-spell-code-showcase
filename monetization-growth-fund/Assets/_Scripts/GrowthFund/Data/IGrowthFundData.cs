using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;

namespace _Scripts.GrowthFund.Data
{
    public interface IGrowthFundData
    {
        int GrowthFundId { get; }
        List<GrowthFundMilestone> Milestones { get; set; }
        List<ConsumableDto> TotalRewards { get; set; }
        GrowthFundLocaData GrowthFundLocaData { get; set; }
        IGrowthFundGraphics GrowthFundGraphics { get; set; }
        GrowthFundColourPaletteData GrowthFundColourPalette { get; set; }
        int ValueFactor { get; }
        int BubblePriority { get; }
        bool DismissibleBubble { get; }
    }
}