using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Studio.Utils.ExtensionMethods
{
	public static class StringExtensions
	{
		#region Methods
		/// <summary>
		///     Converts a string to a dash separated string.
		///     For example, `DoSomething` and `Do Something` will be converted to `Do_Something`.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToDashSeparated(this string text)
		{
			var finalText = new StringBuilder();
			finalText.Append(text[0]);

			for (int i = 1; i < text.Length - 1; ++i)
			{
				char character = text[i];
				char previousCharacter = text[i - 1];

				if (char.IsUpper(character) && char.IsLower(previousCharacter) || char.IsWhiteSpace(character))
				{
					finalText.Append("_");
				}
				if (!char.IsWhiteSpace(character))
				{
					finalText.Append(character);
				}
			}

			finalText.Append(text[text.Length - 1]);

			return finalText.ToString();
		}

		/// <summary>
		/// Converts the string to the corresponding enum value, or returns the default value if not possible.
		/// </summary>
		public static T ToEnum<T>(this string strEnumValue, T defaultValue = default(T))
		{
			if (strEnumValue == default) return defaultValue;

			if (Enum.IsDefined(typeof(T), strEnumValue)) return (T)Enum.Parse(typeof(T), strEnumValue, true);
			if (Enum.IsDefined(typeof(T), strEnumValue.ToUpper())) return (T)Enum.Parse(typeof(T), strEnumValue.ToUpper(), true);
			if (Enum.IsDefined(typeof(T), strEnumValue.ToLower())) return (T)Enum.Parse(typeof(T), strEnumValue.ToLower(), true);

			return defaultValue;
		}

		public static string ToCamelCase(this string s)
		{
			string[] groups = s.Split('_');
			string result = string.Empty;

			if (groups.Length == 0) return string.Empty;

			foreach (string group in groups)
			{
				result += Regex.Replace(group,
										"([A-Z])([A-Z]+)($|[A-Z])",
										m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
			}

			return char.ToLower(result[0]) + result.Substring(1);
		}

		public static string ToPascalCase(this string s)
		{
			string result = s.ToCamelCase();
			return char.ToUpper(result[0]) + result.Substring(1);
		}
		#endregion
	}
}