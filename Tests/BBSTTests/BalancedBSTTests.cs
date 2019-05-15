using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass()]
    public class BalancedBSTTests
    {
        [TestMethod()]
        public void IsBalanced_If_Tree_Has_Root_Only()
        {
            BalancedBST bsTree = new BalancedBST();
            bsTree.Root = new BSTNode(8, null);
            bsTree.Root.Level = 1;

            Assert.IsTrue(bsTree.IsBalanced(bsTree.Root));
        }

        [TestMethod()]
        public void IsBalanced_if_4_level_on_Left_SubTree_2_Level_on_Right_SubTree()
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

        [TestMethod()]
        public void IsBalanced_if_4_level_on_Left_SubTree_3_Level_on_Right_SubTree()
        {
            BalancedBST bsTree = new BalancedBST();
            bsTree.Root = new BSTNode(8, null);
            bsTree.Root.Level = 1;

            bsTree.Root.LeftChild = new BSTNode(4, bsTree.Root); // левый потомок корня 
            bsTree.Root.LeftChild.Level = 2;
            bsTree.Root.RightChild = new BSTNode(12, bsTree.Root); // правый потомок корня
            bsTree.Root.RightChild.Level = 2;

            bsTree.Root.LeftChild.LeftChild = new BSTNode(2, bsTree.Root.LeftChild); // узел 3 уровня 
            bsTree.Root.LeftChild.LeftChild.Level = 3;
            bsTree.Root.RightChild.RightChild = new BSTNode(13, bsTree.Root.LeftChild); // узел 3 уровня
            bsTree.Root.RightChild.RightChild.Level = 3;

            bsTree.Root.LeftChild.LeftChild.RightChild = new BSTNode(3, bsTree.Root.LeftChild.LeftChild); // узел 4 уровня
            bsTree.Root.LeftChild.LeftChild.RightChild.Level = 4;

            Assert.IsTrue(bsTree.IsBalanced(bsTree.Root));
        }

        [TestMethod()]
        public void IsBalanced_if_3_level_on_Left_SubTree_and_Right_SubTree()
        {
            BalancedBST bsTree = new BalancedBST();
            bsTree.Root = new BSTNode(8, null);
            bsTree.Root.Level = 1;

            bsTree.Root.LeftChild = new BSTNode(4, bsTree.Root); // левый потомок корня 
            bsTree.Root.LeftChild.Level = 2;
            bsTree.Root.RightChild = new BSTNode(12, bsTree.Root); // правый потомок корня
            bsTree.Root.RightChild.Level = 2;

            bsTree.Root.LeftChild.LeftChild = new BSTNode(2, bsTree.Root.LeftChild); // узел 3 уровня 
            bsTree.Root.LeftChild.LeftChild.Level = 3;
            bsTree.Root.RightChild.RightChild = new BSTNode(13, bsTree.Root.LeftChild); // узел 3 уровня
            bsTree.Root.RightChild.RightChild.Level = 3;

            Assert.IsTrue(bsTree.IsBalanced(bsTree.Root));
        }
    }
}