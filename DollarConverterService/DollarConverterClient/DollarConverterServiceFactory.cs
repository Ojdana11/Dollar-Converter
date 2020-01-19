using DollarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverterClient
{
	public class DollarConverterServiceFactory : IDollarConverterServiceFactory
	{
		public IDollarConverterService Create()
		{
			ChannelFactory<IDollarConverterService> channelFactory = new ChannelFactory<IDollarConverterService>("DollarServiceEndpoint");
			return channelFactory.CreateChannel();
		}
	}
}
