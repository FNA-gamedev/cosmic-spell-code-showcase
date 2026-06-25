using System;

namespace _Scripts.GrowthFund._Shared.Utility
{
    public static class Lazy
    {
        public static ILazy<T> From<T>(Func<T> func)
        {
            return new Lazy<T>(func);
        }

        public static ILazy<T> ToLazy<T>(this Func<T> func)
        {
            return new Lazy<T>(func);
        }
    }

    internal class Lazy<T> : ILazy<T>
    {
        private Func<T> _creationFunction;
        private bool _initialized;

        private T _value;
        public T Value
        {
            get
            {
                return _initialized ? _value : Initialize();
            }
        }

        public Lazy(Func<T> creationFunction)
        {
            _creationFunction = creationFunction;
        }

        public T Initialize()
        {
            if (_initialized)
                return _value;
            var value = _creationFunction();
            _creationFunction = null;
            _initialized = true;
            return _value = value;
        }
    }
}