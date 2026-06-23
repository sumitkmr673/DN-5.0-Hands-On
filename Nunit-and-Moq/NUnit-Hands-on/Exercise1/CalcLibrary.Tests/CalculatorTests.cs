using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator.AllClear();
        }

        [TestCase(10.5, 5.5, 16.0)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, 10, 5)]
        public void Addition_ShouldReturnCorrectSum(double a, double b, double expectedResult)
        {
            double actualResult = _calculator.Addition(a, b);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [Ignore("Ignoring this test to demonstrate the [Ignore] attribute.")]
        public void Subtraction_ShouldBeIgnored()
        {
            Assert.Fail("This should never run because of the Ignore attribute.");
        }
    }
}