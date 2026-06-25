namespace _Scripts.GrowthFund._Shared.Consumables
{
    public interface IConsumablePackage
    {
        int Amount { get; }
        IConsumable Consumable { get; }
        int DisplayAmount { get; }
        void Receive(ConsumableContext context);
    }
}