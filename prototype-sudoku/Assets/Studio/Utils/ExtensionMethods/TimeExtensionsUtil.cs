using System;
using System.Diagnostics;

namespace Studio.Utils.ExtensionMethods
{
	public enum TIME_UNIT
	{
		SECOND = 0,
		MINUTE,
		HOUR,
		DAY,
		MAX_TIME_UNIT
	}

	public static class TimeExtensionsUtil
	{
		#region Variables
		/** Time units short name localization keys */
		static string[] _timeUnitShortNames = new string[] { "s", "m", "h", "d" };
		/** Time units long name localization keys */
		static string[] _timeUnitLongNameKeys = new string[] { "second", "minute", "hour",  "day" };
		/** Time units durations in seconds */
		static int[] _timeUnitDurations = new int[] { 1, 60, 3600, 86400 };
		#endregion

		#region Methods
		public static double GetTotalTimeLapsed(TimeSpan timeSpan, TIME_UNIT timeUnit)
		{
			double timeLapsed;

			switch (timeUnit)
			{
				case TIME_UNIT.DAY:
					timeLapsed = timeSpan.TotalDays;
					break;
				case TIME_UNIT.HOUR:
					timeLapsed = timeSpan.TotalHours;
					break;
				case TIME_UNIT.MINUTE:
					timeLapsed = timeSpan.TotalMinutes;
					break;
				case TIME_UNIT.SECOND:
					timeLapsed = timeSpan.TotalSeconds;
					break;
				default:
					Debug.Assert(false, "GetTimeLapsed in TimeSpanExtensions is not implemented for the time unit " + timeUnit);
					timeLapsed = 0;
					break;
			}

			return timeLapsed;
		}

		public static int GetTimeLapsed(TimeSpan timeSpan, TIME_UNIT timeUnit)
		{
			int timeLapsed;
			switch (timeUnit)
			{
				case TIME_UNIT.DAY:
					timeLapsed = timeSpan.Days;
					break;
				case TIME_UNIT.HOUR:
					timeLapsed = timeSpan.Hours;
					break;
				case TIME_UNIT.MINUTE:
					timeLapsed = timeSpan.Minutes;
					break;
				case TIME_UNIT.SECOND:
					timeLapsed = timeSpan.Seconds;
					break;
				default:
					Debug.Assert(false, "GetTimeLapsed in TimeSpanExtensions is not implemented for the time unit " + timeUnit);
					timeLapsed = 0;
					break;
			}

			return timeLapsed;
		}

		public static int GetTimeUnitDuration(TIME_UNIT timeUnit)
		{
			int timeUnitIndex = (int)timeUnit;
			int duration = _timeUnitDurations[timeUnitIndex];

			return duration;
		}

		public static string GetTimeUnitShortName(int timeLapsed, TIME_UNIT timeUnit)
		{
			int timeUnitIndex = (int)timeUnit;
			string text = _timeUnitShortNames[timeUnitIndex];

			return text;
		}

		public static string GetTimeUnitLongName(int timeLapsed, TIME_UNIT timeUnit)
		{
			int timeUnitIndex = (int)timeUnit;
			string text = _timeUnitLongNameKeys[timeUnitIndex];

			if (timeLapsed != 1)
			{
				text += "s";
			}

			return text;
		}
		#endregion
	}
}