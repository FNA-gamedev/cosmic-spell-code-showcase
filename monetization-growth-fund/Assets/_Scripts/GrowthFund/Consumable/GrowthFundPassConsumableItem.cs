using _Scripts.GrowthFund._Shared.Consumables;
using Zenject;

namespace _Scripts.GrowthFund.Consumable
{
    public class GrowthFundPassConsumableItem : IConsumableItem
    {
        public class Factory : PlaceholderFactory<int, GrowthFundPassConsumableItem>
        {
        }
        
        public int Id { get; }
        public IConsumable Consumable { get; }
        public bool CanBeBoughtInItemShop { get; }
        public double Costs => 0;

        public GrowthFundPassConsumableItem(int id, GrowthFundPassConsumable.Factory growthFundPassConsumableFactory)
        {
            Id = id;
            Consumable = growthFundPassConsumableFactory.Create(id);
            CanBeBoughtInItemShop = true;
        }
        public void Buy(string transactionId = null)
        {
            Consumable.Receive(ConsumableContext.Unused);
        }
    }
}