using System;
using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;
using UniRx;
using Zenject;

namespace _Scripts.GrowthFund.Consumable
{
    public class GrowthFundPassConsumable : IConsumable
    {
        public class Factory : PlaceholderFactory<int, GrowthFundPassConsumable>
        {
        }

        public ConsumableType Type => ConsumableType.GrowthFundPass;
        public ReactiveProperty<int> StoredAmount { get; }
        public bool IsDaily => false;
        public int Id { get; }
        public string Description => GrowthFundConstants.K_growthFundPassConsumable;

        public GrowthFundPassConsumable(int id, IDisposable disposer)
        {
            Id = id;
            StoredAmount = new ReactiveProperty<int>(0).AddTo(disposer as ICollection<IDisposable>);
        }

        public void Activate(ConsumableContext context)
        {
            Receive(context);
        }

        public void Receive(ConsumableContext context)
        {
            StoredAmount.Value++;
        }
        
        public void ReceiveMultiple(int amount, ConsumableContext context)
        {
            StoredAmount.Value += amount;
        }

        public void Setup() { }
    }
}