using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Studio.Sudoku.UI.Menus
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class MenuController : MonoBehaviour, IMenuController
	{
        #region Variables
        [SerializeField] protected Button _closeButton;

        public MenuEvent onShow;
        public MenuEvent onHide;
        public MenuEvent onCloseButtonClicked;
        protected CanvasGroup _canvasGroup;
        protected Sequence _showSequence;
        protected Sequence _hideSequence;
        #endregion

        #region Properties
        public bool IsInitialized { get; private set; }
        public bool IsSubscribedToEvents { get; private set; }
        public bool IsVisible { get; private set; }
        #endregion

        #region Methods
        public void Initizalize()
        {
            if (IsInitialized) return;

            _canvasGroup = GetComponent<CanvasGroup>();

            InitializeInternal();
            SubscribeToEvents();

            IsVisible = gameObject.activeInHierarchy;
            IsInitialized = true;
        }

        public void Dispose() 
        {
            onShow.RemoveAllListeners();
            onHide.RemoveAllListeners();
            DisposeInternal();
            UnsubscribeToEvents();

            IsInitialized = false;
        }

        public void Tick(float deltaTime) 
        {
            if (IsVisible)
            {
                TickInternal(deltaTime);
            }
        }

        public void SubscribeToEvents() 
        {
            if (IsSubscribedToEvents)
            {
                UnsubscribeToEvents();
            }

            if (_closeButton != default)
            {
                _closeButton.onClick.AddListener(OnCloseButtonClicked);
            }

            SubscribeToEventsInternal();

            IsSubscribedToEvents = true;
        }

        public void UnsubscribeToEvents() 
        {
            if (IsSubscribedToEvents == false) return;

            UnSubscribeToEventsInternal();

            if (_closeButton != default)
            {
                _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            }

            IsSubscribedToEvents = false;
        }

        public Sequence Show() 
        {
            KillSequences();
            _showSequence = DOTween.Sequence();

            if (IsVisible)
            {
                _showSequence.AppendCallback(() =>
                {
                    Debug.LogWarning("#UI# Element " + name + " is already visible. Show operation ignored.");
                });
            }
            else
            {
                _showSequence.AppendCallback(() =>
                {
                    Debug.Log("#UI# Trying to show element " + name);

                    PreShow();

                    _canvasGroup.interactable = false;
                    _canvasGroup.blocksRaycasts = true;
                });

                _showSequence.Append(ShowInternal());
                _showSequence.AppendCallback(() =>
                {
                    Debug.Log("#UI# Element " + name + " finished showing.");

                    IsVisible = true;
                    _canvasGroup.interactable = true;

                    PostShow();

                    onShow.Invoke(this);
                });
            }

            return _showSequence;
        }

        public void ShowInstantly() 
        {
            KillSequences();
            PreShow();

            IsVisible = true;

            ShowInstantlyInternal();

            PostShow();
        }

        public Sequence Hide() 
        {
            KillSequences();
            _hideSequence = DOTween.Sequence();

            if (!IsVisible)
            {
                _hideSequence.AppendCallback(() =>
                {
                    Debug.LogWarning("#UI# Element " + name + " is already hidden. Hide operation ignored.");
                });
            }
            else
            {
                _hideSequence.AppendCallback(() =>
                {
                    Debug.Log("#UI# Trying to hide element " + name);

                    PreHide();

                    _canvasGroup.interactable = false;
                });

                _hideSequence.Append(HideInternal());
                _hideSequence.AppendCallback(() =>
                {
                    Debug.Log("#UI# Element " + name + " finished hidding.");

                    IsVisible = false;
                    _canvasGroup.interactable = true;
                    _canvasGroup.blocksRaycasts = false;

                    PostHide();

                    onHide.Invoke(this);
                });
            }

            return _hideSequence;
        }

        public void HideInstantly() 
        {
            KillSequences();
            PreHide();

            IsVisible = false;
            gameObject.SetActive(false);
            HideInstantlyInternal();

            PostHide();
        }

        protected void KillSequences()
        {
            if (_showSequence != default)
                _showSequence.Kill(true);
            if (_hideSequence != default)
                _hideSequence.Kill(true);
        }

        protected virtual void OnCloseButtonClicked()
        {
            onCloseButtonClicked.Invoke(this);
        }

        protected abstract void InitializeInternal();
        protected abstract void TickInternal(float deltaTime);
        protected abstract void DisposeInternal();
        protected abstract void SubscribeToEventsInternal();
        protected abstract void UnSubscribeToEventsInternal();

        protected virtual Sequence ShowInternal() 
        {
            Sequence showSequence = DOTween.Sequence();

            showSequence.AppendCallback(() =>
            {
                gameObject.SetActive(true);
                _canvasGroup.alpha = 1f;
            });

            return showSequence;
        }

        protected virtual Sequence HideInternal() 
        {
            Sequence hideSequence = DOTween.Sequence();

            hideSequence.AppendCallback(() =>
            {
                _canvasGroup.alpha = 0f;
                gameObject.SetActive(false);
            });

            return hideSequence;
        }

        protected virtual void ShowInstantlyInternal() 
        {
            _canvasGroup.alpha = 1f;
        }

        protected virtual void HideInstantlyInternal()
        {
            _canvasGroup.alpha = 0f;
        }

        protected virtual void PreShow() 
        { 
        
        }

        protected virtual void PostShow() 
        { 
        
        }

        protected virtual void PreHide() 
        { 
        
        }

        protected virtual void PostHide() 
        { 
        
        }
        #endregion
    }
}
