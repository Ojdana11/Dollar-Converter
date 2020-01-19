using DollarInterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DollarConverterClient
{
	public class DollarInputRule : ValidationRule
	{
		//It was my first idea to use validation but then I decided use method inputTextBox_PreviewTextInput which enable user input wrong data
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			var valueAsString = value.ToString();
			if (!string.IsNullOrEmpty(valueAsString))
			{
				if (ValidationRegex.DollarsRegex.IsMatch(valueAsString))
				{
					return new ValidationResult(true, null);
				}
				return new ValidationResult(false, null);
			}
			return new ValidationResult(true, null);
		}
	}
}
