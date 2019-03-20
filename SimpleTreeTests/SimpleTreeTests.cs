using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass()]
    public class SimpleTreeTests
    {
        [TestMethod()]
        public void AddChild_if_Tree_has_Two_Direct_Descendants()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            int expected = 1;
            int actual1 = testTree.Count();

            Assert.AreEqual(expected, actual1);

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));

            Console.WriteLine("LOG\t Roots\' Children: {0}", testTree.Root.Children.Count);

            int actual2 = testTree.Count();
            int expected2 = 3;

            Assert.AreEqual(expected2, actual2);

            List<SimpleTreeNode<int>> list = testTree.GetAllNodes();

            foreach (SimpleTreeNode<int> node in list)
            {
                Console.WriteLine("Current Node Value:\t{0}\nParrent Node:\t{1}", node.NodeValue, (node.Parent == null) ? -9999 : node.Parent.NodeValue);

                for (int i = 0; node.Children != null && i < node.Children.Count; i++)
                {
                    Console.WriteLine("SubNode:\t{0} ", node.Children[i].NodeValue);
                    if (node.Children[i].Children == null)
                        Console.WriteLine("Does not have children.\n");
                }
                Console.WriteLine();
            }
        }

        [TestMethod()]
        public void Get_All_Nodes()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(0, null));

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();
            int expected = 1;
            int actual = testTree.Count();
            Assert.AreEqual(expected, actual);

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(1, null));
            nodes = testTree.GetAllNodes();
            Assert.IsTrue(nodes.Count == 2);

            foreach (SimpleTreeNode<int> node in nodes)
            {
                Console.WriteLine("Parrent:\t{0}\nValue:\t{1}", (node.Parent == null) ? -9999 : node.Parent.NodeValue, node.NodeValue);

                for (int i = 0; node.Children != null && i < node.Children.Count; i++)
                    Console.WriteLine("Children {0} ", node.Children[i].NodeValue);
                Console.WriteLine();
            }
        }

        [TestMethod()]
        public void Get_All_Nodes_in__3_level_Tree()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            for (int i = 2; i < 11; i++)
            {
                if (i < 5)
                    testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(i, null));
                else if (i < 7)
                    testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(i, null));
                else if (i == 7)
                    testTree.AddChild(testTree.Root.Children[1], new SimpleTreeNode<int>(i, null));
                else
                    testTree.AddChild(testTree.Root.Children[2], new SimpleTreeNode<int>(i, null));
            }

            Console.WriteLine("=========Log==========");
            Console.Write("Корень: {0}", testTree.Root.NodeValue);
            Console.Write("\t Узлов: {0}", testTree.Count());
            Console.WriteLine("\t Листьев: {0}", testTree.LeafCount());

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();

            foreach (SimpleTreeNode<int> node in nodes)
            {
                Console.WriteLine("Current Node Value:\t{0}\nParrent Node:\t{1}", node.NodeValue, (node.Parent == null) ? -9999 : node.Parent.NodeValue);

                for (int i = 0; node.Children != null && i < node.Children.Count; i++)
                {
                    Console.WriteLine("SubNode:\t{0} ", node.Children[i].NodeValue);
                    if (node.Children[i].Children == null)
                        Console.WriteLine("Does not have children.\n");
                }
                Console.WriteLine();
            }

            int expectedNodes = 10;
            int actualNodes = testTree.Count();
            Assert.AreEqual(expectedNodes, actualNodes);

            int expectedLeafs = 6;
            int leafs = testTree.LeafCount();
            Assert.AreEqual(expectedLeafs, leafs);
        }

        [TestMethod()]
        public void Get_All_Nodes_in_3_level_Tree_One_Child()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(4, null));
            testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(5, null));
            testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(6, null));

            Console.WriteLine("=========Log==========");
            Console.Write("Корень: {0}", testTree.Root.NodeValue);
            Console.Write("\t Узлов: {0}", testTree.Count());
            Console.WriteLine("\t Листьев: {0}", testTree.LeafCount());

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();

            foreach (SimpleTreeNode<int> node in nodes)
            {
                Console.WriteLine("Current Node Value:\t{0}\nParrent Node:\t{1}", node.NodeValue, (node.Parent == null) ? -9999 : node.Parent.NodeValue);

                for (int i = 0; node.Children != null && i < node.Children.Count; i++)
                {
                    Console.WriteLine("SubNode:\t{0} ", node.Children[i].NodeValue);
                    if (node.Children[i].Children == null)
                        Console.WriteLine("Does not have children.\n");
                }
                Console.WriteLine();
            }

            int expectedNodes = 6;
            int actualNodes = testTree.Count();
            Assert.AreEqual(expectedNodes, actualNodes);

            int expectedLeafs = 4;
            int leafs = testTree.LeafCount();
            Assert.AreEqual(expectedLeafs, leafs);
        }

    }
}