using Benchmark.Services;

namespace Benchmark.Tests.Services
{
    [TestClass]
    public class CommaSplitterTests
    {
        private CommaSplitter _splitter;

        [TestInitialize]
        public void Setup()
        {
            _splitter = new CommaSplitter();
        }

        [TestMethod]
        public void Split_EmptyString_ReturnsEmptyArray()
        {
            string numbers = ",";
            string[] expected = new string[] { };

            string[] result = new string[] { };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Split_SingleNumber_ReturnsSingleElementArray()
        {
            string numbers = "42";
            string[] expected = new string[] { "42" };

            string[] result = _splitter.Split(numbers);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Split_MultipleNumbers_ReturnsArray()
        {
            string numbers = "1,2,3,4,5";
            string[] expected = new string[] { "1", "2", "3", "4", "5" };

            string[] result = _splitter.Split(numbers);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
