using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        [TestMethod()]
        public void RecTest()
        {
            int ret5 = SortLevel.Rec(5);
            int ret4 = SortLevel.Rec(4);
            int ret3 = SortLevel.Rec(3);
            int ret2 = SortLevel.Rec(2);
            int ret1 = SortLevel.Rec(1);
            int ret0 = SortLevel.Rec(0);

            int expected5 = 364;
            int expected4 = 121;
            int expected3 = 40;
            int expected2 = 13;
            int expected1 = 4; 
            int expected0 = 1;

            Assert.AreEqual(expected5, ret5);
            Assert.AreEqual(expected4, ret4);
            Assert.AreEqual(expected3, ret3);
            Assert.AreEqual(expected2, ret2);
            Assert.AreEqual(expected1, ret1);
            Assert.AreEqual(expected0, ret0);
        }

        [TestMethod()]
        public void KnuthSequenceTest_0_1()
        {
            List<int> ret_0 = SortLevel.KnuthSequence(0);
            List<int> ret_1 = SortLevel.KnuthSequence(1);
            
            List<int> expectedList_1 = new List<int> { 1 };
            
            int expectedCount = 1;
            
            int actualCount_0 = ret_0.Count;
            int actualCount_1 = ret_1.Count;

            Assert.AreEqual(expectedCount, actualCount_0);
            Assert.AreEqual(expectedCount, actualCount_1);

            for (int i = 0; i < ret_0.Count; i++)
            {
                Assert.AreEqual(expectedList_1[i], ret_0[i]);
            }

            for (int i = 0; i < ret_1.Count; i++)
            {
                Assert.AreEqual(expectedList_1[i], ret_1[i]);
            }
        }

        [TestMethod()]
        public void KnuthSequenceTest_2_3_4() 
        {
            List<int> ret1_2 = SortLevel.KnuthSequence(2);
            List<int> ret1_3 = SortLevel.KnuthSequence(3);
            List<int> ret1_4 = SortLevel.KnuthSequence(4);
            
            List<int> expectedList_1 = new List<int> { 1 };

            int expectedCount = 1;
            int actualCount2 = ret1_2.Count;
            int actualCount3 = ret1_3.Count;
            int actualCount4 = ret1_4.Count;

            Assert.AreEqual(expectedCount, actualCount2);
            Assert.AreEqual(expectedCount, actualCount3);
            Assert.AreEqual(expectedCount, actualCount4);

            for (int i = 0; i < ret1_2.Count; i++)
            {
                Assert.AreEqual(expectedList_1[i], ret1_2[i]);
            }

            for (int i = 0; i < ret1_3.Count; i++)
            {
                Assert.AreEqual(expectedList_1[i], ret1_3[i]);
            }

            for (int i = 0; i < ret1_4.Count; i++)
            {
                Assert.AreEqual(expectedList_1[i], ret1_4[i]);
            }
        }

        [TestMethod()]
        public void KnuthSequenceTest_13_14_15()
        {
            List<int> ret1_1 = SortLevel.KnuthSequence(13);
            List<int> ret1_2 = SortLevel.KnuthSequence(14);
            List<int> ret1_3= SortLevel.KnuthSequence(15);
            
            List<int> expectedList = new List<int> { 4, 1 };
            List<int> expectedList2 = new List<int> { 13, 4, 1 };

            int expectedCount = 2;
            int expectedCount2 = 3;

            int actualCount1 = ret1_1.Count;
            int actualCount2 = ret1_2.Count;
            int actualCount3 = ret1_3.Count;
            
            Assert.AreEqual(expectedCount, actualCount1);
            Assert.AreEqual(expectedCount2, actualCount2);
            Assert.AreEqual(expectedCount2, actualCount3);

            for (int i = 0; i < ret1_1.Count; i++)
            {
                Assert.AreEqual(expectedList[i], ret1_1[i]);
            }

            for (int i = 0; i < ret1_2.Count; i++)
            {
                Assert.AreEqual(expectedList2[i], ret1_2[i]);
            }

            for (int i = 0; i < ret1_3.Count; i++)
            {
                Assert.AreEqual(expectedList2[i], ret1_3[i]);
            }
        }
    }
}