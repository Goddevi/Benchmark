using Benchmark.Services;
namespace Benchmark.Tests.Services
{
    [TestClass]
    public class DefaultNumberParserTests : DefaultNumberParser
    {
        private DefaultNumberParser _numberParser;

        private class CustomNumberParser : DefaultNumberParser
        {
            public void TestHandleNegativeNumbersWrapper(int[] numbers)
            {
                HandleNegativeNumbers(numbers);
            }
            public int[] TestHandleLargeNumbers(int[] numbers)
            {
                return HandleLargeNumbers(numbers);
            }

            public char[] TestHandlePotentialMultipleDelimiters(string delimiter)
            {
                return HandlePotentialMultipleDelimiters(delimiter);
            }
        }

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
            Assert.AreEqual(0, result[1]); // check invalid number 'abc' is replaced with default value 0
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


        [TestMethod]
        public void HandleNegativeNumbers_NoNegativeNumbers_ThrowsNoException()
        {
            // Arrange
            int[] numbers = { 1, 2, 3 };
            var customNumberParser = new CustomNumberParser();

            // Act and Assert
            customNumberParser.TestHandleNegativeNumbersWrapper(numbers);
        }
        [TestMethod]
        public void HandleNegativeNumbers_NoNumbers_ThrowsNoException()
        {
            // Arrange
            int[] numbers = { };
            var customNumberParser = new CustomNumberParser();

            // Act and Assert
            customNumberParser.TestHandleNegativeNumbersWrapper(numbers);
        }

        [TestMethod]
        public void HandleNegativeNumbers_ContainsNegativeNumbers_ThrowsArgumentException()
        {
            // Arrange
            int[] numbers = { 1, -2, 3, -4 };
            var customNumberParser = new CustomNumberParser();


            try
            {
                // Act
                customNumberParser.TestHandleNegativeNumbersWrapper(numbers);

                // Assert
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Negatives are not allowed: -2, -4", ex.Message);
            }
        }

        [TestMethod]
        public void HandleNumbersGreaterThan1000_NoNumbers_ReturnsEmptyArray()
        {
            // Arrange
            int[] numbers = { };
            var customNumberParser = new CustomNumberParser();

            // Act
            int[] result = customNumberParser.TestHandleLargeNumbers(numbers);

            // Assert
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void HandleNumbersGreaterThan1000_NumbersLessThanOrEqualTo1000_ReturnsSameArray()
        {
            // Arrange
            int[] numbers = { 1, 500, 1000 };
            var customNumberParser = new CustomNumberParser();

            // Act
            int[] result = customNumberParser.TestHandleLargeNumbers(numbers);

            // Assert
            CollectionAssert.AreEqual(numbers, result);
        }

        [TestMethod]
        public void HandleNumbersGreaterThan1000_NumbersGreaterThan1000_ReturnsFilteredArray()
        {
            // Arrange
            int[] numbers = { 500, 2000, 1001, 3000, 1000 };
            int[] expected = { 500, 1000 };
            var customNumberParser = new CustomNumberParser();

            // Act
            int[] result = customNumberParser.TestHandleLargeNumbers(numbers);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void HandlePotentialMultipleDelimiters_SingleCharacter_ReturnsCharArrayWithSingleElement()
        {
            // Arrange
            string delimiter = ",";
            var parser = new CustomNumberParser();

            // Act
            char[] result = parser.TestHandlePotentialMultipleDelimiters(delimiter);

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(',', result[0]);
        }

        [TestMethod]
        public void HandlePotentialMultipleDelimiters_MultipleCharacters_ReturnsCharArrayWithAllCharacters()
        {
            // Arrange
            string delimiter = ",;";
            var parser = new CustomNumberParser();

            // Act
            char[] result = parser.TestHandlePotentialMultipleDelimiters(delimiter);

            // Assert
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(',', result[0]);
            Assert.AreEqual(';', result[1]);
        }

        [TestMethod]
        public void HandlePotentialMultipleDelimiters_EmptyString_ReturnsEmptyCharArray()
        {
            // Arrange
            string delimiter = "";
            var parser = new CustomNumberParser();

            // Act
            char[] result = parser.TestHandlePotentialMultipleDelimiters(delimiter);

            // Assert
            Assert.AreEqual(0, result.Length);
        }

    }
}