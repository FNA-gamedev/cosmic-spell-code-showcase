using System;

namespace Studio.Utils.ExtensionMethods
{
	public static class TimeSpanExtensions
	{
		#region Methods
		/** Returns the time received in seconds serialized in cronometer style (1:30) */
		public static string ToCronometer(this TimeSpan value, TIME_UNIT lowestTimeUnit = TIME_UNIT.SECOND, TIME_UNIT highestTimeUnit = TIME_UNIT.MINUTE)
		{
			int floorValue = (int)Math.Floor(value.TotalSeconds);
			return floorValue.ToCronometer(lowestTimeUnit, highestTimeUnit);
		}

		/** Returns the time received in seconds serialized (e.g. 1d 30m 1s) with the maximum number of time units given (-1 is infinite) */
		public static string ToShortReadableTime(this TimeSpan value, int maxTimeUnits = -1, TIME_UNIT lowestTimeUnit = TIME_UNIT.SECOND, TIME_UNIT highestTimeUnit = TIME_UNIT.DAY)
		{
			int floorValue = (int)Math.Floor(value.TotalSeconds);
			return floorValue.ToShortReadableTime(maxTimeUnits, lowestTimeUnit, highestTimeUnit);
		}

		/** Returns the time received in seconds serialized (e.g. 1d 30m 1s) with the maximum number of time units given (-1 is infinite) */
		public static string ToLongReadableTime(this TimeSpan value, int maxTimeUnits = -1, TIME_UNIT lowestTimeUnit = TIME_UNIT.SECOND, TIME_UNIT highestTimeUnit = TIME_UNIT.DAY)
		{
			int floorValue = (int)Math.Floor(value.TotalSeconds);
			return floorValue.ToLongReadableTime(maxTimeUnits, lowestTimeUnit, highestTimeUnit);
		}
		#endregion
	}
}