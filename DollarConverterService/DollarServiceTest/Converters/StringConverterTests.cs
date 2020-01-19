using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DollarConverter.Converters;
using System.Collections.Generic;
using DollarConverter;

namespace DollarServiceTest.Converters
{
	[TestClass]
	public class StringConverterTests
	{
		private StringConverter converter;

		[TestInitialize]
		public void TestInitialize()
		{
			this.converter = new StringConverter(new EnumTranslator());
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityReturnNumberWithS()
		{
			var input = "0";
			var end = "cent";
			var expected1 = "zero cents ";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(expected1, result1);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityReturnNumberWithoutS()
		{
			var input = "5";
			var end = "million";
			var expected1 = "five million ";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, false);

			Assert.AreEqual(expected1, result1);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityReturnOneWithoutS()
		{
			var input = "1";
			var end = "dollar";
			var expected = "one dollar ";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, false);
			var result2 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(expected, result1);
			Assert.AreEqual(expected, result2);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityReturnEmptyStringWhenIncorrectInput()
		{
			var input = "123";
			var end = "dollar";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, false);
			var result2 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(string.Empty, result1);
			Assert.AreEqual(string.Empty, result2);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityRemoveWhitespaces()
		{
			var input = " 1 2 ";
			var end = "dollar";
			var expected = "twelve dollars ";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(expected, result1);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityReturnEmptyStringWhenCannotParseValue()
		{
			var input = " 1 2sd ";
			var end = "dollar";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(string.Empty, result1);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityNotFromEnum()
		{
			var input = "77";
			var end = "banana";
			var expected = " seventy-seven bananas ";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(expected, result1);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertDecimalAndUnityFromEnum()
		{
			var input = "18";
			var end = "cookie";
			var expected = "eighteen cookies ";

			var result1 = this.converter.ConvertDecimalAndUnity(input, end, true);

			Assert.AreEqual(expected, result1);
		}

		[TestMethod]
		[TestCategory("Unit")]
		[TestCategory("Converter")]
		public void ShouldConvertHundrethPart()
		{
			var expected = "eight hundred ";

			Assert.AreEqual(expected, this.converter.ConvertHundrethPart('8'));
		}
	}
}
