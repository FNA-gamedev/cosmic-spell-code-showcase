using Zenject;
namespace _Scripts.GrowthFund._Shared.Consumables
{
    public class ConsumablePackage : IConsumablePackage
    {
        public interface IFactory : IFactory<int, IConsumable, IConsumablePackage>
        { }
        
        public int Amount { get; }
        public IConsumable Consumable { get; }

        public ConsumablePackage(int amount, IConsumable consumable)
        {
            Amount = amount;
            Consumable = consumable;
        }
        
        public int DisplayAmount => Amount * SpecificAmountForConsumableType;

        private int SpecificAmountForConsumableType
        {
            get
            {
                switch (Consumable)
                {
                    default:
                        return 1;
                }
            }
        }

        public void Receive(ConsumableContext context)
        {
            Consumable.ReceiveMultiple(Amount, context);
        }
    }
}