using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            int? expectedSlot = null;

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

        [TestMethod()]
        public void AddKey_If_3_Level_Tree_Is_Full()
        {
            aBST testTree = new aBST(3);
            int index = testTree.AddKey(4);
            int index2 = testTree.AddKey(2);
            int index3 = testTree.AddKey(6);
            int index4 = testTree.AddKey(1);
            int index5 = testTree.AddKey(3);
            int index6 = testTree.AddKey(5);
            int index7 = testTree.AddKey(7);

            int indexFull = testTree.AddKey(9);

            int expectedIndex = 0;
            int expectedIndex2 = 1;
            int expectedIndex3 = 2;
            int expectedIndex4 = 3;
            int expectedIndex5 = 4;
            int expectedIndex6 = 5;
            int expectedIndex7 = 6;

            int expectedIndexFull = -1;

            Assert.IsTrue(testTree.Tree.Length == 7);
            Assert.IsTrue(testTree.Tree[0] == 4);
            Assert.IsTrue(testTree.Tree[1] == 2);
            Assert.IsTrue(testTree.Tree[2] == 6);
            Assert.IsTrue(testTree.Tree[3] == 1);
            Assert.IsTrue(testTree.Tree[4] == 3);
            Assert.IsTrue(testTree.Tree[5] == 5);
            Assert.IsTrue(testTree.Tree[6] == 7);
    
            Assert.AreEqual(expectedIndex, index);
            Assert.AreEqual(expectedIndex2, index2);
            Assert.AreEqual(expectedIndex3, index3);
            Assert.AreEqual(expectedIndex4, index4);
            Assert.AreEqual(expectedIndex5, index5);
            Assert.AreEqual(expectedIndex6, index6);
            Assert.AreEqual(expectedIndex7, index7);
            Assert.AreEqual(expectedIndexFull, indexFull);
        }

        [TestMethod()]
        public void AddKey_If_4_Level_Tree_Is_Full()
        {
            aBST testTree = new aBST(4);
            int index1 = testTree.AddKey(8);
            int index2 = testTree.AddKey(4);
            int index3 = testTree.AddKey(12);
            int index4 = testTree.AddKey(2);
            int index5 = testTree.AddKey(6);
            int index6 = testTree.AddKey(10);
            int index7 = testTree.AddKey(14);
            int index8 = testTree.AddKey(1);
            int index9 = testTree.AddKey(3);
            int index10 = testTree.AddKey(5);
            int index11 = testTree.AddKey(7);
            int index12 = testTree.AddKey(9);
            int index13 = testTree.AddKey(11);
            int index14 = testTree.AddKey(13);
            int index15 = testTree.AddKey(15);

            int indexFull = testTree.AddKey(0);
            int indexDuplicate = testTree.AddKey(7);

            int expectedIndex1 = 0;
            int expectedIndex2 = 1;
            int expectedIndex3 = 2;
            int expectedIndex4 = 3;
            int expectedIndex5 = 4;
            int expectedIndex6 = 5;
            int expectedIndex7 = 6;
            int expectedIndex8 = 7;
            int expectedIndex9 = 8;
            int expectedIndex10 = 9;
            int expectedIndex11 = 10;
            int expectedIndex12 = 11;
            int expectedIndex13 = 12;
            int expectedIndex14 = 13;
            int expectedIndex15 = 14;

            int expectedIndexFull = -1;
            int expectedIndexDuplicate = 10;

            Assert.IsTrue(testTree.Tree.Length == 15);
            Assert.IsTrue(testTree.Tree[0] == 8);
            Assert.IsTrue(testTree.Tree[1] == 4);
            Assert.IsTrue(testTree.Tree[2] == 12);
            Assert.IsTrue(testTree.Tree[3] == 2);
            Assert.IsTrue(testTree.Tree[4] == 6);
            Assert.IsTrue(testTree.Tree[5] == 10);
            Assert.IsTrue(testTree.Tree[6] == 14);
            Assert.IsTrue(testTree.Tree[7] == 1);
            Assert.IsTrue(testTree.Tree[8] == 3);
            Assert.IsTrue(testTree.Tree[9] == 5);
            Assert.IsTrue(testTree.Tree[10] == 7);
            Assert.IsTrue(testTree.Tree[11] == 9);
            Assert.IsTrue(testTree.Tree[12] == 11);
            Assert.IsTrue(testTree.Tree[13] == 13);
            Assert.IsTrue(testTree.Tree[14] == 15);

            Assert.AreEqual(expectedIndex1, index1);
            Assert.AreEqual(expectedIndex2, index2);
            Assert.AreEqual(expectedIndex3, index3);
            Assert.AreEqual(expectedIndex4, index4);
            Assert.AreEqual(expectedIndex5, index5);
            Assert.AreEqual(expectedIndex6, index6);
            Assert.AreEqual(expectedIndex7, index7);
            Assert.AreEqual(expectedIndex8, index8);
            Assert.AreEqual(expectedIndex9, index9);
            Assert.AreEqual(expectedIndex10, index10);
            Assert.AreEqual(expectedIndex11, index11);
            Assert.AreEqual(expectedIndex12, index12);
            Assert.AreEqual(expectedIndex13, index13);
            Assert.AreEqual(expectedIndex14, index14);
            Assert.AreEqual(expectedIndex15, index15);

            Assert.AreEqual(expectedIndexFull, indexFull);
            Assert.AreEqual(expectedIndexDuplicate, indexDuplicate);
        }
    }
}