using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stack.Tests
{
    [TestClass()]
    public class StackTests
    {
        [TestMethod()]
        public void Size_if_Stack_is_Empty()
        {
            Stack testStack = new Stack();

            Assert.IsTrue(testStack.Size() == 0);
        }

        [TestMethod()]
        public void Size_if_Stack_has_Items()
        {
            Stack testStack = new Stack();

            testStack.Push(new Node(1));
            testStack.Push(new Node(2));

            Assert.IsTrue(testStack.Size() == 2);
        }

        [TestMethod()]
        public void Push_if_Stack_is_Empty()
        {
            Stack testStack = new Stack();

            for (int i = 0; i < 20; i++)
            {
                testStack.Push(new Node(i));
            }

            Assert.IsTrue(testStack.Size() == 20);
        }

        [TestMethod()]
        public void Pop_if_Stack_is_Empty()
        {
            Stack testStack = new Stack();
            Node deletedNode = testStack.Pop();

            Assert.IsNull(deletedNode);
            Assert.IsTrue(testStack.Size() == 0);
        }

        [TestMethod()]
        public void Pop_2Items_if_Stack_has_Items()
        {
            Stack testStack = new Stack();

            for (int i = 0; i < 10; i++)
            {
                testStack.Push(new Node(i));
            }

            Node deletedNode = testStack.Pop();
            Node deletedNode2 = testStack.Pop();
            int expectedLength = 8;
            int actualLength = testStack.Size();

            Assert.IsTrue(deletedNode.value == 9);
            Assert.IsTrue(deletedNode2.value == 8);
            Assert.AreEqual(expectedLength, actualLength);
        }

        [TestMethod()]
        public void Peek_if_Stack_is_Empty()
        {
            Stack testStack = new Stack();
            Node peekedNode = testStack.Peek();

            Assert.IsNull(peekedNode);
            Assert.IsTrue(testStack.Size() == 0);
        }

        [TestMethod()]
        public void Peek_if_Stack_has_Items()
        {
            Stack testStack = new Stack();

            for (int i = 0; i < 10; i++)
            {
                testStack.Push(new Node(i));
            }

            Node peekedNode = testStack.Peek();
            int expectedSize = 10;
            int actualSize = testStack.Size();

            Assert.IsTrue(peekedNode.value == 9);
            Assert.AreEqual(expectedSize, actualSize);
        }
    }
}