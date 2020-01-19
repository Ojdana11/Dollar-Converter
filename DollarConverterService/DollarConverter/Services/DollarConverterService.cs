using DollarConverter.Converters;
using DollarInterfaces;

namespace DollarConverter
{
	public class DollarConverterService : IDollarConverterService
	{
		private IDollarsConverter dollarsConverter;
		public DollarConverterService(IDollarsConverter dollarsConverter)
		{
			this.dollarsConverter = dollarsConverter;
		}
		public string GetDollarsInWords(string dollars)
		{
			return this.dollarsConverter.Convert(dollars);
		}
	}
}
