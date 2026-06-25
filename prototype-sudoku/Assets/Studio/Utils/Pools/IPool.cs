using System;

namespace Studio.Utils.Pools
{
    public interface IPool<T> : IDisposable
    {
		#region Methods
		T Spawn();
		void Despawn(T element);
		#endregion
	}
}
