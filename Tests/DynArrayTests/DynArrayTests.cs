using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DynArray.Tests
{
    [TestClass()]
    public class DynArrayTests
    {
        [TestMethod()]
        public void AppEndTest_if_Buffer_Is_not_Resized()
        {
            DynArray testDynArr = new DynArray();

            for (int item = 1; item < 4; item++)
            {
                testDynArr.AppEnd(item);
            }

            int expected = 3;
            int actual = testDynArr.GetCount();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testDynArr.GetCapacity() == 16);
        }

        [TestMethod()]
        public void AppEndTest_if_Buffer_Changed()
        {
            DynArray testDynArr = new DynArray();

            for (int item = 1; item < 19; item++)
            {
                testDynArr.AppEnd(item);
            }

            int expected = 18;
            int actual = testDynArr.GetCount();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testDynArr.GetCapacity() == 32);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertTest_if_DynArray_is_Empty()
        {
            DynArray testDynArr = new DynArray();
            testDynArr.Insert(0, 19);
        }

        [TestMethod()]
        public void InsertTest_if_Buffer_Has_not_Changed()
        {
            DynArray testDynArr = new DynArray();

            for (int item = 1; item < 4; item++)
            {
                testDynArr.AppEnd(item);
            }
            testDynArr.Insert(1, 19);

            int expectedCount = 4;
            string expectedItem = "19";
            int actualCount = testDynArr.GetCount();
            string actualItem = testDynArr.GetItem(1).ToString();

            Assert.AreEqual(expectedCount, actualCount);    // проверка, что количество элементов изменилось
            Assert.IsTrue(testDynArr.GetCapacity() == 16);  // проверка, что ёмкость буфера прежняя
            Assert.IsTrue(expectedItem == actualItem);      // проверка, что по данному индексу добавлен искомый элемент 
        }

        [TestMethod()]
        public void InsertTest_if_Buffer_Changed()
        {
            DynArray testDynArr = new DynArray();

            for (int item = 1; item < 17; item++)
            {
                testDynArr.AppEnd(item);
            }

            testDynArr.Insert(3, 315);

            int expectedCount = 17;
            string expectedItem = "315";
            int actualCount = testDynArr.GetCount();
            string actualItem = testDynArr.GetItem(3).ToString();

            Assert.AreEqual(expectedCount, actualCount);    // проверка, что количество элементов изменилось
            Assert.IsTrue(testDynArr.GetCapacity() == 32);  // проверка, что буфер увеличился
            Assert.IsTrue(expectedItem == actualItem);      // проверка, что по данному индексу добавлен искомый элемент 
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertTest_If_Index_is_Out_of_Range()
        {
            DynArray testDynArr = new DynArray();

            for (int item = 1; item < 5; item++)
            {
                testDynArr.AppEnd(item);
            }

            testDynArr.Insert(4, 315);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteTest_If_Index_is_Out_of_Range()
        {
            DynArray testDynArr = new DynArray();
            testDynArr.Delete(4);
        }

        [TestMethod()]
        public void DeleteTest_Buffer_Did_not_Change()
        {
            DynArray testDynArr = new DynArray();

            for (int item = 1; item < 5; item++)
            {
                testDynArr.AppEnd(item);
            }

            testDynArr.Delete(1);

            int expectedCount = 3;
            int actualCount = testDynArr.GetCount();
            int expectedCapacity = 16;
            int actualCapacity = testDynArr.GetCapacity();

            Assert.AreEqual(expectedCount, actualCount);        // проверка, что количество элементов изменилось
            Assert.AreEqual(expectedCapacity, actualCapacity);  // проверка, что ёмкость буфер не изменилась

            for (int i = 0; i < testDynArr.GetCount(); i++)
            {
                Assert.IsFalse(testDynArr.GetItem(i).ToString() == "2"); // проверка, что удаленный элемент отсутствует
            }

        }

        [TestMethod()]
        public void DeleteTest_If_Buffer_Changed_and_Capacity_is_Bigger_16()
        {
            DynArray testDynArr = new DynArray();
            int item = 0;
            for (item = 1; item < 18; item++)
            {
                testDynArr.AppEnd(item);
            }

            for (int i = 0; i < 2; i++)
            {
                testDynArr.Delete(3);
            }

            int expectedCapacity = 21;
            int actualCapacity = testDynArr.GetCapacity();

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestMethod()]
        public void DeleteTest_If_Buffer_Changed_and_Capacity_is_Less_16()
        {
            DynArray testDynArr = new DynArray();
            int item = 0;
            for (item = 1; item < 16; item++)
            {
                testDynArr.AppEnd(item);
            }

            for (int i = 0; i < 10; i++)
            {
                testDynArr.Delete(1);
            }

            int expectedCapacity = 16;
            int actualCapacity = testDynArr.GetCapacity();
            int expectedCount = 5;
            int actualCount = testDynArr.GetCount();

            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}