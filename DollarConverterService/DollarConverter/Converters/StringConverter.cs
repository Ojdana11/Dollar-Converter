using DollarConverter.Common;
using DollarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Converters
{
	public class StringConverter : IStringConverter
	{
		private IEnumTranslator enumTranslator;
		public StringConverter(IEnumTranslator enumTranslator)
		{
			this.enumTranslator = enumTranslator;
		}
		public string ConvertDecimalAndUnity(string decimalAndUnity, string end, bool withS = false)
		{
			decimalAndUnity = decimalAndUnity.Replace(" ", string.Empty);
			if(decimalAndUnity.Length > 2)
			{
				return string.Empty;
			}
			var result = new StringBuilder();
			if(Int32.TryParse(decimalAndUnity, out int asNumber))
			{
				if (Enum.IsDefined(typeof(NumberInWords), asNumber))
				{
					result.Append(this.enumTranslator.Get<NumberInWords>(asNumber));
					result.Append(" ");
					result.Append(end);

					if (asNumber != 1 && withS)
					{
						result.Append("s");
					}
					result.Append(" ");
					return result.ToString();
				}

				result.Append(this.ConvertDecimal(decimalAndUnity[0]));

				if (decimalAndUnity[1] != '0')
				{
					result.Append("-");
					result.Append(this.enumTranslator.Get<NumberInWords>(decimalAndUnity[1]));
				}
				result.Append(" ");
				result.Append(end);

				if (withS)
				{
					result.Append("s");
				}
				result.Append(" ");

				return result.ToString();
			}
			return string.Empty;
		}

		public string ConvertHundrethPart(char value)
		{
			var result = new StringBuilder();
			result.Append(this.enumTranslator.Get<NumberInWords>(value));
			result.Append(" hundred ");
			return result.ToString();
		}

		private string ConvertDecimal(char decimalValue)
		{
			switch (decimalValue)
			{
				case '2': return " twenty";
				case '3': return " thirty";
				case '4': return " forty";
				case '5': return " fifty";
				case '6': return " sixty";
				case '7': return " seventy";
				case '8': return " eighty";
				case '9': return " ninety";
			}
			return string.Empty;
		}

		private string ConverUnity(char decimalValue)
		{
			switch (decimalValue)
			{
				case '1': return "-one ";
				case '2': return "-two ";
				case '3': return "-three ";
				case '4': return "-four ";
				case '5': return "-five ";
				case '6': return "-six ";
				case '7': return "-seven ";
				case '8': return "-eight ";
				case '9': return "-nine ";
			}
			return string.Empty;
		}
	}
}
