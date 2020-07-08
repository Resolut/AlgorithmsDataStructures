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

            SortLevel.SelectionSortStep(testArr, 0);
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

            SortLevel.SelectionSortStep(testArr, 0);

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 0);

        }

        [TestMethod()]
        public void SelectionSortStep_if_Array_Has_1_Elem()
        {
            int[] testArr = { 19 };

            SortLevel.SelectionSortStep(testArr, 0);

            int expected = 19;

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 1);

            Assert.AreEqual(expected, testArr[0]);

        }

        [TestMethod()]
        public void SelectionSortStep_if_Array_Has_2_Elem()
        {
            int[] testArr = { 21, 19 };

            SortLevel.SelectionSortStep(testArr, 0);

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 2);

            int[] expectedSortedArr = new int[] { 19, 21 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(testArr[i], expectedSortedArr[i]);
            }

        }

        [TestMethod()]
        public void BubbleSortStepTest_if_Array_unsorted()
        {
            int[] testArr = { 4, 3, 1, 2 };
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            bool res = SortLevel.BubbleSortStep(testArr);
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] {3, 1, 2, 4 };
            
            Assert.IsFalse(res);

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(testArr[i], expectedSortedArr[i]);
            }
        }

        [TestMethod()]
        public void BubbleSortStep_if_Array_is_Empty()
        {
            int[] testArr = { };

            bool res = SortLevel.BubbleSortStep(testArr);

            Assert.IsNotNull(testArr);
            Assert.IsTrue(res);
            Assert.IsTrue(testArr.Length == 0);
        }

        [TestMethod()]
        public void BubbleSortStep_if_Array_Has_1_Elem()
        {
            int[] testArr = { 19 };

            bool res = SortLevel.BubbleSortStep(testArr);

            int expected = 19;

            Assert.IsNotNull(testArr);
            Assert.IsTrue(res);
            Assert.IsTrue(testArr.Length == 1);
            Assert.AreEqual(expected, testArr[0]);
        }

        [TestMethod()]
        public void BubbleSortStepTest_if_Array_is_Already_Sorted()
        {
            int[] testArr = { 1, 2, 3, 4 };
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            bool res = SortLevel.BubbleSortStep(testArr);
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 1, 2, 3, 4 };

            Assert.IsNotNull(testArr);
            Assert.IsTrue(res);
            Assert.IsTrue(testArr.Length == 4);

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(testArr[i], expectedSortedArr[i]);
            }
        }
    }
}