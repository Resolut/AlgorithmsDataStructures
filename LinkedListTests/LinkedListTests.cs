using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class LinkedListTests
    {

        [TestMethod()]
        public void Remove_nor_Head_nor_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));

            int expectedLength = 3;

            testList.Remove(2);
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void RemoveNode_in_Head()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));

            int expectedLength = 3;

            testList.Remove(1);
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void RemoveNode_in_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));

            int expectedLength = 3;

            testList.Remove(3);
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void RemoveNode_from_Null_List()
        {
            LinkedList testList = new LinkedList();
            int expectedLength = 0;
            testList.Remove(3);
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void Remove_from_List_with_One_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(3));
            int expectedLength = 0;
            testList.Remove(3);
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void AddInTail_in_EmptyList()
        {
            LinkedList testList = new LinkedList();
            int expectedLength = 1;
            testList.AddInTail(new Node(4));
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void AddInTail_in_List_with_One_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            int expectedLength = 2;
            testList.AddInTail(new Node(2));
            int actual = testList.Count();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void RemoveAllNodes_DublicateValues_OneByOne()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));

            int expected = 6;
            testList.RemoveAll(2);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAllNodes_One_More_Values()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));

            int expected = 7;
            testList.RemoveAll(3);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAllNodes_Single_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(6));
            testList.AddInTail(new Node(7));
            testList.AddInTail(new Node(8));

            int expected = 8;
            testList.RemoveAll(2);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAllNodes_DublicateValues_Head_n_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(6));
            testList.AddInTail(new Node(7));
            testList.AddInTail(new Node(8));
            testList.AddInTail(new Node(0));

            int expected = 8;
            testList.RemoveAll(0);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAllNodes_DublicateValues_inTail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(6));
            testList.AddInTail(new Node(7));
            testList.AddInTail(new Node(8));
            testList.AddInTail(new Node(321));
            testList.AddInTail(new Node(321));
            testList.AddInTail(new Node(321));
            testList.AddInTail(new Node(321));

            int expected = 9;
            testList.RemoveAll(321);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAllNodes_only_List_Has()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(321));
            testList.AddInTail(new Node(321));
            testList.AddInTail(new Node(321));
            testList.AddInTail(new Node(321));
            testList.RemoveAll(321);

            Assert.IsTrue(testList.Count() == 0);
        }

        [TestMethod()]
        public void Clear_NotEmptyList()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.Clear();

            Assert.IsTrue(testList.Count() == 0);
        }

        [TestMethod()]
        public void Clear_EmptyList()
        {
            LinkedList testList = new LinkedList();

            testList.Clear();

            Assert.IsTrue(testList.Count() == 0);
        }

        [TestMethod()]
        public void FindAll_in_EmptyList()
        {
            LinkedList testList = new LinkedList();

            List<Node> results = testList.FindAll(3);

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod()]
        public void FindAll_Exist_Nodes()
        {
            LinkedList testList = new LinkedList();

            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(3));
            List<Node> results = testList.FindAll(3);
            int expected = 4;
            int actual = results.Count;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void FindAll_Not_Exist_Values()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(4));

            List<Node> results = testList.FindAll(3);

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod()]
        public void Count_EmptyList()
        {
            LinkedList testList = new LinkedList();
            int expected = 0;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Count_List_with_One_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            int expected = 1;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Count_after_multiply_manipulations_with_List()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.InsertAfter(new Node(1), new Node(19));
            testList.AddInTail(new Node(4));
            testList.Remove(0);

            int expected = 6;
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InsertAfter_in_EmptyList()
        {
            LinkedList testList = new LinkedList();

            testList.InsertAfter(new Node(0), new Node(205));

            int expected = 0;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InsertAfter_after_Head()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.InsertAfter(new Node(200), new Node(201));

            int expected = 2;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InsertAfter_after_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddInTail(new Node(201));
            testList.AddInTail(new Node(202));
            testList.AddInTail(new Node(203));
            testList.AddInTail(new Node(204));
            testList.InsertAfter(new Node(204), new Node(205));

            int expected = 6;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InsertAfter_nor_Head_nor_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddInTail(new Node(201));
            testList.AddInTail(new Node(202));
            testList.AddInTail(new Node(203));
            testList.AddInTail(new Node(204));
            testList.InsertAfter(new Node(202), new Node(2018));

            int expected = 6;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InsertAfter_after_nonexist_Node_Value()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddInTail(new Node(201));
            testList.AddInTail(new Node(202));
            testList.AddInTail(new Node(203));
            testList.AddInTail(new Node(204));
            testList.InsertAfter(new Node(2018), new Node(205));

            int expected = 5;
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
        }
    }
}