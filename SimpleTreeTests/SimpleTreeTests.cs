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
    public class SimpleTreeTests
    {
        [TestMethod()]
        public void AddChild_if_Tree_has_root_only()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(0, null));

            int count = testTree.Count();

            Console.WriteLine(count);
            Assert.IsTrue(count == 1);

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(1, null));
            Assert.IsNotNull(testTree.Root.Children);
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null));
            int actual = testTree.Count();
            Assert.IsTrue(actual == 2);

            List<SimpleTreeNode<int>> list = testTree.GetAllNodes();
            for (int i = 0; i<list.Count ;i++)
            {
                Console.WriteLine(list[i].NodeValue); 
            }
        }

        [TestMethod()]
        public void Get_All_Nodes()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(0, null));

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();

            Assert.IsTrue(nodes.Count == 1);

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(1, null));
            nodes = testTree.GetAllNodes();
            Assert.IsTrue(nodes.Count == 2);
        }
    }
}