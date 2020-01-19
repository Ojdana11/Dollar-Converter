using DollarConverter;
using DollarConverter.Converters;
using DollarInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DollarServiceTest.Converters
{
	[TestClass]
	public class DollarsConverterTests
	{
		private DollarsConverter converter;
		private Mock<IStringConverter> stringConverter;		 

		[TestInitialize]
		public void TestIntialize()
		{
			this.stringConverter = new Mock<IStringConverter>();
			this.converter = new DollarsConverter(this.stringConverter.Object, new EnumTranslator());
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertReturnEmptyStringWhenInputIsEmpty()
		{
			Assert.AreEqual(string.Empty, this.converter.Convert(string.Empty));
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertReturnEmptyStringWhenInputIsNotValid()
		{
			Assert.AreEqual(string.Empty, this.converter.Convert("1hello1"));
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertStringWhichLenghtIsNotThreeMultiple()
		{
			var input = "87234";
			var expected = "Peter Pan from Neverland";
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("87", "thousand", false)).Returns("Peter Pan ");
			this.stringConverter.Setup(x => x.ConvertHundrethPart('2')).Returns("from ");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("34", "dollar", true)).Returns("Neverland");

			var result = this.converter.Convert(input);

			Assert.AreEqual(expected, result);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("87", "thousand", false), Times.Once);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('2'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("34", "dollar", true), Times.Once);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertStringWhichLenghtIsThreeMultiple()
		{
			var input = "879234";
			var expected = "Peter Pan from Neverland!";
			this.stringConverter.Setup(x => x.ConvertHundrethPart('8')).Returns("Peter Pan ");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("79", "thousand", false)).Returns("from ");
			this.stringConverter.Setup(x => x.ConvertHundrethPart('2')).Returns("Neverland");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("34", "dollar", true)).Returns("!");

			var result = this.converter.Convert(input);

			Assert.AreEqual(expected, result);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('8'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("79", "thousand", false), Times.Once);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('2'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("34", "dollar", true), Times.Once);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertFloatNumber()
		{
			var input = "879234,12";
			var expected = "Do you like apples and oranges?";
			this.stringConverter.Setup(x => x.ConvertHundrethPart('8')).Returns("Do ");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("79", "thousand", false)).Returns("you ");
			this.stringConverter.Setup(x => x.ConvertHundrethPart('2')).Returns("like");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("34", "dollar", true)).Returns(" apples");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("12", "cent", true)).Returns("oranges?");

			var result = this.converter.Convert(input);

			Assert.AreEqual(expected, result);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('8'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("79", "thousand", false), Times.Once);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('2'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("34", "dollar", true), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("12", "cent", true), Times.Once);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertIgnoreEmptyFractionalPart()
		{
			var input = "879234,";
			var expected = "Do you like apples?";
			this.stringConverter.Setup(x => x.ConvertHundrethPart('8')).Returns("Do ");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("79", "thousand", false)).Returns("you ");
			this.stringConverter.Setup(x => x.ConvertHundrethPart('2')).Returns("like");
			this.stringConverter.Setup(x => x.ConvertDecimalAndUnity("34", "dollar", true)).Returns(" apples?");

			var result = this.converter.Convert(input);

			Assert.AreEqual(expected, result);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('8'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("79", "thousand", false), Times.Once);
			this.stringConverter.Verify(x => x.ConvertHundrethPart('2'), Times.Once);
			this.stringConverter.Verify(x => x.ConvertDecimalAndUnity("34", "dollar", true), Times.Once);
		}
	}
}
