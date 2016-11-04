using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [OneTimeSetUp]
        public void GivenAStringCalculator()
        {
            _stringCalculator = new StringCalculator();
        }

        [TestCase("0", "0", 0)]
        [TestCase("1", "0", 1)]
        [TestCase("one", "0", 1)]
        [TestCase("one", "two", 3)]
        [TestCase("five", "zero", 5)]
        [TestCase("five", "twelve", 17)]
        [TestCase("nineteen","twenty",39)]
        [TestCase("one", "twenty-One", 22)]
        [TestCase("4294967295", "0", 4294967295)]
        [TestCase("4294967295", "1", 4294967296)]
        [TestCase("one hundred and six", "1", 107)]
        [TestCase("minus two", "1", -1)]
        [TestCase("minus two", "five million six hundred and thirty thousand four hundred and seventy-three", 5630471)]
        public void WhenAddIsCalled(string number1, string number2, double expectedResponse)
        {
            var response = _stringCalculator.Add(number1, number2);
            Assert.That(response, Is.EqualTo(expectedResponse));
        }
    }
}
