namespace _Scripts.GrowthFund._Shared.Consumables
{
    public interface IConsumableItem
    {
        IConsumable Consumable { get; }

        bool CanBeBoughtInItemShop { get; }
        double Costs { get; }
    }
}