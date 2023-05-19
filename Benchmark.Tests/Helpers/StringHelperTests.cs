using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmark.Services.Helpers;


    namespace Benchmark.Tests.Helpers
    {
        [TestClass]
        public class StringHelpersTests
        {
            [TestMethod]
            public void TryConvertStringToInt32_ValidNumber_ReturnsConvertedValue()
            {
                // Arrange
                string number = "42";
                int expected = 42;

                // Act
                int result = number.TryConvertStringToInt32();

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TryConvertStringToInt32_InvalidNumber_ReturnsZero()
            {
                // Arrange
                string invalidNumber = "abc";
                int expected = 0;

                // Act
                int result = invalidNumber.TryConvertStringToInt32();

                // Assert
                Assert.AreEqual(expected, result);
            }
        }
    }


