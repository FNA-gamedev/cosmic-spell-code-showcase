using System;

namespace _Scripts.GrowthFund._Shared.Utility
{
    public interface IEventBus
    {
        IObservable<T> OnEvent<T>();
        void Publish<T>(T evt);
    }
}