using System.Collections.Generic;
using _Scripts.GrowthFund._Shared.Consumables;

namespace _Scripts.GrowthFund._Shared.Analytics
{
    public interface ITransactionDataGenerator
    {
        IEnumerable<ITransactionData> ConsumablesToTransactionData(IEnumerable<IConsumable> consumables);

        IEnumerable<ITransactionData> ConsumablePackagesToTransactionData(IEnumerable<IConsumablePackage> consumablePackages);
        ITransactionData ConsumableToTransactionData(IConsumable consumable);
        ITransactionData ConsumableToTransactionData(IConsumable consumable, int consumableAmount);
    }
}