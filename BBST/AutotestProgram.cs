using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey;         // ключ узла
        public BSTNode Parent;      // родитель или null для корня
        public BSTNode LeftChild;   // левый потомок
        public BSTNode RightChild;  // правый потомок	
        public int Level;           // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }
    public class BalancedBST
    {
        public BSTNode Root;

        public int[] BSTArray; // временный массив для ключей дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void CreateFromArray(int[] a)
        {
            BSTArray = new int[a.Length];   // создаём массив дерева BSTArray из заданного
            Array.Sort(a);                  // сортируем исходный массив по возрастанию
            AddToArray(a, 0);               // формируем массив со структурой сбалансированного дерева
        }

        public void GenerateTree()
        {
            Root = AddNode(null, 0); // создаём дерево с нуля из массива BSTArray
        }

        public bool IsBalanced(BSTNode root_node)
        {
            BSTNode node = root_node;

            if (node != null)
            {
                int LeftLevel = node.Level;
                int RightLevel = node.Level;

                if (node.LeftChild != null)
                    LeftLevel = MaxLevel(node.LeftChild);

                if (node.RightChild != null)
                    RightLevel = MaxLevel(node.RightChild);

                if (Math.Abs(LeftLevel - RightLevel) > 1) return false;
            }

            return true;
        }

        // вспомогательный рекурсивный метод для наполнения массива структурой сбалансированного дерева 
        private void AddToArray(int[] arr, int index)
        {
            int middle = arr.Length / 2;        // центральный индекс массива
            BSTArray[index] = arr[middle];      // центральный элемент - корень дерева 

            if (arr.Length == 1) return;        // выход из рекурсии

            int[] left = new int[middle];       // левый подмассив
            int[] right = new int[middle];      // правый подмассив

            for (int i = 0; i < middle; i++)
            {
                left[i] = arr[i];               // вычисление левой части массива
                right[i] = arr[middle + i + 1]; // вычисление правой части массива
            }

            AddToArray(left, 2 * index + 1);    // определяем левого наследника родительского узла
            AddToArray(right, 2 * index + 2);   // определяем правого наследника родительского узла 

        }

        // вспомогательный рекурсивный метод для создания дерева из массива BSTArray
        private BSTNode AddNode(BSTNode parent, int index)
        {
            if (index >= BSTArray.Length) return null; // выход из рекурсии

            BSTNode node = new BSTNode(BSTArray[index], parent); // создаём корневой узел дерева
            node.Parent = parent;
            if (parent == null) node.Level = 1;
            else node.Level = parent.Level + 1;

            node.LeftChild = AddNode(node, 2 * index + 1);
            if (node.LeftChild != null)
            {
                node.LeftChild.Level = node.LeftChild.Parent.Level + 1;
            }

            node.RightChild = AddNode(node, 2 * index + 2);
            if (node.RightChild != null)
            {
                node.RightChild.Level = node.RightChild.Parent.Level + 1;
            }

            return node;
        }

        // вспомогательный рекурсивный метод для определения максимальной глубины в поддереве
        private int MaxLevel(BSTNode FromNode)
        {
            BSTNode node = FromNode;
            int maxLevel = node.Level;

            if (node != null)
            {
                int leftLevel = node.Level;
                int rightLevel = node.Level;

                if (node.LeftChild != null)
                    leftLevel = MaxLevel(node.LeftChild);

                if (node.RightChild != null)
                    rightLevel = MaxLevel(node.RightChild);

                maxLevel = leftLevel > rightLevel ? leftLevel : rightLevel;
            }

            return maxLevel;
        }

        // v-- методы взяты из BST для проверки дерева --v
        // вспомогательный метод для отображения(печати) всех ключей дерева
        public void PrintNodes(List<BSTNode> NodesList)
        {

            foreach (var item in NodesList)
            {
                Console.Write("node: {0} ", item.NodeKey);
                Console.Write("level: {0} ", item.Level);
                Console.Write("parent: {0} ", item.Parent == null ? "null" : item.Parent.NodeKey.ToString());
                Console.Write("LeftChild: {0} ", item.LeftChild == null ? "null" : item.LeftChild.NodeKey.ToString());
                Console.WriteLine("RightChild: {0}", item.RightChild == null ? "null" : item.RightChild.NodeKey.ToString());
            }
            Console.WriteLine();

            return;
        }

        // вспомогательный итеративный метод для обхода дерева в ширину
        public List<BSTNode> WideAllNodes()
        {
            BSTNode node = Root;
            List<BSTNode> tempQueue = new List<BSTNode> { node }; // список для обхода узлов в порядке очереди
            List<BSTNode> nodes = new List<BSTNode>(); // итоговый список узлов
            while (tempQueue.Count != 0)
            {
                node = tempQueue[tempQueue.Count - 1];
                nodes.Add(node);
                tempQueue.RemoveAt(tempQueue.Count - 1);

                if (node.LeftChild != null)
                    tempQueue.Insert(0, node.LeftChild);
                if (node.RightChild != null)
                    tempQueue.Insert(0, node.RightChild);
            }

            return nodes;
        }

        // метод-обёртка для вызова рекурсивного метода обхода в глубину
        public List<BSTNode> DeepAllNodes(int orderType)
        {
            return RecursiveDeep(Root, orderType);
        }

        // вспомогательный метод обхода в глубину 
        private List<BSTNode> RecursiveDeep(BSTNode FromNode, int orderType)
        {
            BSTNode node = FromNode;
            List<BSTNode> nodes = new List<BSTNode>();

            if (node != null)
            {
                switch (orderType)
                {
                    case 0: // in-order
                        nodes.AddRange(RecursiveDeep(node.LeftChild, orderType));
                        nodes.Add(node);
                        nodes.AddRange(RecursiveDeep(node.RightChild, orderType));
                        break;
                    case 1: // post-order
                        nodes.AddRange(RecursiveDeep(node.LeftChild, orderType));
                        nodes.AddRange(RecursiveDeep(node.RightChild, orderType));
                        nodes.Add(node);
                        break;
                    case 2: // pre-order
                        nodes.Add(node);
                        nodes.AddRange(RecursiveDeep(node.LeftChild, orderType));
                        nodes.AddRange(RecursiveDeep(node.RightChild, orderType));
                        break;
                    default: return null;
                }
            }

            return nodes;
        }

    }
}
