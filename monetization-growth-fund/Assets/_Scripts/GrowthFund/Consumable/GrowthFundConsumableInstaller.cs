using Zenject;

namespace _Scripts.GrowthFund.Consumable
{
    public class GrowthFundConsumableInstaller : Installer<GrowthFundConsumableInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<int, GrowthFundPassConsumableItem, GrowthFundPassConsumableItem.Factory>();
            Container.BindFactory<int, GrowthFundPassConsumable, GrowthFundPassConsumable.Factory>();
        }
    }
}