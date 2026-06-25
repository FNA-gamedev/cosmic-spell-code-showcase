using DG.Tweening;
using Studio.Modules.Core.Audio;
using Studio.Utils.CustomInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Studio.Sudoku.UI.Buttons
{
    public class BaseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region Injection
        [Inject] protected AudioService _audioService;
		#endregion

		#region Variables
		[SerializeField] private Image _background;
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Sprite _disabledSprite;
        [SerializeField] private bool _shouldAnimateWithScale = true;

        [Header("Optional")]
        [SerializeField] private ParticleSystem _onClickedFx;
        [SerializeField] private bool _useCustomSound;
        [SerializeField, ConditionalHide("_useCustomSound"),] private string _soundName;
        [SerializeField] private bool _disableScrollWhenTouched = true;

        [HideInInspector] public Button.ButtonClickedEvent onClick;
        [HideInInspector] public Button.ButtonClickedEvent onClickReleased;

        protected bool _isInitialized;
        protected bool _isInteractable;
        protected Color _originalColor;
        protected float _lastFxTime;
        protected bool _isDragging;

        private const string DEFAULT_BUTTON_CLICK_SOUND_NAME = "ui_button_click";
        #endregion

        #region Properties
        public bool interactable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                if (_background != default) _background.sprite = value ? _enabledSprite : _disabledSprite;
            }
        }

        public float TimeLastClick { get; private set; }
        public bool IsPressedDown { get; protected set; }
        public bool IsPointerInside { get; protected set; }
        protected CanvasGroup ParentCanvas { get; set; }
        protected ScrollRect ParentScroll { get; set; }
        protected bool IsHorizontalScroll { get; set; }
        protected bool IsVerticalScroll { get; set; }
        protected bool IsParentCanvasInteractable
        {
            get
            {
                if (ParentCanvas != default)
                {
                    return ParentCanvas.interactable;
                }
                return true;
            }
        }
        #endregion

        #region Methods
        protected void Start()
        {
            Initialize();
        }

        protected void OnDisable()
        {
            if (IsPressedDown)
            {
                // Simulate a pointer release before disabling
                OnPointerUp(default);
            }
        }

		protected void OnDestroy()
		{
            Dispose();
		}

		public virtual void Initialize()
        {
            if (_isInitialized) return;

            _originalColor = (_background != default) ? _background.color : Color.clear;
            ParentCanvas = GetComponentInParent<CanvasGroup>();
            ParentScroll = GetComponentInParent<ScrollRect>();

            if (ParentScroll != default)
            {
                IsHorizontalScroll = ParentScroll.horizontal;
                IsVerticalScroll = ParentScroll.vertical;
            }

            interactable = true;
            _isInitialized = true;
        }

        public virtual void Dispose() 
        { 
        
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            eventData.Use();

            if (interactable == false) return;

            if (IsPressedDown) return;

            StartClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            eventData.Use();
            IsPointerInside = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            eventData.Use();
            IsPointerInside = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            eventData?.Use();

            if (interactable == false || eventData == default) return;

            _isDragging = eventData.dragging;
            ReleaseClick();
        }

        public virtual void ChangeBackgroundColor(Color color)
        {
            _originalColor = color;
            if (_background != default) _background.color = color;
        }

        protected virtual void StartClick()
        {
            IsPressedDown = true;

            if (_disableScrollWhenTouched)
                DisableParentScroll();

            ShowClickDownAnimation();
        }

        protected virtual void ReleaseClick()
        {
            IsPressedDown = false;

            ShowClickReleasedAnimation();

            if (_isDragging) return;

            OnClickDetected();

            if (_disableScrollWhenTouched)
                EnableParentScroll();
        }

        protected void ShowClickDownAnimation(float duration = 0.2f)
        {
            transform.DOKill();

            if (_shouldAnimateWithScale)
            {
                transform.DOScale(0.9f, duration).SetEase(Ease.OutQuad);
            }

            if (_background != default) 
            {
                Color color = Color.Lerp(_originalColor, Color.black, 0.25f);
                _background.DOColor(color, duration).SetEase(Ease.OutQuad);
            }
        }

        protected void ShowClickReleasedAnimation(float duration = 0.2f)
        {
            transform.DOKill();

            if (_shouldAnimateWithScale)
            {
                transform.DOScale(1.0f, duration).SetEase(Ease.OutBack);
            }

            if (_background != default) 
            {
                _background.DOColor(_originalColor, duration).SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    onClickReleased.Invoke();
                });
            }
        }

        protected virtual void ShowClickAnimation()
        {
            ShowClickFxFeedback();
        }

        protected void ShowClickFxFeedback()
        {
            if (_onClickedFx != default)
            {
                _onClickedFx.Play();
            }

            if (_useCustomSound)
            {
                _audioService.PlaySound(_soundName);
            }
            else
            {
                _audioService.PlaySound(DEFAULT_BUTTON_CLICK_SOUND_NAME);
            }
        }

        protected virtual void OnClickDetected()
        {
            if (!interactable) return;

            ShowClickAnimation();

            onClick.Invoke();

            TimeLastClick = Time.time;
        }

        protected void EnableParentScroll()
        {
            if (ParentScroll == default) return;

            ParentScroll.enabled = true;
        }

        protected void DisableParentScroll()
        {
            if (ParentScroll == default) return;

            ParentScroll.enabled = false;
        }
        #endregion
    }
}
