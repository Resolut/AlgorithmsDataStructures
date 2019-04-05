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

            int expectdMin = 2;
            int expectdMax = 14;

            BSTNode<string> minValue = testBSTree.FinMinMax(foundRoot.Node, false);
            BSTNode<string> maxValue = testBSTree.FinMinMax(foundRoot.Node, true);

            Assert.AreEqual(expectdMin, minValue.NodeKey);
            Assert.AreEqual(expectdMax, maxValue.NodeKey);
        }
    }
}