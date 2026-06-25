using System;

namespace _Scripts.GrowthFund._Shared.Analytics
{
    public interface IAnalyticsBus
    {
        void Publish(IDataPlatformPayload payload);
        void Publish(string eventName);
        
        IObservable<T> OnEvent<T>() where T : class, IDataPlatformPayload;
    }
}