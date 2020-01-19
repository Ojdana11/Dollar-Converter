using DollarConverter;
using DollarConverter.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DollarServiceTest
{
	[TestClass]
	public class EnumTranslatorTests
	{
		private EnumTranslator enumTranslator;

		[TestInitialize]
		public void TestInitialize()
		{
			this.enumTranslator = new EnumTranslator();
		}

		[TestMethod]
		[TestCategory("Unit")]
		public void ShouldGetCharAsString()
		{
			Assert.AreEqual("dollar", this.enumTranslator.Get<MagnitudeEnum>('1'));
		}

		[TestMethod]
		[TestCategory("Unit")]
		public void ShouldGetCharAsStringThrowsWhenCannotParseCharToInt()
		{
			Assert.ThrowsException<FormatException>(() => this.enumTranslator.Get<MagnitudeEnum>('a'));
		}

		[TestMethod]
		[TestCategory("Unit")]
		public void ShouldGetIntAsString()
		{
			Assert.AreEqual("fifteen", this.enumTranslator.Get<NumberInWords>(15));
		}

		[TestMethod]
		[TestCategory("Unit")]
		public void ShouldGetIntAsStringReturnSameStringWhenNoEnumValue()
		{
			Assert.AreEqual("115", this.enumTranslator.Get<NumberInWords>(115));
		}

	}
}
