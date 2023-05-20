using Benchmark.Services;
using Benchmark.Services.Interfaces;

namespace Benchmark.Tests.Services
{
    [TestClass]
    public class StringCalculationServiceTests
    {
        private IStringCalculationService _stringCalculationService;
        private ISplitter _splitter;

        [TestInitialize]
        public void Setup()
        {
            _splitter = new CommaSplitter();
            _stringCalculationService = new StringCalculationService(_splitter);
        }

        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            string numbers = "";
            int expected = 0;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            string numbers = "42";
            int expected = 42;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            string numbers = "1,2,3,4,5";
            int expected = 15;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NonNumericInput_ReturnsZero()
        {
            string numbers = "abc";
            int expected = 0;

            int result = _stringCalculationService.Add(numbers);

            Assert.AreEqual(expected, result);
        }
    }
}
