using DollarConverter;
using DollarInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DollarServiceTest.Services
{
	[TestClass]
	public class DollarConverterServiceTests
	{
		private DollarConverterService service;
		private Mock<IDollarsConverter> converter;

		[TestInitialize]
		public void TestInitialize()
		{
			this.converter = new Mock<IDollarsConverter>();
			this.service = new DollarConverterService(this.converter.Object);
		}

		[TestMethod]
		[TestCategory("Service")]
		[TestCategory("Unit")]
		public void ShouldGetDollarsInWordsReturnConvertedDollars()
		{
			var input = "123";
			var expected = "one two three";
			this.converter.Setup(x => x.Convert(input)).Returns(expected);

			var result = this.service.GetDollarsInWords(input);

			Assert.AreEqual(expected, result);
			this.converter.Verify(x => x.Convert(input), Times.Once);
		}
	}
}
