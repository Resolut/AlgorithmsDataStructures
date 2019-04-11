using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass()]
    public class BSTTests
    {
        [TestMethod()]
        public void FindNodeByKey_If_BST_Has_Root_Only()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(16, "Root", null));
            BSTFind<string> foundNode = testBSTree.FindNodeByKey(16);

            int expectedCount = 1;
            int actualCount = testBSTree.Count();

            Assert.IsNotNull(foundNode.Node);
            Assert.IsTrue(foundNode.NodeHasKey);
            Assert.IsTrue(foundNode.Node.NodeKey == 16);
            Assert.IsTrue(foundNode.Node.NodeValue == "Root");
            Assert.IsNull(foundNode.Node.Parent);
            Assert.IsNull(foundNode.Node.LeftChild);
            Assert.IsNull(foundNode.Node.RightChild);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void FindNodeByKey_If_BST_is_Empty()
        {
            BST<string> testBSTree = new BST<string>(null);
            BSTFind<string> foundNode = testBSTree.FindNodeByKey(16);

            int expectedCount = 0;
            int actualCount = testBSTree.Count();

            Assert.IsNull(foundNode);
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestMethod()]
        public void FindNodeByKey_If_BST_has_3_Nodes()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");

            BSTFind<string> found_1_Left = testBSTree.FindNodeByKey(4);
            BSTFind<string> found_1_Right = testBSTree.FindNodeByKey(12);
            BSTFind<string> found_2_1 = testBSTree.FindNodeByKey(2);
            BSTFind<string> found_2_2 = testBSTree.FindNodeByKey(6);
            BSTFind<string> found_2_3 = testBSTree.FindNodeByKey(10);
            BSTFind<string> found_2_4 = testBSTree.FindNodeByKey(14);

            Assert.IsFalse(found_2_1.NodeHasKey); // проверка, что ключи отсутствуют
            Assert.IsFalse(found_2_2.NodeHasKey);
            Assert.IsFalse(found_2_3.NodeHasKey);
            Assert.IsFalse(found_2_4.NodeHasKey);

            Assert.AreEqual(found_2_1.Node, found_1_Left.Node); // проверка, что правильно выставлен родительский узел
            Assert.AreEqual(found_2_2.Node, found_1_Left.Node); // для вставки нового узла
            Assert.AreEqual(found_2_3.Node, found_1_Right.Node);
            Assert.AreEqual(found_2_4.Node, found_1_Right.Node);

            Assert.IsTrue(found_2_1.ToLeft); // новые узлы будут левыми потомками
            Assert.IsTrue(found_2_3.ToLeft);

            Assert.IsFalse(found_2_2.ToLeft); // новые узлы будут правыми потомками
            Assert.IsFalse(found_2_4.ToLeft);

            Assert.IsTrue(testBSTree.Count() == 3); // проверка, количество узлов после поиска не изменилось
        }

        [TestMethod()]
        public void AddKeyValue_Twice_If_BST_has_Root()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(16, "Root", null));
            BSTFind<string> foundNodeBeforeAdding = testBSTree.FindNodeByKey(8);

            Assert.IsNotNull(foundNodeBeforeAdding);
            Assert.IsFalse(foundNodeBeforeAdding.NodeHasKey);
            Assert.IsTrue(foundNodeBeforeAdding.ToLeft);

            bool isAdded = testBSTree.AddKeyValue(8, "Left Child");
            BSTFind<string> foundNewNode = testBSTree.FindNodeByKey(8);
            BSTFind<string> foundParent = testBSTree.FindNodeByKey(16);

            int expectedCount = 2;
            int actualCount = testBSTree.Count();

            Assert.IsTrue(isAdded);
            Assert.IsTrue(foundNewNode.Node.NodeKey == 8);
            Assert.IsTrue(foundNewNode.Node.NodeValue == "Left Child");
            Assert.IsNull(foundNewNode.Node.LeftChild);
            Assert.IsNull(foundNewNode.Node.RightChild);
            Assert.AreEqual(foundNewNode.Node.Parent, foundParent.Node);
            Assert.AreEqual(expectedCount, actualCount);

            bool isTwoAdded = testBSTree.AddKeyValue(24, "Right Child");


            int afterTwoCount = 3;
            int actualAfterTwoCount = testBSTree.Count();

            Assert.IsTrue(isTwoAdded);
            Assert.AreEqual(afterTwoCount, actualAfterTwoCount);
        }

        [TestMethod()]
        public void AddKeyValue_BST_has_7_Nodes()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 3);

            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");

            Assert.IsTrue(isAdded1);
            Assert.IsTrue(isAdded2);
            Assert.IsTrue(isAdded3);
            Assert.IsTrue(isAdded4);
            Assert.IsTrue(isAdded5);
            Assert.IsTrue(isAdded6);
            Assert.IsTrue(testBSTree.Count() == 7);

            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(8); // находим все добавленные узлы
            BSTFind<string> found_1_Left = testBSTree.FindNodeByKey(4);
            BSTFind<string> found_1_Right = testBSTree.FindNodeByKey(12);
            BSTFind<string> found_2_1_Left = testBSTree.FindNodeByKey(2);
            BSTFind<string> found_2_2_Right = testBSTree.FindNodeByKey(6);
            BSTFind<string> found_2_3_Left = testBSTree.FindNodeByKey(10);
            BSTFind<string> found_2_4_Right = testBSTree.FindNodeByKey(14);

            Assert.IsNull(foundRoot.Node.Parent); // проверка, что корень не имеет родителей

            Assert.AreEqual(foundRoot.Node.LeftChild, found_1_Left.Node); // проверка, что корень и потомки 1го уровня ссылаются друг на друга
            Assert.AreEqual(foundRoot.Node.RightChild, found_1_Right.Node);
            Assert.AreEqual(found_1_Left.Node.Parent, foundRoot.Node);
            Assert.AreEqual(found_1_Right.Node.Parent, foundRoot.Node);

            Assert.AreEqual(found_1_Left.Node.LeftChild, found_2_1_Left.Node);      // проверка, что родители 1 уровня и потомки 2го уровня
            Assert.AreEqual(found_1_Left.Node.RightChild, found_2_2_Right.Node);    // ссылаются друг на друга
            Assert.AreEqual(found_1_Right.Node.LeftChild, found_2_3_Left.Node);
            Assert.AreEqual(found_1_Right.Node.RightChild, found_2_4_Right.Node);
            Assert.AreEqual(found_2_1_Left.Node.Parent, found_1_Left.Node);
            Assert.AreEqual(found_2_2_Right.Node.Parent, found_1_Left.Node);
            Assert.AreEqual(found_2_3_Left.Node.Parent, found_1_Right.Node);
            Assert.AreEqual(found_2_4_Right.Node.Parent, found_1_Right.Node);

            Assert.IsNull(found_2_1_Left.Node.LeftChild); // проверка что потомки 2го уровня являются листьями
            Assert.IsNull(found_2_1_Left.Node.RightChild);
            Assert.IsNull(found_2_2_Right.Node.LeftChild);
            Assert.IsNull(found_2_2_Right.Node.RightChild);
            Assert.IsNull(found_2_3_Left.Node.LeftChild);
            Assert.IsNull(found_2_3_Left.Node.RightChild);
            Assert.IsNull(found_2_4_Right.Node.LeftChild);
            Assert.IsNull(found_2_4_Right.Node.RightChild);
        }

        [TestMethod()]
        public void AddKeyValue_BST_has_15_Nodes()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 3);

            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 7);

            bool isAdded7 = testBSTree.AddKeyValue(1, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(3, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(5, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(7, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(9, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(11, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(13, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(15, "Level_3 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 15);
        }

        [TestMethod()]
        public void AddKeyValue_If_Node_Already_Exists()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");
            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");
            bool isAdded7 = testBSTree.AddKeyValue(6, "Level_2 Right_Child"); // попытка добавления ключа который уже присутствует в дереве

            Assert.IsTrue(isAdded1);
            Assert.IsTrue(isAdded2);
            Assert.IsTrue(isAdded3);
            Assert.IsTrue(isAdded4);
            Assert.IsTrue(isAdded5);
            Assert.IsTrue(isAdded6);

            Assert.IsFalse(isAdded7); // ключ-дубликат не добавлен
            Assert.IsTrue(testBSTree.Count() == 7);
        }

        [TestMethod()]
        public void FinMinMax_in_BST_has_7_Nodes()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");
            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");

            Assert.IsTrue(isAdded1);
            Assert.IsTrue(isAdded2);
            Assert.IsTrue(isAdded3);
            Assert.IsTrue(isAdded4);
            Assert.IsTrue(isAdded5);
            Assert.IsTrue(isAdded6);
            Assert.IsTrue(testBSTree.Count() == 7);

            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(8);

            int expectedMin = 2;
            int expectedMax = 14;

            BSTNode<string> minValue = testBSTree.FinMinMax(foundRoot.Node, false);
            BSTNode<string> maxValue = testBSTree.FinMinMax(foundRoot.Node, true);

            Assert.AreEqual(expectedMin, minValue.NodeKey);
            Assert.AreEqual(expectedMax, maxValue.NodeKey);
        }

        [TestMethod()]
        public void FinMinMax_in_SubTree_if_Tree_Has_15_Nodes()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 3);

            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 7);

            bool isAdded7 = testBSTree.AddKeyValue(1, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(3, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(5, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(7, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(9, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(11, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(13, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(15, "Level_3 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 15);

            BSTFind<string> foundFromNode = testBSTree.FindNodeByKey(12);

            int expectedMin = 9;
            int expectedMax = 15;

            BSTNode<string> minValue = testBSTree.FinMinMax(foundFromNode.Node, false);
            BSTNode<string> maxValue = testBSTree.FinMinMax(foundFromNode.Node, true);

            Assert.AreEqual(expectedMin, minValue.NodeKey);
            Assert.AreEqual(expectedMax, maxValue.NodeKey);
        }

        [TestMethod()]
        public void DeleteNodeByKey_in_Tree_with_15_Nodes_If_NodeToDelete_Is_Leaf()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");
            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");
            bool isAdded7 = testBSTree.AddKeyValue(1, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(3, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(5, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(7, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(9, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(11, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(13, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(15, "Level_3 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 15);
            BSTFind<string> foundParentNode = testBSTree.FindNodeByKey(10);
            Assert.IsTrue(foundParentNode.Node.LeftChild.NodeKey == 9);
            Assert.IsTrue(foundParentNode.Node.LeftChild.Parent.NodeKey == 10);
            bool isDeleted = testBSTree.DeleteNodeByKey(9);
            Assert.IsTrue(isDeleted);
            Assert.IsNull(foundParentNode.Node.LeftChild);
            Assert.IsTrue(testBSTree.Count() == 14);
        }

        [TestMethod()]
        public void DeleteNodeByKey_in_Tree_with_15_Nodes_If_NodeToDelete_Has_TWO_Children()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");
            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");
            bool isAdded7 = testBSTree.AddKeyValue(1, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(3, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(5, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(7, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(9, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(11, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(13, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(15, "Level_3 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 15);
            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(8);
            Assert.IsTrue(foundRoot.Node.RightChild.NodeKey == 12);
            Assert.IsTrue(foundRoot.Node.RightChild.RightChild.NodeKey == 14);

            bool isDeleted = testBSTree.DeleteNodeByKey(12);

            Assert.IsTrue(foundRoot.Node.RightChild.NodeKey == 13);
            Assert.IsTrue(foundRoot.Node.RightChild.Parent.NodeKey == 8);
            Assert.IsTrue(foundRoot.Node.RightChild.RightChild.NodeKey == 14);
            Assert.IsNull(foundRoot.Node.RightChild.RightChild.LeftChild);
            Assert.IsTrue(foundRoot.Node.RightChild.RightChild.RightChild.NodeKey == 15);
            testBSTree.PrintNodes(testBSTree.DeepAllNodes(foundRoot.Node, 0));
            Assert.AreEqual(14, testBSTree.Count());
        }

        [TestMethod()]
        public void DeleteNodeByKey_in_Tree_with_15_Nodes_If_NodeToDelete_Has_ONE_Children()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");
            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");
            bool isAdded7 = testBSTree.AddKeyValue(1, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(3, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(5, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(7, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(9, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(11, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(13, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(15, "Level_3 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 15);
            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(8);

            bool isDeleted1 = testBSTree.DeleteNodeByKey(5); // удаление первого узла
            BSTFind<string> catchRemovedNode = testBSTree.FindNodeByKey(5);

            Assert.IsTrue(isDeleted1);
            Assert.IsNull(foundRoot.Node.LeftChild.RightChild.LeftChild);
            Assert.IsFalse(catchRemovedNode.NodeHasKey);
            Assert.AreEqual(14, testBSTree.Count());

            bool isDeleted2 = testBSTree.DeleteNodeByKey(6); // удаление второго узла
            BSTFind<string> catchRemovedNode2 = testBSTree.FindNodeByKey(6);

            Assert.IsTrue(isDeleted2); // удаление успешно произведено
            Assert.IsTrue(foundRoot.Node.LeftChild.RightChild.NodeKey == 7); // преемник занял место удаленного узла
            Assert.IsFalse(catchRemovedNode2.NodeHasKey); // удаленный ключ отсутствует в дереве
            Assert.AreEqual(foundRoot.Node.LeftChild.RightChild.Parent, foundRoot.Node.LeftChild); // родитель удаленного узла стал родителем для преемника
            Assert.IsNull(foundRoot.Node.LeftChild.RightChild.LeftChild); // преемник по прежнему не имеет потомков
            Assert.IsNull(foundRoot.Node.LeftChild.RightChild.RightChild);
            Assert.AreEqual(13, testBSTree.Count()); // количесвто узлов уменьшилось на 1

            testBSTree.PrintNodes(testBSTree.DeepAllNodes(foundRoot.Node, 0));
        }

        [TestMethod()]
        public void DeleteNodeByKey_in_Tree_with_15_Nodes_If_NodeToDelete_Has_NOT_Children()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(8, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(4, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(12, "Level_1 Right_Child");
            bool isAdded3 = testBSTree.AddKeyValue(2, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(6, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(10, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(14, "Level_2 Right_Child");
            bool isAdded7 = testBSTree.AddKeyValue(1, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(3, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(5, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(7, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(9, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(11, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(13, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(15, "Level_3 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 15);
            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(8);

            bool isDeleted = testBSTree.DeleteNodeByKey(7);
            BSTFind<string> catchRemovedNode = testBSTree.FindNodeByKey(7);

            Assert.IsTrue(isDeleted);
            Assert.IsNull(foundRoot.Node.LeftChild.RightChild.RightChild);
            Assert.IsFalse(catchRemovedNode.NodeHasKey);
            Assert.AreEqual(14, testBSTree.Count());

            testBSTree.PrintNodes(testBSTree.DeepAllNodes(foundRoot.Node, 0));
        }

        [TestMethod()]
        public void DeleteNodeByKey_in_Tree_with_31_Nodes_If_Successor_Has_RightChild_Only()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(16, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(8, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(24, "Level_1 Right_Child");

            bool isAdded3 = testBSTree.AddKeyValue(4, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(12, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(20, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(28, "Level_2 Right_Child");

            bool isAdded7 = testBSTree.AddKeyValue(2, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(6, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(10, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(14, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(18, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(22, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(26, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(30, "Level_3 Right_Child");

            bool isAdded15 = testBSTree.AddKeyValue(1, "Level_4 Left_Child");
            bool isAdded16 = testBSTree.AddKeyValue(3, "Level_4 Right_Child");
            bool isAdded17 = testBSTree.AddKeyValue(5, "Level_4 Left_Child");
            bool isAdded18 = testBSTree.AddKeyValue(7, "Level_4 Right_Child");
            bool isAdded19 = testBSTree.AddKeyValue(9, "Level_4 Left_Child");
            bool isAdded20 = testBSTree.AddKeyValue(11, "Level_4 Right_Child");
            bool isAdded21 = testBSTree.AddKeyValue(13, "Level_4 Left_Child");
            bool isAdded22 = testBSTree.AddKeyValue(15, "Level_4 Right_Child");
            bool isAdded23 = testBSTree.AddKeyValue(17, "Level_4 Left_Child");
            bool isAdded24 = testBSTree.AddKeyValue(19, "Level_4 Right_Child");
            bool isAdded25 = testBSTree.AddKeyValue(21, "Level_4 Left_Child");
            bool isAdded26 = testBSTree.AddKeyValue(23, "Level_4 Right_Child");
            bool isAdded27 = testBSTree.AddKeyValue(25, "Level_4 Left_Child");
            bool isAdded28 = testBSTree.AddKeyValue(27, "Level_4 Right_Child");
            bool isAdded29 = testBSTree.AddKeyValue(29, "Level_4 Left_Child");
            bool isAdded30 = testBSTree.AddKeyValue(31, "Level_4 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 31);
            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(16);

            bool isDeleted = testBSTree.DeleteNodeByKey(25); // удаляем лист
            BSTFind<string> catchRemovedNode = testBSTree.FindNodeByKey(25);

            Assert.IsTrue(isDeleted); // удаление прошло успешно
            Assert.IsTrue(testBSTree.Count() == 30); // количество узлов уменьшилось
            Assert.IsFalse(catchRemovedNode.NodeHasKey); // удаленный узел не найден

            bool isDeleted2 = testBSTree.DeleteNodeByKey(24); // удаляем узел с двумя потомками
            BSTFind<string> catchRemovedNode2 = testBSTree.FindNodeByKey(24);

            Assert.IsTrue(isDeleted2); // удаление прошло успешно
            Assert.AreEqual(29, testBSTree.Count()); // количество узлов уменьшилось
            Assert.IsFalse(catchRemovedNode2.NodeHasKey); // удаленный узел не найден
            Assert.IsTrue(foundRoot.Node.RightChild.NodeKey == 26);
            Assert.AreEqual(foundRoot.Node.RightChild.Parent, foundRoot.Node);
            Assert.AreEqual(foundRoot.Node.RightChild, foundRoot.Node.RightChild.RightChild.Parent);
            Assert.IsTrue(foundRoot.Node.RightChild.RightChild.NodeKey == 28);
            Assert.IsTrue(foundRoot.Node.RightChild.RightChild.LeftChild.NodeKey == 27);
            Assert.IsTrue(foundRoot.Node.RightChild.RightChild.RightChild.NodeKey == 30);

            BSTFind<string> foundChild = testBSTree.FindNodeByKey(27);
            Assert.IsTrue(foundChild.Node.Parent.NodeKey == 28);
            Assert.IsNull(foundChild.Node.LeftChild);
            Assert.IsNull(foundChild.Node.RightChild);

            testBSTree.PrintNodes(testBSTree.DeepAllNodes(foundRoot.Node, 0));
        }

        [TestMethod()]
        public void DeleteNodeByKey_in_Tree_with_31_Nodes_If_NodeToDelete_Has_Leafs()
        {
            BST<string> testBSTree = new BST<string>(new BSTNode<string>(16, "Root", null));

            bool isAdded1 = testBSTree.AddKeyValue(8, "Level_1 Left_Child");
            bool isAdded2 = testBSTree.AddKeyValue(24, "Level_1 Right_Child");

            bool isAdded3 = testBSTree.AddKeyValue(4, "Level_2 Left_Child");
            bool isAdded4 = testBSTree.AddKeyValue(12, "Level_2 Right_Child");
            bool isAdded5 = testBSTree.AddKeyValue(20, "Level_2 Left_Child");
            bool isAdded6 = testBSTree.AddKeyValue(28, "Level_2 Right_Child");

            bool isAdded7 = testBSTree.AddKeyValue(2, "Level_3 Left_Child");
            bool isAdded8 = testBSTree.AddKeyValue(6, "Level_3 Right_Child");
            bool isAdded9 = testBSTree.AddKeyValue(10, "Level_3 Left_Child");
            bool isAdded10 = testBSTree.AddKeyValue(14, "Level_3 Right_Child");
            bool isAdded11 = testBSTree.AddKeyValue(18, "Level_3 Left_Child");
            bool isAdded12 = testBSTree.AddKeyValue(22, "Level_3 Right_Child");
            bool isAdded13 = testBSTree.AddKeyValue(26, "Level_3 Left_Child");
            bool isAdded14 = testBSTree.AddKeyValue(30, "Level_3 Right_Child");

            bool isAdded15 = testBSTree.AddKeyValue(1, "Level_4 Left_Child");
            bool isAdded16 = testBSTree.AddKeyValue(3, "Level_4 Right_Child");
            bool isAdded17 = testBSTree.AddKeyValue(5, "Level_4 Left_Child");
            bool isAdded18 = testBSTree.AddKeyValue(7, "Level_4 Right_Child");
            bool isAdded19 = testBSTree.AddKeyValue(9, "Level_4 Left_Child");
            bool isAdded20 = testBSTree.AddKeyValue(11, "Level_4 Right_Child");
            bool isAdded21 = testBSTree.AddKeyValue(13, "Level_4 Left_Child");
            bool isAdded22 = testBSTree.AddKeyValue(15, "Level_4 Right_Child");
            bool isAdded23 = testBSTree.AddKeyValue(17, "Level_4 Left_Child");
            bool isAdded24 = testBSTree.AddKeyValue(19, "Level_4 Right_Child");
            bool isAdded25 = testBSTree.AddKeyValue(21, "Level_4 Left_Child");
            bool isAdded26 = testBSTree.AddKeyValue(23, "Level_4 Right_Child");
            bool isAdded27 = testBSTree.AddKeyValue(25, "Level_4 Left_Child");
            bool isAdded28 = testBSTree.AddKeyValue(27, "Level_4 Right_Child");
            bool isAdded29 = testBSTree.AddKeyValue(29, "Level_4 Left_Child");
            bool isAdded30 = testBSTree.AddKeyValue(31, "Level_4 Right_Child");

            Assert.IsTrue(testBSTree.Count() == 31);
            BSTFind<string> foundRoot = testBSTree.FindNodeByKey(16);

            bool isDeleted = testBSTree.DeleteNodeByKey(18); // удаляем узел с двумя листами
            BSTFind<string> catchRemovedNode = testBSTree.FindNodeByKey(18);

            Assert.IsTrue(isDeleted); // удаление прошло успешно
            Assert.IsFalse(catchRemovedNode.NodeHasKey); // удаленный узел не найден
            Assert.IsTrue(testBSTree.Count() == 30); // количество узлов уменьшилось

            bool isDeleted2 = testBSTree.DeleteNodeByKey(22); // удаляем узел с двумя потомками
            BSTFind<string> catchRemovedNode2 = testBSTree.FindNodeByKey(22);

            Assert.IsTrue(isDeleted2); // удаление прошло успешно
            Assert.AreEqual(29, testBSTree.Count()); // количество узлов уменьшилось
            Assert.IsFalse(catchRemovedNode2.NodeHasKey); // удаленный узел не найден

            Assert.IsTrue(foundRoot.Node.RightChild.LeftChild.LeftChild.NodeKey == 19);
            Assert.IsTrue(foundRoot.Node.RightChild.LeftChild.LeftChild.Parent.NodeKey == 20);
            Assert.AreEqual(foundRoot.Node.RightChild.LeftChild.LeftChild.Parent, foundRoot.Node.RightChild.LeftChild);
            Assert.IsTrue(foundRoot.Node.RightChild.LeftChild.LeftChild.LeftChild.NodeKey == 17);
            Assert.IsNull(foundRoot.Node.RightChild.LeftChild.LeftChild.RightChild);
            Assert.AreEqual(foundRoot.Node.RightChild.LeftChild.LeftChild.LeftChild.Parent, foundRoot.Node.RightChild.LeftChild.LeftChild);

            testBSTree.PrintNodes(testBSTree.DeepAllNodes(foundRoot.Node, 0));
        }

        [TestMethod()]
        public void DeepAllNodes()
        {
            BST<string> tree = new BST<string>(new BSTNode<string>(4, "Root", null));
            tree.AddKeyValue(2, "Level1 Left_Child");
            tree.AddKeyValue(6, "Level1 Right_Child");
            tree.AddKeyValue(1, "Level2 Left_Child");
            tree.AddKeyValue(3, "Level1 Right_Child");
            tree.AddKeyValue(5, "Level1 Left_Child");
            tree.AddKeyValue(7, "Level3 Right_Child");

            BSTFind<string> foundRoot = tree.FindNodeByKey(4);
            System.Console.Write("pre-order:     ");
            tree.PrintNodes(tree.DeepAllNodes(foundRoot.Node, 2)); // pre-order
            System.Console.Write("in-order:       ");
            tree.PrintNodes(tree.DeepAllNodes(foundRoot.Node, 0)); // in-order
            System.Console.Write("post-order:   ");
            tree.PrintNodes(tree.DeepAllNodes(foundRoot.Node, 1)); // post-order
        }

        [TestMethod()]
        public void WideAllNodes()
        {
            BST<string> tree = new BST<string>(new BSTNode<string>(8, "Root", null));

            tree.AddKeyValue(4, "Level_1 Left_Child");
            tree.AddKeyValue(12, "Level_1 Right_Child");
            tree.AddKeyValue(2, "Level_2_1 Left_Child");
            tree.AddKeyValue(6, "Level_2_1 Right_Child");
            tree.AddKeyValue(10, "Level_2_2 Left_Child");
            tree.AddKeyValue(14, "Level_2_2 Right_Child");
            tree.AddKeyValue(1, "Level_3_1 Left_Child");
            tree.AddKeyValue(3, "Level_3_1 Right_Child");
            tree.AddKeyValue(5, "Level_3_2 Left_Child");
            tree.AddKeyValue(7, "Level_3_2 Right_Child");
            tree.AddKeyValue(9, "Level_3_3 Left_Child");
            tree.AddKeyValue(11, "Level_3_3 Right_Child");
            tree.AddKeyValue(13, "Level_3_4 Left_Child");
            tree.AddKeyValue(15, "Level_3_4 Right_Child");

            BSTFind<string> foundRoot = tree.FindNodeByKey(8);
            tree.PrintNodes(tree.WideAllNodes(foundRoot.Node));
        }
    }
}