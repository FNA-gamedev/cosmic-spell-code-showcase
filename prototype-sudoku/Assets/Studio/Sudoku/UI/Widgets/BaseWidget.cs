using System;
using UnityEngine;

namespace Studio.Sudoku.UI.Widgets
{
    public abstract class BaseWidget : MonoBehaviour, IDisposable
    {
        #region Variables
        private bool _isSubscribedToEvents;
        #endregion

        #region Properties
        public float TimeElapsed { get; private set; }
        #endregion

        #region Methods
        public void Initialize()
        {
            TimeElapsed = 0f;

            InitializeInternal();

            SubscribeToEvents();
        }

        public void Dispose()
        {
            UnSubscribeToEvents();
        }

        public void SubscribeToEvents()
        {
            if (_isSubscribedToEvents)
            {
                UnSubscribeToEvents();
            }

            SubscribeToEventsInternal();

            _isSubscribedToEvents = true;
        }

        public void UnSubscribeToEvents()
        {
            if (_isSubscribedToEvents == false) return;

            UnSubscribeToEventsInternal();
        }

        public void Tick(float deltaTime)
        {
            TimeElapsed += deltaTime;

            TickInternal(deltaTime);
        }

        protected abstract void InitializeInternal();
        protected abstract void DisposeInternal();
        protected abstract void SubscribeToEventsInternal();
        protected abstract void UnSubscribeToEventsInternal();

        protected virtual void TickInternal(float deltaTime)
        {

        }
        #endregion
    }
}
