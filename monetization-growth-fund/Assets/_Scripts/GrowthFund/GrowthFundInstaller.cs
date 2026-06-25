using _Scripts.GrowthFund.DataEvents;
using _Scripts.GrowthFund.Offer;
using _Scripts.GrowthFund.Progression;
using Zenject;

namespace _Scripts.GrowthFund
{
    public class GrowthFundInstaller : Installer<GrowthFundInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GrowthFundOfferModelProvider>().AsSingle();
            Container.BindInterfacesTo<GrowthFundProgressModelProvider>().AsSingle();
            Container.BindInterfacesTo<GrowthFundProgressionService>().AsSingle();
            Container.BindInterfacesTo<GrowthFundUnlockModel>().AsSingle();
            Container.BindInterfacesTo<GrowthFundEventDataService>().AsSingle();
        }
    }
}