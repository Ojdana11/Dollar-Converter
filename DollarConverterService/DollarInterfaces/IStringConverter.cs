using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarInterfaces
{
	public interface IStringConverter
	{
		string ConvertDecimalAndUnity(string decimalAndUnity, string end, bool withS = false);
		string ConvertHundrethPart(char value);
	}
}
