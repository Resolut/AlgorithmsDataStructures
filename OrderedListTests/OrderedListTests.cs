using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class OrderedListTests
    {
        [TestMethod()]
        public void Add_Empty_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(19);

            int expectedSize = 1;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 19);
            Assert.IsTrue(tList.tail.value == 19);
        }

        [TestMethod()]
        public void Add_Empty_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(19);

            int expectedSize = 1;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 19);
            Assert.IsTrue(tList.tail.value == 19);

        }

        [TestMethod()]
        public void Add_in_between_nodes_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(1);
            tList.Add(3);

            tList.Add(2);

            int expectedSize = 3;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 1);
            Assert.IsTrue(tList.head.next.value == 2);
            Assert.IsTrue(tList.tail.value == 3);
            Assert.IsTrue(tList.tail.prev.value == 2);

        }

        [TestMethod()]
        public void Add_in_between_nodes_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(9);
            tList.Add(7);

            tList.Add(8);

            int expectedSize = 3;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 9);
            Assert.IsTrue(tList.head.next.value == 8);
            Assert.IsTrue(tList.tail.value == 7);
            Assert.IsTrue(tList.tail.prev.value == 8);
        }

        [TestMethod()]
        public void Add_if_More_than_the_Tail_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(1);
            tList.Add(2);
            tList.Add(3);

            tList.Add(9);

            int expectedSize = 4;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 1);
            Assert.IsTrue(tList.tail.value == 9);
            Assert.IsTrue(tList.tail.prev.value == 3);
        }

        [TestMethod()]
        public void Add_if_Less_than_the_Head_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(2);
            tList.Add(3);
            tList.Add(9);

            tList.Add(0);

            int expectedSize = 4;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 0);
            Assert.IsTrue(tList.head.next.value == 2);
            Assert.IsTrue(tList.tail.value == 9);
        }

        [TestMethod()]
        public void Add_if_Less_than_the_Tail_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(3);
            tList.Add(1);
            tList.Add(2);

            tList.Add(0);

            int expectedSize = 4;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 3);
            Assert.IsTrue(tList.tail.value == 0);
            Assert.IsTrue(tList.tail.prev.value == 1);
        }

        [TestMethod()]
        public void Add_if_More_than_the_Head_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(5);
            tList.Add(6);
            tList.Add(8);

            tList.Add(19);

            int expectedSize = 4;
            int actualSize = tList.Count();

            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.value == 19);
            Assert.IsTrue(tList.tail.value == 5);
            Assert.IsTrue(tList.head.next.value == 8);
        }

        [TestMethod()]
        public void Find_in_Empty_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);

            Assert.IsNull(tList.Find(19));
            Assert.IsTrue(tList.Count() == 0);
        }

        [TestMethod()]
        public void Find_in_Empty_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);

            Assert.IsNull(tList.Find(19));
            Assert.IsTrue(tList.Count() == 0);
        }

        [TestMethod()]
        public void Find_if_Elem_Is_not_Exists_in_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(2);
            tList.Add(3);
            tList.Add(9);
            tList.Add(0);

            Node<int> actual = tList.Find(42);

            Assert.IsNull(actual);
        }

        [TestMethod()]
        public void Find_if_Elem_Is_not_Exists_in_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(12);
            tList.Add(48);
            tList.Add(35);
            tList.Add(-101);

            Node<int> actual = tList.Find(42);

            Assert.IsNull(actual);
        }

        [TestMethod()]
        public void Find_if_Elem_Is_Exists_in_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(2);
            tList.Add(3);
            tList.Add(9);

            tList.Add(0);

            int expectedFoundValue = 3;
            int actualFoundValue = tList.Find(3).value;

            Assert.AreEqual(expectedFoundValue, actualFoundValue);
        }

        [TestMethod()]
        public void Find_if_Elem_Is_Exists_in_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(12);
            tList.Add(48);
            tList.Add(35);

            tList.Add(-101);

            int expectedFoundValue = -101;
            int actualFoundValue = tList.Find(-101).value;

            Assert.AreEqual(expectedFoundValue, actualFoundValue);
        }

        [TestMethod()]
        public void Delete_from_Empty_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Delete(42);

            Assert.IsTrue(tList.Count() == 0);
        }

        [TestMethod()]
        public void Delete_from_Empty_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);

            tList.Delete(42);

            Assert.IsTrue(tList.Count() == 0);
        }

        [TestMethod()]
        public void Delete_if_Elem_Is_Not_Exists_in_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(12);
            tList.Add(48);
            tList.Add(35);
            tList.Add(-101);

            tList.Delete(42);
            Node<int> actualFoundValue = tList.Find(42);
            int expectedSize = 4;
            int actualSize = tList.Count();

            Assert.IsNull(actualFoundValue);
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod()]
        public void Delete_if_Elem_Is_Exists_in_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);
            tList.Add(12);
            tList.Add(48);
            tList.Add(35);
            tList.Add(-101);
            tList.Add(119);

            tList.Delete(35);
            Node<int> actualFoundValue = tList.Find(35);

            int expectedSize = 4;
            int actualSize = tList.Count();

            Assert.IsNull(actualFoundValue);
            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.next.next.next.value == 119);
            Assert.IsTrue(tList.tail.prev.value == 48);
        }

        [TestMethod()]
        public void Delete_if_Elem_Is_Exists_in_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(12);
            tList.Add(48);
            tList.Add(35);
            tList.Add(-101);

            tList.Delete(12);

            Node<int> actualFoundValue = tList.Find(12);

            int expectedSize = 3;
            int actualSize = tList.Count();

            Assert.IsNull(actualFoundValue);
            Assert.AreEqual(expectedSize, actualSize);
            Assert.IsTrue(tList.head.next.next.value == -101);
            Assert.IsTrue(tList.tail.prev.value == 35);
        }

        [TestMethod()]
        public void Delete_if_Elem_Is_Not_Exists_in_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);
            tList.Add(122);
            tList.Add(7);
            tList.Add(21);
            tList.Add(7);
            tList.Add(0);

            tList.Delete(42);
            Node<int> actualFoundValue = tList.Find(42);

            int expectedSize = 5;
            int actualSize = tList.Count();

            Assert.IsNull(actualFoundValue);
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod()]
        public void Add_if_Exists_Duplicate_Element_Asc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(true);

            tList.Add(10);
            tList.Add(9);
            tList.Add(1);
            tList.Add(5);
            tList.Add(1);
            tList.Add(6);
            tList.Add(2);
            tList.Add(8);
            tList.Add(7);
            tList.Add(4);

            Assert.IsTrue(tList.Count() == 10);
            Assert.IsTrue(tList.head.value == 1);
            Assert.IsTrue(tList.head.next.value == 1);
            Assert.IsTrue(tList.head.next.prev.value == 1);
            Assert.IsTrue(tList.head.next.next.value == 2);
        }

        [TestMethod()]
        public void Add_if_Exists_Duplicate_Element_Desc_List()
        {
            OrderedList<int> tList = new OrderedList<int>(false);

            tList.Add(10);
            tList.Add(9);
            tList.Add(1);
            tList.Add(5);
            tList.Add(1);
            tList.Add(6);
            tList.Add(2);
            tList.Add(8);
            tList.Add(7);
            tList.Add(4);

            Assert.IsTrue(tList.Count() == 10);
            Assert.IsTrue(tList.tail.value == 1);
            Assert.IsTrue(tList.tail.prev.value == 1);
            Assert.IsTrue(tList.tail.prev.next.value == 1);
            Assert.IsTrue(tList.tail.prev.prev.value == 2);
        }
    }
}