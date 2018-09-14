using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass()]
    public class LinkedListTests
    {

        [TestMethod()]
        public void RemoveNode_nor_Head_nor_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));

            int expectedLength = 3;

            testList.RemoveNode(2);
            int actual = testList.GetLength();

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

            testList.RemoveNode(1);
            int actual = testList.GetLength();

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

            testList.RemoveNode(3);
            int actual = testList.GetLength();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void RemoveNode_from_Null_List()
        {
            LinkedList testList = new LinkedList();
            int expectedLength = 0;
            testList.RemoveNode(3);
            int actual = testList.GetLength();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void RemoveNode_from_List_with_One_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(3));
            int expectedLength = 0;
            testList.RemoveNode(3);
            int actual = testList.GetLength();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void AddInTail_in_EmptyList()
        {
            LinkedList testList = new LinkedList();
            int expectedLength = 1;
            testList.AddInTail(new Node(4));
            int actual = testList.GetLength();

            Assert.AreEqual(expectedLength, actual);
        }

        [TestMethod()]
        public void AddInTail_in_List_with_One_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            int expectedLength = 2;
            testList.AddInTail(new Node(2));
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

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
            int actual = testList.GetLength();

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

            Assert.IsTrue(testList.GetLength() == 0);
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

            Assert.IsTrue(testList.GetLength() == 0);
        }

        [TestMethod()]
        public void Clear_EmptyList()
        {
            LinkedList testList = new LinkedList();

            testList.Clear();

            Assert.IsTrue(testList.GetLength() == 0);
        }

        [TestMethod()]
        public void FindAll_in_EmptyList()
        {
            LinkedList testList = new LinkedList();

            LinkedList results = testList.FindAll(3);

            Assert.IsTrue(results.GetLength() == 0);
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
            LinkedList results = testList.FindAll(3);
            int expected = 4;
            int actual = results.GetLength();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void FindAll_Not_Exist_Values()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(4));

            LinkedList results = testList.FindAll(3);

            Assert.IsTrue(results.GetLength() == 0);
        }

        [TestMethod()]
        public void GetLength_EmptyList()
        {
            LinkedList testList = new LinkedList();
            int expected = 0;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetLength_List_with_One_Node()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            int expected = 1;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetLength_after_multiply_manipulations_with_List()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(0));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddNode(new Node(19), 1);
            testList.AddInTail(new Node(4));
            testList.RemoveNode(0);

            int expected = 6;
            int actual = testList.GetLength();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNode_in_EmptyList()
        {
            LinkedList testList = new LinkedList();

            testList.AddNode(new Node(205), 0);

            int expected = 0;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNode_after_Head()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddNode(new Node(201), 200);

            int expected = 2;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNode_after_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddInTail(new Node(201));
            testList.AddInTail(new Node(202));
            testList.AddInTail(new Node(203));
            testList.AddInTail(new Node(204));
            testList.AddNode(new Node(205), 204);

            int expected = 6;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNode_nor_Head_nor_Tail()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddInTail(new Node(201));
            testList.AddInTail(new Node(202));
            testList.AddInTail(new Node(203));
            testList.AddInTail(new Node(204));
            testList.AddNode(new Node(2018), 202);

            int expected = 6;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNode_after_nonexist_Node_Value()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(200));
            testList.AddInTail(new Node(201));
            testList.AddInTail(new Node(202));
            testList.AddInTail(new Node(203));
            testList.AddInTail(new Node(204));
            testList.AddNode(new Node(205), 2018);

            int expected = 5;
            int actual = testList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReduceLinkedLists_with_Equal_Lengths_ ()
        {
            LinkedList testListOne = new LinkedList();

            testListOne.AddInTail(new Node(200));
            testListOne.AddInTail(new Node(201));
            testListOne.AddInTail(new Node(202));
            testListOne.AddInTail(new Node(203));
            testListOne.AddInTail(new Node(204));
            
            LinkedList testListTwo = new LinkedList();

            testListTwo.AddInTail(new Node(100));
            testListTwo.AddInTail(new Node(101));
            testListTwo.AddInTail(new Node(102));
            testListTwo.AddInTail(new Node(103));
            testListTwo.AddInTail(new Node(104));

            LinkedList expectedResults = new LinkedList();
            for (int i = 0; i < 5; i++)
            {
                expectedResults.AddInTail(new Node(300 + i * 2));
            }

            LinkedList actualResults = LinkedList.ReduceLinkedLists(testListOne, testListTwo);

            Assert.IsTrue(expectedResults.PrintList() == actualResults.PrintList());
        }

        [TestMethod()]
        public void ReduceLinkedLists_with_Different_Lengths_()
        {
            LinkedList testListOne = new LinkedList();

            testListOne.AddInTail(new Node(200));
            testListOne.AddInTail(new Node(201));
            testListOne.AddInTail(new Node(202));
            testListOne.AddInTail(new Node(203));
            testListOne.AddInTail(new Node(204));

            LinkedList testListTwo = new LinkedList();

            testListTwo.AddInTail(new Node(100));
            testListTwo.AddInTail(new Node(101));
            testListTwo.AddInTail(new Node(102));
            testListTwo.AddInTail(new Node(103));

            LinkedList expectedResults = new LinkedList();
            LinkedList actualResults = LinkedList.ReduceLinkedLists(testListOne, testListTwo);

            Assert.AreEqual(expectedResults.GetLength(), actualResults.GetLength());
        }
    }
}