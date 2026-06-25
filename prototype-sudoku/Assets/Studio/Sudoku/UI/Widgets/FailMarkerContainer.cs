using Studio.Sudoku.Systems;
using Studio.Utils.Pools;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Studio.Sudoku.UI.Widgets
{
	public class FailMarkerContainer : BaseWidget
	{
		#region Injection
		[Inject] protected DiContainer _zenject;
		[Inject] protected GameplaySystem _gameplaySystem;
		#endregion

		#region Variables
		[SerializeField] private RectTransform _failMarkerWidgetsParent;
		[SerializeField] private FailMarkerWidget _failMarkerWidgetsSource;

		protected bool _initialized;
		protected InternalPool<FailMarkerWidget> _failMarkerWidgetsPool;
		protected List<FailMarkerWidget> _failMarkers;
		#endregion

		#region Methods
		protected override void InitializeInternal()
		{
			if (_initialized) return;

			_failMarkerWidgetsPool = new InternalPool<FailMarkerWidget>(_failMarkerWidgetsSource, _failMarkerWidgetsParent, 3, _zenject);
			_failMarkers = new List<FailMarkerWidget>();

			CreateMarkers();

			_initialized = true;
		}

		protected override void DisposeInternal()
		{
			DisposeMarkers();

			_initialized = false;
		}

		protected override void SubscribeToEventsInternal()
		{

		}

		protected override void UnSubscribeToEventsInternal()
		{

		}

		public bool OnPlayerFail() 
		{
			int currentFailures = 0;
			int maxFailuresAllowed = _failMarkers.Count;

			foreach (FailMarkerWidget marker in _failMarkers)
			{
				if (marker.Active)
				{
					currentFailures++;
				}
				else 
				{
					marker.SetState(true);
					currentFailures++;
					break;
				}
			}

			return currentFailures >= maxFailuresAllowed;
		}

		private void CreateMarkers() 
		{
			_failMarkers.Clear();
			int failuresAllowed = _gameplaySystem.GetMaximumFailuresAllowed();

			for (int i = 0; i < failuresAllowed; ++i)
			{
				FailMarkerWidget marker = _failMarkerWidgetsPool.Spawn();
				marker.Initialize();

				_failMarkers.Add(marker);
			}
		}

		private void DisposeMarkers()
		{
			foreach (FailMarkerWidget marker in _failMarkers)
			{
				marker.Dispose();
				_failMarkerWidgetsPool.Despawn(marker);
			}

			_failMarkers.Clear();
		}
		#endregion
	}
}