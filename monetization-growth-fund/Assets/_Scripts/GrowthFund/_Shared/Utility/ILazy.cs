namespace _Scripts.GrowthFund._Shared.Utility
{
    public interface ILazy<out T>
    {
        T Value { get; }
        T Initialize();
    }
}