using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.Web.Common.SelfHost;
using System;

namespace DollarConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel(new ServiceModule());

			NinjectWcfConfiguration dollarConverterServiceConfig = 
				NinjectWcfConfiguration.Create<DollarConverterService, NinjectServiceSelfHostFactory>();

			using (var selfHost = new NinjectSelfHostBootstrapper(() => kernel
				, dollarConverterServiceConfig))
			{
				selfHost.Start();
				Console.Write("All Services Started. Press \"Enter\" to stop thems...");
				Console.ReadLine();
			}
		}
	}
}
