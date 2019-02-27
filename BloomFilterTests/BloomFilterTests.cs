using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class BloomFilterTests
    {
        [TestMethod()]
        public void AddTest()
        {
            BloomFilter testFilter = new BloomFilter(32);
            string s1 = "0123456789";
            string s2 = "1234567890";
            string s3 = "2345678901";
            string s4 = "3456789012";
            string s5 = "4567890123";
            string s6 = "5678901234";
            string s7 = "6789012345";
            string s8 = "7890123456";
            string s9 = "8901234567";
            string s10 = "9012345678";

            testFilter.Add(s1);

            Assert.IsTrue(testFilter.IsValue(s1)); // добавленный элемент присутствует
            Assert.IsFalse(testFilter.IsValue(s2));
            Assert.IsTrue(testFilter.IsValue(s3));
            Assert.IsFalse(testFilter.IsValue(s4));
            Assert.IsTrue(testFilter.IsValue(s5));
            Assert.IsFalse(testFilter.IsValue(s6));
            Assert.IsTrue(testFilter.IsValue(s7));
            Assert.IsFalse(testFilter.IsValue(s8));
            Assert.IsTrue(testFilter.IsValue(s9)); // ложноположительное срабатаывание
            Assert.IsFalse(testFilter.IsValue(s10));
        }
    }
}