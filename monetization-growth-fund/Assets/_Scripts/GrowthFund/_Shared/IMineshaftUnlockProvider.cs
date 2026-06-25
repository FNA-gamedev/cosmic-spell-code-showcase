using UniRx;

namespace _Scripts.GrowthFund._Shared
{
    public interface IMineshaftUnlockProvider
    {
        IReadOnlyReactiveProperty<bool> GetMineshaftUnlockedReactiveProperty(int mineId, int mineshaftId);
    }
}