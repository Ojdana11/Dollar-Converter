using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarInterfaces
{
	public interface IEnumTranslator
	{
		string Get<T>(char value);
		string Get<T>(int value);
	}
}
