using System;
using System.Collections.Generic;

namespace _Scripts.GrowthFund._Shared.Consumables
{
    public interface IConsumableItemModelPool : IDisposable
    {
        IEnumerable<IConsumableItem> ConsumableItems { get; }

        void Add(IConsumableItem item);
        void AddRange(IEnumerable<IConsumableItem> items);

        bool ConsumableExists(int id);
        IConsumableItem GetConsumableItem(int id);
        IEnumerable<IConsumable> GetAllConsumables();
        List<IConsumablePackage> GetConsumablePackages(int iapProductId);
        List<IConsumablePackage> GetConsumablePackages(IDictionary<int, int> packages);
        IEnumerable<TConsumable> GetAllConsumablesByType<TConsumable>(ConsumableType consumableType)
            where TConsumable : IConsumable;
    }
}