using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        [TestMethod()]
        public void RemoveNodeTest()
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));

            int expectedLength = 2;

            testList.RemoveNode(3);
            int actual = testList.GetLength();

            Assert.AreEqual(expectedLength, actual);
        }
    }
}