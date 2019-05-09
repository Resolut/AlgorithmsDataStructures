using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

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

        int[] BSTArray; // временный массив для ключей дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void CreateFromArray(int[] a)
        {
            // создаём массив дерева BSTArray из заданного
            BSTArray = new int[a.Length];
            Array.Sort(a);  // сортируем исходный массив по возрастанию
            AddToArray(a, 0);      // формируем массив со структурой сбалансированного дерева
        }

        public void GenerateTree()
        {
            // создаём дерево с нуля из массива BSTArray
            Root = AddNode(null, 0);
        }

        public bool IsBalanced(BSTNode root_node)
        {
            return false; // сбалансировано ли дерево с корнем root_node
        }
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

            AddToArray(left, 2 * index + 1);           // определяем левого наследника родительского узла
            AddToArray(right, 2 * index + 2);          // определяем правого наследника родительского узла 

        }

        private BSTNode AddNode(BSTNode parent, int index)
        {
            // TODO: добавить условие выхода из рекурсии по превышению индекса массива
            BSTNode node = new BSTNode(BSTArray[index], parent);
            if (parent == null) node.Level = 1;
            else node.Level = parent.Level + 1;

            node.LeftChild = AddNode(node, 2 * index + 1);
            node.LeftChild.Level = node.LeftChild.Parent.Level + 1;
            node.RightChild = AddNode(node, 2 * index + 2);
            node.RightChild.Level = node.RightChild.Parent.Level + 1;

            return node;
        }
    }
}