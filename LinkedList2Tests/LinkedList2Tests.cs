using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList2.Tests
{
    [TestClass()]
    public class LinkedList2Tests
    {
        [TestMethod()]
        public void RemoveNode_from_EmptyList()
        {

            LinkedList2 testList = new LinkedList2();
            int expected = 0;
            testList.RemoveNode(5);
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(5));
        }

        [TestMethod()]
        public void RemoveNode_from_Head()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            int expected = 3;
            testList.RemoveNode(5);
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(5));
        }

        [TestMethod()]
        public void RemoveNode_from_Tail()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            int expected = 3;
            testList.RemoveNode(3);
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(3));
        }

        [TestMethod()]
        public void RemoveNode_nor_Head_nor_Tail()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            int expected = 5;
            testList.RemoveNode(5);
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
            Assert.IsNull(testList.Find(5));
        }

        [TestMethod()]
        public void RemoveNode_if_more_One_Exists()
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
            testList.RemoveNode(5);
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testList.FindAll(5).GetLength() >= 1);
        }

        [TestMethod()]
        public void RemoveNode_nonExist()
        {

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            int expected = 6;
            testList.RemoveNode(19);
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(testList.Find(19));
        }

        [TestMethod]
        public void AddInHead_in_EmptyList()
        {
            LinkedList2 testList = new LinkedList2();
            testList.AddInHead(new Node(21));

            int expected = 1;
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

           
            LinkedList2 resultsList = testList.FindAll(4);
            
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(testList.FindAll(4).GetLength() == 5);
        }
    }
}