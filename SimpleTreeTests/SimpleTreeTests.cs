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


        [TestMethod()]
        public void Get_Lists_All_Nodes_and_FoundNodes()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(4, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(5, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(6, null));

            List<SimpleTreeNode<int>> foundtList = testTree.FindNodesByValue(4);

            foreach (var item in foundtList)
            {
                Console.WriteLine("item = {0}", item.NodeValue);
            }
            Assert.IsTrue(foundtList.Count == 1);
            Assert.IsTrue(testTree.Count() == 6);
        }

        [TestMethod()]
        public void Get_FoundNodes_If_Duplicates_Exists()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null)); // узлы первого уровня
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(4, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(5, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(6, null));

            testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(7, null)); // узлы второго уровня
            testTree.AddChild(testTree.Root.Children[1], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[2], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[4], new SimpleTreeNode<int>(8, null));

            testTree.AddChild(testTree.Root.Children[4].Children[0], new SimpleTreeNode<int>(7, null)); // узлы третьего уровня

            List<SimpleTreeNode<int>> foundtList = testTree.FindNodesByValue(7); // Список найденных узлов

            foreach (var item in foundtList)
            {
                Console.WriteLine("item = {0}", item.NodeValue);
            }

            int expectedCount = 11;
            int expectedLeafs = 5;
            int expectedFoundNodes = 4;

            int actualCount = testTree.Count();
            int actualLeafs = testTree.LeafCount();
            int actualFoundNodes = foundtList.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedLeafs, actualLeafs);
            Assert.AreEqual(expectedFoundNodes, actualFoundNodes);
        }

        [TestMethod()]
        public void FindNodesByValue_If_TargetNode_Is_not_Exists()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null)); // узлы первого уровня
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(4, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(5, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(6, null));

            testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(7, null)); // узлы второго уровня
            testTree.AddChild(testTree.Root.Children[1], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[2], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[4], new SimpleTreeNode<int>(8, null));

            testTree.AddChild(testTree.Root.Children[4].Children[0], new SimpleTreeNode<int>(7, null)); // узлы третьего уровня

            List<SimpleTreeNode<int>> foundList = testTree.FindNodesByValue(12); // Список найденных узлов

            int expectedCount = 11;
            int expectedLeafs = 5;

            int actualCount = testTree.Count();
            int actualLeafs = testTree.LeafCount();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedLeafs, actualLeafs);
            Assert.IsNull(foundList);
        }

        [TestMethod()]
        public void DeleteNode_If_Node_Exists()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null)); // узлы первого уровня
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(4, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(5, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(6, null));

            testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(7, null)); // узлы второго уровня
            testTree.AddChild(testTree.Root.Children[1], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[2], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[4], new SimpleTreeNode<int>(8, null));

            testTree.AddChild(testTree.Root.Children[4].Children[0], new SimpleTreeNode<int>(7, null)); // узлы третьего уровня

            int beforeDelNodesCount = 11;
            int beforeDelLeafs = 5;

            int actualNodesCount = testTree.Count();
            int actualLeafs = testTree.LeafCount();

            Assert.AreEqual(beforeDelNodesCount, actualNodesCount);
            Assert.AreEqual(beforeDelLeafs, actualLeafs);

            testTree.DeleteNode(testTree.Root.Children[3]); // удаление листа со значением "5"

            int afterDelNodesCount = 10;
            int afterDelLeafs = 4;

            int actualAfterDelNodesCount = testTree.Count();
            int actualAfterDelLeafs = testTree.LeafCount();

            Assert.AreEqual(afterDelNodesCount, actualAfterDelNodesCount);
            Assert.AreEqual(afterDelLeafs, actualAfterDelLeafs);
            Assert.IsNull(testTree.FindNodesByValue(5));
            Assert.IsTrue(testTree.Root.Children.Count == 4);

            testTree.DeleteNode(testTree.Root.Children[2].Children[0]); // удаление вначале потомка-листа ("7"), затем его родительского узла ("4")
            testTree.DeleteNode(testTree.Root.Children[2]);

            Assert.IsNull(testTree.FindNodesByValue(4));
            Assert.IsTrue(testTree.LeafCount() == 3);
            Assert.IsTrue(testTree.Count() == 8);

            Console.WriteLine("=========Log==========");
            Console.WriteLine("Корень: {0}", testTree.Root.NodeValue);
            Console.WriteLine("Всего Узлов: {0}", testTree.Count());
            Console.WriteLine("Всего Листьев: {0}", testTree.LeafCount());

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();

            foreach (SimpleTreeNode<int> node in nodes)
            {
                Console.WriteLine("Current Node Value:\t{0}\nParrent Node:\t{1}", node.NodeValue, (node.Parent == null) ? -9999 : node.Parent.NodeValue);

                for (int i = 0; node.Children != null && i < node.Children.Count; i++)
                {
                    Console.Write("SubNode:\t{0} ", node.Children[i].NodeValue);
                    if (node.Children[i].Children == null)
                        Console.WriteLine(" - Has not children");
                    else
                        Console.WriteLine(" - Has children");
                }
                Console.WriteLine();
            }
        }

        [TestMethod()]
        public void DeleteNode_If_Node_IS_NOT_Exists()
        {
            SimpleTree<int> testTree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(2, null)); // узлы первого уровня
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(3, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(4, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(5, null));
            testTree.AddChild(testTree.Root, new SimpleTreeNode<int>(6, null));

            testTree.AddChild(testTree.Root.Children[0], new SimpleTreeNode<int>(7, null)); // узлы второго уровня
            testTree.AddChild(testTree.Root.Children[1], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[2], new SimpleTreeNode<int>(7, null));
            testTree.AddChild(testTree.Root.Children[4], new SimpleTreeNode<int>(8, null));

            testTree.AddChild(testTree.Root.Children[4].Children[0], new SimpleTreeNode<int>(7, null)); // узлы третьего уровня

            int beforeDelNodesCount = 11;
            int beforeDelLeafs = 5;

            int actualNodesCount = testTree.Count();
            int actualLeafs = testTree.LeafCount();

            Assert.AreEqual(beforeDelNodesCount, actualNodesCount);
            Assert.AreEqual(beforeDelLeafs, actualLeafs);

            testTree.DeleteNode(new SimpleTreeNode<int>(7, testTree.Root.Children[4].Children[0])); // попытка удаления псевдо-листа со значением "7"

            int afterDelNodesCount = 11;
            int afterDelLeafs = 5;

            int actualAfterDelNodesCount = testTree.Count();
            int actualAfterDelLeafs = testTree.LeafCount();

            Console.WriteLine("=========Log==========");
            Console.WriteLine("Всего Узлов: {0}", testTree.Count());
            Console.WriteLine("Всего Листьев: {0}\n", testTree.LeafCount());

            List<SimpleTreeNode<int>> nodes = testTree.GetAllNodes();

            foreach (SimpleTreeNode<int> node in nodes)
            {
                if (node == testTree.Root)
                    Console.WriteLine("Корень дерева:\t{0}\nРодитель: -", node.NodeValue);
                else
                    Console.WriteLine("Текущий узел:\t{0}\nРодитель:\t{1}", node.NodeValue, node.Parent.NodeValue);

                Console.Write("Потомки:");
                for (int i = 0; node.Children != null && i < node.Children.Count; i++)
                {
                    Console.Write(" [{0} ", node.Children[i].NodeValue);
                    if (node.Children[i].Children == null)
                        Console.Write(" - нет своих потомков; ]");
                    else
                        Console.Write(" - Есть свои потомки; ]");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Assert.AreEqual(afterDelNodesCount, actualAfterDelNodesCount);
            Assert.IsTrue(testTree.Root.Children[4].Children[0].Children.Count == 1);
            Assert.AreEqual(afterDelLeafs, actualAfterDelLeafs);

        }
    }
}