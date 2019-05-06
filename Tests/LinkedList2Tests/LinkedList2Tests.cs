using LinkedList2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinkedList2.Tests
{
    [TestClass()]
    public class LinkedList2Tests
    {
        [TestMethod()]
        public void Remove_from_EmptyList()
        {

            LinkedList2 testList = new LinkedList2();
            int expected = 0;
            testList.Remove(5);
            int actual = testList.Count();

            Assert.IsNull(testList.head);
            Assert.IsNull(testList.tail);
            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(5));
        }

        [TestMethod()]
        public void Remove_from_Head()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            int expected = 3;
            testList.Remove(5);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(5));
        }

        [TestMethod()]
        public void Remove_from_Tail()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            int expected = 3;
            testList.Remove(3);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(3));
        }

        [TestMethod()]
        public void Remove_nor_Head_nor_Tail()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            int expected = 5;
            testList.Remove(5);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(5));
        }

        [TestMethod()]
        public void Remove_if_more_One_Exists()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            int expected = 6;
            testList.Remove(5);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testList.FindAll(5).Count >= 1);
        }

        [TestMethod()]
        public void Remove_nonExist()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            int expected = 6;
            testList.Remove(19);
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(19));
        }

        [TestMethod()]
        public void AddInHead_in_NotEmptyList()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            int expected = 6;
            testList.AddInHead(new Node(19));
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(testList.Find(19));
        }

        [TestMethod]
        public void AddInHead_in_EmptyList()
        {
            LinkedList2 testList = new LinkedList2();
            testList.AddInHead(new Node(21));

            int expected = 1;
            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(testList.Find(21));

        }

        [TestMethod()]
        public void AddInHead_if_List_Is_Contain_the_Same_NodeValue()
        {
            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(4));
            testList.AddInHead(new Node(4));
            int expected = 7;
            int actual = testList.Count();


            List<Node> resultsList = testList.FindAll(4);

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testList.FindAll(4).Count == 5);
        }

        [TestMethod()]
        public void AddNodeTest()
        {
            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(6));
            testList.AddInHead(new Node(7));
            int expected = 8;
            testList.InsertAfter(new Node(6), new Node(21));
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testList.Find(21).value == 21);
        }

        [TestMethod()]
        public void AddNode_in_Tail()
        {
            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            int expected = 6;
            testList.InsertAfter(new Node(5), new Node(21));
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testList.Find(21).value == 21);
        }

        [TestMethod()]
        public void AddNode_if_Target_non_Exists()
        {
            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            int expected = 5;
            testList.InsertAfter(new Node(13), new Node(21));
            int actual = testList.Count();
            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(21));
        }
    }
}