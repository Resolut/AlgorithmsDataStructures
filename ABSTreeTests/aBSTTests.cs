using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass()]
    public class aBSTTests
    {
        [TestMethod()]
        public void FindKeyIndex_If_Tree_is_Empty()
        {
            aBST testTree = new aBST(3);
            int? Slot = testTree.FindKeyIndex(4);
            int? expectedSlot = 0;
            Assert.IsTrue(testTree.Tree.Length == 7);
            Assert.AreEqual(expectedSlot, Slot);
        }

        [TestMethod()]
        public void FindKeyIndex_If_Tree_Has_Tree_Only()
        {
            aBST testTree = new aBST(3);
            int index = testTree.AddKey(4);
            int? index2 = testTree.FindKeyIndex(2);
            int expectedIndex = 0;
            int? expectedIndex2 = -1;

            Assert.IsTrue(testTree.Tree.Length == 7);
            Assert.IsTrue(testTree.Tree[0] == 4);
            Assert.IsTrue(testTree.Tree[1] == null);
            Assert.AreEqual(expectedIndex, index);
            Assert.AreEqual(expectedIndex2, index2);
        }

        [TestMethod()]
        public void AddKey_If_Tree_is_Empty()
        {
            aBST testTree = new aBST(3);
            int index = testTree.AddKey(4);
            int expectedIndex = 0;
            Assert.IsTrue(testTree.Tree.Length == 7);
            Assert.IsTrue(testTree.Tree[0] == 4);
            Assert.AreEqual(expectedIndex, index);
        }

        [TestMethod()]
        public void AddKey_If_Tree_Has_Tree_Only()
        {
            aBST testTree = new aBST(3);
            int index = testTree.AddKey(4);
            int index2 = testTree.AddKey(2);
            int index3 = testTree.AddKey(6);
            int expectedIndex = 0;
            int? expectedIndex2 = 1;
            int? expectedIndex3 = 2;

            Assert.IsTrue(testTree.Tree.Length == 7);
            Assert.IsTrue(testTree.Tree[0] == 4);
            Assert.IsTrue(testTree.Tree[1] == 2);
            Assert.IsTrue(testTree.Tree[2] == 6);
            Assert.AreEqual(expectedIndex, index);
            Assert.AreEqual(expectedIndex2, index2);
            Assert.AreEqual(expectedIndex3, index3);
        }
    }
}