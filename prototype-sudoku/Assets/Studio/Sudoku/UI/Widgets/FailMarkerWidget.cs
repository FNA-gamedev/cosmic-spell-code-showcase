using System;
using UnityEngine;

namespace Studio.Sudoku.UI.Widgets
{
	public class FailMarkerWidget : BaseWidget
	{
		#region Variables
		[SerializeField] private CanvasGroup _activeState;
		[SerializeField] private CanvasGroup _inactiveState;

		private bool _isActive;
		#endregion

		#region Properties
		public bool Active { get { return _isActive; } }
		#endregion

		#region Methods
		protected override void InitializeInternal()
		{
			SetState(false);
		}

		protected override void DisposeInternal()
		{
			SetState(false);
		}

		protected override void SubscribeToEventsInternal()
		{

		}

		protected override void UnSubscribeToEventsInternal()
		{

		}

		public void SetState(bool active) 
		{
			_isActive = active;
			_activeState.alpha = Convert.ToInt32(Active);
			_inactiveState.alpha = Convert.ToInt32(!Active);
		}
		#endregion
	}
}