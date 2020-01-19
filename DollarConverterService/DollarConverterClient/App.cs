using System.Windows;

namespace DollarConverterClient
{
	/// <summary>
	///     Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			IocKernel.Initialize(new ClientModule());
			Current.MainWindow = IocKernel.Get<MainWindow>();
			Current.MainWindow.Show();
		}
	}
}
