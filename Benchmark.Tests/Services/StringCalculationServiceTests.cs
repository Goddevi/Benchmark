using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmark.Services.Helpers;
using Benchmark.Services.Interfaces;
using Benchmark.Services;


namespace Benchmark.Tests.Services
{
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
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            string numbers = "";
            int expected = 0;

            // Act
            int result = _stringCalculationService.Add(numbers);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            string numbers = "42";
            int expected = 42;

            // Act
            int result = _stringCalculationService.Add(numbers);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            // Arrange
            string numbers = "1,2,3,4,5";
            int expected = 15;

            // Act
            int result = _stringCalculationService.Add(numbers);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NonNumericInput_ReturnsZero()
        {
            // Arrange
            string numbers = "abc";
            int expected = 0;

            // Act
            int result = _stringCalculationService.Add(numbers);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}


