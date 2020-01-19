using DollarInterfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverterClient
{
	public class ClientModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IDollarConverterServiceFactory>().To<DollarConverterServiceFactory>().InSingletonScope();
		}
	}
}
