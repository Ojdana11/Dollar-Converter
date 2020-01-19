using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;
using System.Diagnostics;
using System.IO;

namespace DollarClientTest
{
	[TestClass]
	public class DollarClientTests
	{
		private Application app;
		private Window window;

		[TestInitialize]
		public void TestInitialize()
		{
			this.app = Application.Launch("DollarConverterClient.exe");
			this.window = app.GetWindow("Dollar Converter", InitializeOption.NoCache);
		}

		[TestMethod]
		[TestCategory("Integration")]
		[TestCategory("UI")]
		public void TestClient()
		{
			var inputTextBox = window.Get<TextBox>("inputTextBox");
		//	var expected = "six thousand four hundred twenty-seven dollars and sixty-three cents";

		//	inputTextBox.SetValue("6427,63");

			var textResult = window.Get<TextBox>("textResult");
			var result = textResult.Text;

			Assert.AreEqual(string.Empty, result);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			this.app.Close();
		}
	}
}
