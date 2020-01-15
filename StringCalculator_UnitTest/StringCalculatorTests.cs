using NUnit.Framework;
using StringCalculator_Library;
using System;

namespace StringCalculator_UnitTest
{
    /*
     * Arrange
     * Act
     * Assert
    */

    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void Setup()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(null, ExpectedResult = 0)]
        public int Calculator_WhenNullOrEmpty_ReturnsZero(string input) => stringCalculator.Add(input);

        [Test]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("10", ExpectedResult = 10)]
        [TestCase("7548", ExpectedResult = 7548)]
        public int Calculator_WhenOneNumer_ReturnsSameNumber(string input) => stringCalculator.Add(input);

        [Test]
        [TestCase("1, 2, 3, 4, 5, 10, 23", ExpectedResult = 48)]
        [TestCase("15, 5, 1, 38, 9, 10", ExpectedResult = 78)]
        [TestCase("7, 5, 9", ExpectedResult = 21)]
        public int Calculator_WhenMultipleNumbers_ReturnsSumOfNumbers(string input) => stringCalculator.Add(input);

        [Test]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("5\n5\n3\n12\n3\n8", ExpectedResult = 36)]
        [TestCase("1,3,8,0,3", ExpectedResult = 15)]
        [TestCase("1\n2,3,3\n6,7\n5,9", ExpectedResult = 36)]
        public int Calculator_WhenNewLine_ReturnsHandledOutput(string input) => stringCalculator.Add(input);

        [Test]
        [TestCase("//$\n1$2", ExpectedResult = 3)]
        [TestCase("//;\n1,4,3\n6,3;8;2", ExpectedResult = 27)]
        [TestCase("//*\n1,2,3\n4,5*1*0", ExpectedResult = 16)]
        [TestCase("1,4,3\n6,3\n3\n2", ExpectedResult = 22)]
        public int Calculator_WhenDelimitersSpecified_ReturnsSumOfNumbers(string input) => stringCalculator.Add(input);

        [Test]
        [TestCase("-1,2,4,6,4,8")]
        [TestCase("-1,-4,5\n8,4")]
        [TestCase("//*\n1,-2,3\n4,5*-1*0")]
        public void Calculator_WhenNegativeNumbers_ThrowsException(string input)
        {
            Assert.Throws<FormatException>(() => stringCalculator.Add(input));
        }

        [Test]
        [TestCase("1005,2,5", ExpectedResult = 7)]
        [TestCase("1005,7,7,13,2", ExpectedResult = 29)]
        [TestCase("1001,1,1", ExpectedResult = 2)]
        public int Calculator_WhenGreaterThan1000_ReturnsSumOfNumbersExcluding1000(string input) => stringCalculator.Add(input);

    }
}