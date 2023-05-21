using Benchmark.Services;
using Benchmark.Services.Interfaces;
using Moq;
namespace Benchmark.Tests.Services
{
    /// <summary>
    /// This test class is testing the String Calculation Service.
    /// 
    /// </summary>
    [TestClass]
    public class StringCalculationServiceTests
    {
        private IStringCalculationService _stringCalculationService;

        [TestInitialize]
        public void Setup()
        {
            _stringCalculationService = new StringCalculationService();
        }

        [TestMethod]
        public void Add_EmptyString_Should_ReturnZero()
        {
            string numbers = "";
            int expected = 0;
          

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_SingleNumber_Should_ReturnNumber()
        {
            string numbers = "42";
            int expected = 42;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_MultipleNumbers_Should_ReturnSum()
        {
            string numbers = "1,2,3,4,5";
            int expected = 15;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NonNumericInput_Should_ReturnZero()
        {
            string numbers = "abc";
            int expected = 0;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        //For this next batch of Add() Tests we will be using Moq to Mock the Number Parser which will be tested elsewhere.
   
        [TestMethod]
        public void Add_EmptyStringAndNumberParser_Should_ReturnZero()
        {
            //Arrange
            string numbers = "";
            int expected = 0;
            var numberParserMock = new Mock<INumberParser>();
            numberParserMock.Setup(parser => parser.ParseNumbers(It.IsAny<string>()))
                            .Returns(new[] {0});

            //Act
            int result = _stringCalculationService.Add(numbers,numberParserMock.Object);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_SingleNumberAndNumberParser_Should_ReturnNumber()
        {
            string numbers = "42";
            int expected = 42;
            var numberParserMock = new Mock<INumberParser>();
            numberParserMock.Setup(parser => parser.ParseNumbers(It.IsAny<string>()))
                            .Returns(new[] { 42 });

            int result = _stringCalculationService.Add(numbers, numberParserMock.Object);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_MultipleNumbersAndNumberParser_Should_ReturnSum()
        {
            string numbers = "1,2,3,4,5";
            int expected = 15;
            var numberParserMock = new Mock<INumberParser>();
            numberParserMock.Setup(parser => parser.ParseNumbers(It.IsAny<string>()))
                            .Returns(new[] { 1,2,3,4,5});

            int result = _stringCalculationService.Add(numbers, numberParserMock.Object);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NonNumericInputAndNumberParser_Should_ReturnZero()
        {
            string numbers = "abc";
            int expected = 0;
            var numberParserMock = new Mock<INumberParser>();
            numberParserMock.Setup(parser => parser.ParseNumbers(It.IsAny<string>()))
                            .Returns(new[] { 0 });

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }
    }
}
