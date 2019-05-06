using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dequeue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dequeue.Tests
{
    [TestClass()]
    public class DequeTests
    {
        [TestMethod()]
        public void AddFront_if_Empty()
        {
            Deque<int> testDeq = new Deque<int>();
            testDeq.AddFront(0);

            int expected = 1;
            int actual = testDeq.Size();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTailTest()
        {
            Deque<int> testDeq = new Deque<int>();
            testDeq.AddFront(0);
            testDeq.AddFront(1);
            testDeq.AddTail(2);
        
            int expectedLength = 3;
            int actualLength = testDeq.Size();

            Assert.AreEqual(expectedLength, actualLength);

            int actualRemovedValue = testDeq.RemoveTail();
            int expectedValue = 2;

            Assert.AreEqual(expectedValue, actualRemovedValue);
        }

        [TestMethod()]
        public void RemoveFrontTest()
        {
            Deque<int> testDeq = new Deque<int>();
            testDeq.AddFront(1);
            testDeq.AddFront(0);

            int expectedLength = 2;
            int actualLength = testDeq.Size();
            Assert.AreEqual(expectedLength, actualLength);

            int actualRemovedValue = testDeq.RemoveFront();
            int expectedValue = 0;

            Assert.AreEqual(expectedValue, actualRemovedValue);
        }

        [TestMethod()]
        public void RemoveTailTest()
        {
            Deque<int> testDeq = new Deque<int>();
            testDeq.AddFront(2);
            testDeq.AddFront(1);
            testDeq.AddFront(0);
            testDeq.AddTail(3);

            int expectedLength = 4;
            int actualLength = testDeq.Size();

            Assert.AreEqual(expectedLength, actualLength);

            int actualRemovedTail = testDeq.RemoveTail();
            int expectedTail = 3;

            Assert.AreEqual(expectedTail, actualRemovedTail);
        }
    }
}