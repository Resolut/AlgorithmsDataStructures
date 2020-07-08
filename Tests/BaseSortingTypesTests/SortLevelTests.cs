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
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
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
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
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
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
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
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStepTest_if_Array_Has_3_Elements()
        {
            int[] testArr = { 3, 4, 2 };
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            SortLevel.InsertionSortStep(testArr, 1, 0);
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 2, 3, 4 };
            
            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStepTest_if_Array_Has_7_Elements()
        {
            int[] testArr = { 7, 6, 5, 4, 3, 2, 1 };
            
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            SortLevel.InsertionSortStep(testArr, 1, 0);

            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] {1, 2, 3, 4, 5, 6, 7};

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStepTest_if_Array_Has_Step_3()
        {
            int[] testArr = { 7, 6, 5, 4, 3, 2, 1 };

            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            SortLevel.InsertionSortStep(testArr, 3, 0);
            
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 1, 6, 5, 4, 3, 2, 7 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStepTest_if_Array_Has_Step_2()
        {
            int[] testArr = { 7, 6, 5, 4, 3, 2, 1 };
            
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            int step = 2;
            int startIndex = 0;
            
            SortLevel.InsertionSortStep(testArr, step, startIndex);
            
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 1, 6, 3, 4, 5, 2, 7 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStepTest_if_Array_Has_Step_3_startIndex_1()
        {
            int[] testArr = { 1, 6, 5, 4, 3, 2, 7 };
            
            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            int step = 3;
            int startIndex = 1;
            
            SortLevel.InsertionSortStep(testArr, step, startIndex);
            
            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 1, 3, 5, 4, 6, 2, 7 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStepTest_if_Array_Has_Step_4_startIndex_0()
        {
            int[] testArr = { 6, 2, 5, 4, 1, 2, 7 };

            Array.ForEach(testArr, (item) => Console.Write(item + " "));
            Console.WriteLine();

            int step = 4;
            int startIndex = 0;

            SortLevel.InsertionSortStep(testArr, step, startIndex);

            foreach (int item in testArr)
                Console.Write(item + " ");
            Console.WriteLine();

            int[] expectedSortedArr = new int[] { 1, 2, 5, 4, 6, 2, 7 };

            for (int i = 0; i < testArr.Length; i++)
            {
                Assert.AreEqual(expectedSortedArr[i], testArr[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortStep_if_Array_is_Empty()
        {
            int[] testArr = { };

            SortLevel.InsertionSortStep(testArr, 5, 0);

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 0);
        }

        [TestMethod()]
        public void InsertionSortStep_if_Array_Has_1_Elem()
        {
            int[] testArr = { 19 };

            SortLevel.InsertionSortStep(testArr, 12, 0);

            int expected = 19;

            Assert.IsNotNull(testArr);
            Assert.IsTrue(testArr.Length == 1);
            Assert.AreEqual(expected, testArr[0]);
        }
    }
}