using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass()]
    public class BalancedBSTTests
    {
        [TestMethod()]
        public void IsBalancedTest()
        {
            BalancedBST bsTree = new BalancedBST();
            bsTree.Root = new BSTNode(8, null);
            bsTree.Root.Level = 1;

            bsTree.Root.LeftChild = new BSTNode(4, bsTree.Root); // потомки корня 
            bsTree.Root.LeftChild.Level = 2;
            bsTree.Root.RightChild = new BSTNode(12, bsTree.Root);
            bsTree.Root.RightChild.Level = 2;

            bsTree.Root.LeftChild.LeftChild = new BSTNode(2, bsTree.Root.LeftChild); // узел 3 уровня
            bsTree.Root.LeftChild.LeftChild.Level = 3;

            bsTree.Root.LeftChild.LeftChild.RightChild = new BSTNode(3, bsTree.Root.LeftChild.LeftChild); // узел 4 уровня
            bsTree.Root.LeftChild.LeftChild.RightChild.Level = 4;

            Assert.IsFalse(bsTree.IsBalanced(bsTree.Root));
        }
    }
}