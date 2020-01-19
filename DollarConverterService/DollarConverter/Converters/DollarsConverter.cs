using DollarConverter.Common;
using DollarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Converters
{
	public class DollarsConverter : IDollarsConverter
	{
		private IStringConverter stringConverter;
		private IEnumTranslator enumTranslator;

		public DollarsConverter(IStringConverter stringConverter, IEnumTranslator enumTranslator)
		{
			this.stringConverter = stringConverter;
			this.enumTranslator = enumTranslator;
		}

		public string Convert(string dollars)
		{
			if (ValidationRegex.DollarsRegex.IsMatch(dollars) && !string.IsNullOrEmpty(dollars))
			{
				var result = new StringBuilder();
				var totalAndPart = dollars.Split(',');
				var dollarsMagnitude = (int)Math.Ceiling(totalAndPart[0].Length / (float)3);
				var subDollarsLen = totalAndPart[0].Length % 3;
				var pointer = 0;
				if(subDollarsLen != 0)
				{
					result.Append(
						this.stringConverter.ConvertDecimalAndUnity(
							totalAndPart[0].Substring(0, subDollarsLen), 
							this.enumTranslator.Get<MagnitudeEnum>(dollarsMagnitude), 
							dollarsMagnitude == 1)
					);
					pointer = subDollarsLen;
					dollarsMagnitude--;
				}
				for (int i= dollarsMagnitude; i > 0; i--, pointer += 3)
				{
					var subDollars = totalAndPart[0].Substring(pointer, 3);
					result.Append(this.stringConverter.ConvertHundrethPart(subDollars[0]));
					result.Append(
						this.stringConverter.ConvertDecimalAndUnity(
							subDollars.Substring(1, 2),
							this.enumTranslator.Get<MagnitudeEnum>(i), 
							i == 1)
					);
				}
				if (totalAndPart.Length > 1)
				{
					if (!string.IsNullOrEmpty(totalAndPart[1]))
					{
						result.Append(" and ");
						result.Append(this.stringConverter.ConvertDecimalAndUnity(totalAndPart[1], "cent", true));
					}
				}
				return result.ToString();
			}
			return string.Empty;
		}

	}
}
