using UniRx;

namespace _Scripts.GrowthFund._Shared.Consumables
{
    public interface IConsumable : IConsumableData
    {
        void Activate(ConsumableContext context);
        void Receive(ConsumableContext context);
        void ReceiveMultiple(int amount, ConsumableContext context);
        bool IsDaily { get; }
    }

    public interface IActivateMultipleConsumable
    {
        void ActivateMultiple(int amount, ConsumableContext context);
    }

    public interface IConsumableData
    {
        ConsumableType Type { get; }
        ReactiveProperty<int> StoredAmount { get; }
        int Id { get; }
    }
}