namespace Studio.Modules.Core.Systems
{
    public class ScoreSystem
    {
		#region Variables
		protected int _lives;
		protected float _timeElapsed;
		protected bool _timerActive;
		#endregion

		#region Properties
		public int Lives { get { return _lives; } }
		public bool IsPlayerDead { get { return _lives <= 0; } }
		public float TimePlaying { get { return _timeElapsed; } }
		#endregion

		#region Methods
		public void Initialize() 
		{

		}

		public void Tick(float deltaTime)
		{
			if (_timerActive) 
			{
				_timeElapsed += deltaTime;
			}
		}

		public void Dispose() 
		{

		}

		public void InitScoring(int lives, float timePlaying) 
		{
			_lives = lives;
			_timeElapsed = timePlaying;
			_timerActive = true;
		}

		public void OnPlayerFail() 
		{
			_lives--;

			if (IsPlayerDead) SetTimerState(false);
		}

		public void SetTimerState(bool active) 
		{
			_timerActive = active;
		}
		#endregion
	}
}

