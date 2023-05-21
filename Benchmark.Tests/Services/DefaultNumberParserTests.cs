using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benchmark.Services;
namespace Benchmark.Tests.Services
{
    [TestClass]
    public class DefaultNumberParserTests
    {
        private DefaultNumberParser _numberParser;

        [TestInitialize]
        public void Setup()
        {
            _numberParser = new DefaultNumberParser();
        }

        [TestMethod]
        public void ParseNumbers_InputWithValidNumbers_ReturnsParsedNumbersArray()
        {
            // Arrange
            string input = "1,2,3";

            // Act
            int[] result = _numberParser.ParseNumbers(input);

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
        }

        [TestMethod]
        public void ParseNumbers_InputWithInvalidNumbers_ReturnsParsedNumbersArrayWithDefaultValues()
        {
            // Arrange
            string input = "1,abc,3";

            // Act
            int[] result = _numberParser.ParseNumbers(input);

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(0, result[1]); // Invalid number 'abc' is replaced with default value 0
            Assert.AreEqual(3, result[2]);
        }

        [TestMethod]
        public void ParseNumbers_EmptyInput_ReturnsEmptyArray()
        {
            // Arrange
            string input = "";

            // Act
            int[] result = _numberParser.ParseNumbers(input);

            // Assert
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void ParseNumbers_NullInput_ReturnsEmptyArray()
        {
            // Arrange
            string input = null;

            // Act
            int[] result = _numberParser.ParseNumbers(input);

            // Assert
            Assert.AreEqual(0, result.Length);
        }
    }
}