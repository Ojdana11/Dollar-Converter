using DollarInterfaces;
using System;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DollarConverterClient
{
	public partial class MainWindow : Window
	{
		private IDollarConverterServiceFactory dollarConverterServiceFactory;

		public MainWindow()
		{
			InitializeComponent();
		}
		public MainWindow(IDollarConverterServiceFactory dollarConverterServiceFactor) : this()
		{
			this.dollarConverterServiceFactory = dollarConverterServiceFactor;
		}

		private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var proxy = this.dollarConverterServiceFactory.Create();
			TextBox textBox = sender as TextBox;
			textResult.Text = proxy.GetDollarsInWords(inputTextBox.Text);
		}

		private void inputTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			var newText = new StringBuilder();
			newText.Append(inputTextBox.Text);
			newText.Append(e.Text);
			float.TryParse(newText.ToString(), out float valueAsNumber);
			if (valueAsNumber >= 1000000000)
			{
				e.Handled = true;
			}
			else
			{
				var nextTextAsString = newText.ToString();
				e.Handled = !ValidationRegex.DollarsRegex.IsMatch(nextTextAsString) || 
							ValidationRegex.ZeroRegex.IsMatch(nextTextAsString);
			}
		}
	}
}

	

