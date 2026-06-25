using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Studio.Utils.Pools
{
    public class PoolCollection<T> where T : MonoBehaviour
    {
        #region Variables
        private T[] _referencePrefabs;
        private Transform _poolContainerParent;
        private int _initialPoolSize;
        private DiContainer _zenject;

        private Dictionary<string, InternalPool<T>> _poolCollection;
        #endregion

        #region Constructor
        public PoolCollection(T[] references, Transform container, int initialSize, DiContainer zenject)
        {
            _referencePrefabs = references;
            _poolContainerParent = container;
            _initialPoolSize = initialSize;
            _zenject = zenject;
        }
        #endregion

        #region Methods
        public void Initialize() 
        {
            _poolCollection = new Dictionary<string, InternalPool<T>>();

            foreach (var reference in _referencePrefabs)
            {
                InternalPool<T> referencePool = new InternalPool<T>(reference, _poolContainerParent, _initialPoolSize, _zenject);
                _poolCollection.Add(reference.GetType().Name, referencePool);
            }
        }

        public void Dispose()
        {
            foreach (var referencePool in _poolCollection.Values)
            {
                referencePool.Dispose();
            }

            _poolCollection.Clear();
        }
        
        public InternalPool<T> GetReferencePool(string referenceName) 
        {
            return _poolCollection[referenceName];
        }

        public T SpawnFromReferencePool(string referenceName) 
        {
            InternalPool<T> referencePool = _poolCollection[referenceName];

            if (referencePool != default) return referencePool.Spawn();
            else return default;
        }

        public void DespawnFromReferencePool(T referenceObject)
        {
            string objectName = referenceObject.GetType().Name;
            InternalPool<T> referencePool = _poolCollection[objectName];
            if (referencePool != default) referencePool.Despawn(referenceObject);
        }
        #endregion
    }
}

