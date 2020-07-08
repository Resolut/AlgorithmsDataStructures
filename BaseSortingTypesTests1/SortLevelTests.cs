using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SortSpace.Tests
{
    [TestClass()]
    public class SortLevelTests
    {
        [TestMethod()]
        public void SelectionSortStepTest()
        {
            int[] testArr = { 4, 3, 1, 2 };
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            SortLevel.SelectionSortStep(ref testArr, 0);
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 1, 3, 4, 2 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(testArr[i], expectedSortedArr[i]);
            }
        }

        [TestMethod()]
        public void SelectionSortStep_if_Array_is_Empty()
        {
            int[] testArr = { };

            SortLevel.SelectionSortStep(ref testArr, 0);

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 0);

        }

        [TestMethod()]
        public void SelectionSortStep_if_Array_Has_1_Elem()
        {
            int[] testArr = { 19 };

            SortLevel.SelectionSortStep(ref testArr, 0);

            int expected = 19;

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 1);

            Assert.AreEqual(expected, testArr[0]);

        }

        [TestMethod()]
        public void SelectionSortStep_if_Array_Has_2_Elem()
        {
            int[] testArr = { 21, 19 };

            SortLevel.SelectionSortStep(ref testArr, 0);

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 2);

            int[] expectedSortedArr = new int[] { 19, 21 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(testArr[i], expectedSortedArr[i]);
            }

        }
    }
}