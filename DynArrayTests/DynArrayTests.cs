using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynArray.Tests
{
    [TestClass()]
    public class DynArrayTests
    {
        [TestMethod()]
        public void AppEndTest_if_Buffer_Is_not_Resized()
        {
            DynArray testDynArr = new DynArray();
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            int expected = 3;
            int actual = testDynArr.GetCount();
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testDynArr.GetCapacity() == 16);
        }

        [TestMethod()]
        public void AppEndTest_if_Buffer_Changed()
        {
            DynArray testDynArr = new DynArray();
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);

            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);

            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            int expected = 18;
            int actual = testDynArr.GetCount();
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testDynArr.GetCapacity() == 32);
        }

        [TestMethod()]
        public void InsertTest_if_Buffer_Is_not_Resized()
        {
            DynArray testDynArr = new DynArray();
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.Insert(1, 19);

            int expectedCount = 4;
            string expectedItem = "19";
            int actualCount = testDynArr.GetCount(); 
            string actualItem = testDynArr.GetItem(1).ToString();

            Assert.AreEqual(expectedCount, actualCount);    // проверка что количество элементов изменилось
            Assert.IsTrue(testDynArr.GetCapacity() == 16);  // проверка что емкость буфера прежняя
            Assert.IsTrue(expectedItem == actualItem);      // проверка что по данному индексу добавлен искомый элемент 
        }

        [TestMethod()]
        public void InsertTest_if_Buffer_Changed()
        {
            DynArray testDynArr = new DynArray();
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);

            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);

            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);

            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            Console.WriteLine("Емкость буфера: {0}", testDynArr.GetCapacity());
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
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);

            testDynArr.Insert(4, 315);
        }
    }
}