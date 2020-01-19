using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DollarInterfaces
{
	public class ValidationRegex
	{
		public static Regex DollarsRegex = new Regex(@"^\d*?(,?\d{0,2})?$");
		public static Regex ZeroRegex = new Regex(@"0{2}");
	}
}
