using System;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Studio.Utils.ExtensionMethods
{
	public static class IntExtensions
	{
		#region Variables
		private static NumberFormatInfo _nfi;

		delegate bool OnProcessTimeUnit(StringBuilder stringBuilder, int time, TIME_UNIT timeUnit);
		#endregion

		#region Constructor
		static IntExtensions()
		{
			_nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
			_nfi.NumberGroupSeparator = " ";
		}
		#endregion

		#region Methods
		public static CultureInfo GetCurrentCultureInfo()
        {
            SystemLanguage currentLanguage = Application.systemLanguage;
            CultureInfo correspondingCultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(x => x.EnglishName.Equals(currentLanguage.ToString()));
            
			if (correspondingCultureInfo != default)
            {
                return CultureInfo.CreateSpecificCulture(correspondingCultureInfo.TwoLetterISOLanguageName);
            }

            return CultureInfo.CurrentCulture;
        }

		/** Converts a value to a culture specific separated string.
		 *  For example, `1000` could be converted to `1.000`.
		 *	@param format Serialization format */
		public static string ToDotSeparated(this int value, string format = "N0")
		{
			string text = value.ToString(format, CultureInfo.CurrentCulture);
			return text;
		}

		/** Converts a value to a space separated string.
		 *  For example, `1000` could be converted to `1 000`.
		 * 	@param format Serialization format */
		public static string ToSpaceSeparated(this int value, string format = "#,0")
		{
			string text = value.ToString(format, _nfi);
			return text;
		}

		/** Returns the time received in seconds serialized in cronometer style (1:30) */
		public static string ToCronometer(this int value, TIME_UNIT lowestTimeUnit = TIME_UNIT.SECOND, TIME_UNIT highestTimeUnit = TIME_UNIT.MINUTE)
		{
			return ProcessTime(	value, 
								-1, 
								lowestTimeUnit, 
								highestTimeUnit, 
								(stringBuilder, time, timeUnit) =>
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(":");
										stringBuilder.Append(time.ToString("00"));
									}
									else
									{
										stringBuilder.Append(time.ToString("#0"));
									}

									return true;
								});
		}

		/** Returns the time received in seconds serialized (e.g. 1d 30m 1s) with the maximum number of time units given (-1 is infinite) */
		public static string ToShortReadableTime(this int value, int maxTimeUnits = -1, TIME_UNIT lowestTimeUnit = TIME_UNIT.SECOND, TIME_UNIT highestTimeUnit = TIME_UNIT.DAY)
		{
			return ProcessTime(	value, 
								maxTimeUnits, 
								lowestTimeUnit, 
								highestTimeUnit, 
								(stringBuilder, time, timeUnit) =>
								{
									if (time <= 0 && (timeUnit != lowestTimeUnit || stringBuilder.Length > 0))
									{
										return false;
									}

									string timeUnitStr = TimeExtensionsUtil.GetTimeUnitShortName(time, timeUnit);
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(" ");
									}

									stringBuilder.Append(time + timeUnitStr);
									return true;
								});
		}

		/** Returns the time received in seconds serialized (e.g. 1d 30m 1s) with the maximum number of time units given (-1 is infinite) */
		public static string ToLongReadableTime(this int value, int maxTimeUnits = -1, TIME_UNIT lowestTimeUnit = TIME_UNIT.SECOND, TIME_UNIT highestTimeUnit = TIME_UNIT.DAY)
		{
			return ProcessTime(	value, 
								maxTimeUnits, 
								lowestTimeUnit, 
								highestTimeUnit, 
								(stringBuilder, time, timeUnit) =>
								{
									if (time <= 0 && (timeUnit != lowestTimeUnit || stringBuilder.Length > 0))
									{
										return false;
									}

									string timeUnitStr = TimeExtensionsUtil.GetTimeUnitLongName(time, timeUnit);
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(" ");
									}

									stringBuilder.Append(time + timeUnitStr);
									return true;
								});
		}

		static string ProcessTime(int value, int maxTimeUnits, TIME_UNIT lowestTimeUnit, TIME_UNIT highestTimeUnit, OnProcessTimeUnit processTimeUnitCallback)
		{
			int size = ((int)highestTimeUnit - (int)lowestTimeUnit + 1) * 3;
			StringBuilder stringBuilder = new StringBuilder(size);

			int totalTimeUnits = 0;
			int time = value;

			for (int i = (int)highestTimeUnit; i >= (int)lowestTimeUnit; --i)
			{
				TIME_UNIT timeUnit = (TIME_UNIT)i;

				int timeUnitDuration = TimeExtensionsUtil.GetTimeUnitDuration(timeUnit);
				int timeUnitsLapsed = time / timeUnitDuration;
				time -= timeUnitsLapsed * timeUnitDuration;
				bool timeUnitAdded = processTimeUnitCallback(stringBuilder, timeUnitsLapsed, timeUnit);
				
				if (timeUnitAdded)
				{
					totalTimeUnits++;

					if (maxTimeUnits >= 0 && totalTimeUnits >= maxTimeUnits)
					{
						break;
					}
				}
			}

			return stringBuilder.ToString();
		}
		#endregion
	}
}