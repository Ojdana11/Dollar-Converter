using DollarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter
{
	public class EnumTranslator : IEnumTranslator
	{
		public string Get<T>(char value)
		{
			var asNumber = Int32.Parse(value.ToString());
			return this.Get<T>(asNumber);
		}

		public string Get<T>(int value)
		{
			return ((T)(object)value).ToString();
		}
	}
}
