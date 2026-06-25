using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Studio.Utils.Pools
{
    public class InternalPool<T> : IPool<T> where T : MonoBehaviour
    {
        #region Definitions
        private class PooledObject
        {
            public T sceneObject;
            public bool isUsed;

            public PooledObject(T sceneObject)
            {
                this.sceneObject = sceneObject;
                this.isUsed = false;
            }
        }
        #endregion

        #region Variables
        private readonly T _prefab;
        private readonly Transform _container;
        private readonly List<PooledObject> _pooledObjects;
        private readonly DiContainer _zenject;
        #endregion

        #region Properties
        public int Size => _pooledObjects.Count;
        #endregion

        #region Constructor
        public InternalPool(T prefab, Transform container, int initialSize, DiContainer zenject)
        {
            _prefab = prefab;
            _container = container;
            _pooledObjects = new List<PooledObject>(initialSize);
            _zenject = zenject;

            T[] children;

            children = container.GetComponentsInChildren<T>(true);

            foreach (var child in children)
            {
                Register(child);
            }

            for (int i = Size; i < initialSize; i++)
            {
                Expand();
            }
        }
        #endregion

        #region Methods
        public T Spawn()
        {
            PooledObject pooledObject;

            pooledObject = FindAvailable();

            if (IsValid(pooledObject) == false)
            {
                pooledObject = Expand();
            }

            pooledObject.isUsed = true;

            if (!pooledObject.sceneObject.gameObject.activeSelf)
            {
                pooledObject.sceneObject.gameObject.SetActive(true);
            }

            return pooledObject.sceneObject;
        }

        public void Despawn(T sceneObject)
        {
            PooledObject pooledObject;

            pooledObject = Find(sceneObject);

            if (IsValid(pooledObject))
            {
                pooledObject.isUsed = false;
                pooledObject.sceneObject.transform.SetParent(_container);

                if (pooledObject.sceneObject.gameObject.activeSelf)
                {
                    pooledObject.sceneObject.gameObject.SetActive(false);
                }
            }
        }

        public void Dispose()
        {
            foreach (var pooledObject in _pooledObjects)
            {
                GameObject.DestroyImmediate(pooledObject.sceneObject.gameObject);
            }

            _pooledObjects.Clear();
        }

        private PooledObject Expand()
        {
            T sceneObject;
            PooledObject pooledObject;

            sceneObject = GameObject.Instantiate<T>(_prefab, _container);
            pooledObject = Register(sceneObject);

            return pooledObject;
        }

        private PooledObject Register(T sceneObject)
        {
            PooledObject pooledObject;

            pooledObject = new PooledObject(sceneObject);

            _zenject.InjectGameObject(pooledObject.sceneObject.gameObject);
            pooledObject.sceneObject.gameObject.SetActive(false);

            _pooledObjects.Add(pooledObject);

            return pooledObject;
        }

        private PooledObject FindAvailable()
        {
            foreach (var pooledObject in _pooledObjects)
            {
                if (pooledObject.isUsed == false) return pooledObject;
            }

            return default;
        }

        private PooledObject Find(T sceneObject)
        {
            foreach (var pooledObject in _pooledObjects)
            {
                if (pooledObject.sceneObject == sceneObject) return pooledObject;
            }

            return default;
        }

        private bool IsValid(PooledObject pooledObject)
        {
            if (pooledObject == default) return false;
            if (pooledObject.sceneObject == default) return false;

            return true;
        }
        #endregion
    }
}
