using DollarConverter.Converters;
using DollarInterfaces;
using Ninject.Modules;

namespace DollarConverter
{
	public class ServiceModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IEnumTranslator>().To<EnumTranslator>().InSingletonScope();
			this.Bind<IStringConverter>().To<StringConverter>().InSingletonScope();
			this.Bind<IDollarsConverter>().To<DollarsConverter>().InSingletonScope();
		}
	}
}
