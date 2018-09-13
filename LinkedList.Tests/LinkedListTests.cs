using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void DeleteNodeWithValue(LinkedList testList, int value)
        {
            LinkedList actualList = testList;
            actualList.RemoveNode(23);
            actualList.PrintList();
        }
    }
}
