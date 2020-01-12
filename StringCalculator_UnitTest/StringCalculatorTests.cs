using NUnit.Framework;
using StringCalculator_Library;

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
        public void Calculator_WhenNullOrEmpty_ReturnsZero
            (
                [Values("", null)]
                string input
            )
        {
            int result = stringCalculator.Add(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Calculator_WhenOneNumer_ReturnsSameNumber
            (
                [Values ("1", "10", "100")]
                string input
            )
        {

            int result = stringCalculator.Add(input);

            Assert.AreEqual(int.Parse(input), result);
        }

        [Test]
        public void Calculator_WhenMultipleNumbers_ReturnsSumOfNumbers()
        {
            string input = "1, 2, 3, 4, 5, 10, 23";

            int result = stringCalculator.Add(input);

            Assert.AreEqual(48, result);
        }

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
    }
}