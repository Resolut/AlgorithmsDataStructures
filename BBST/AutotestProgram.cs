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
            // ...
        }

        public void GenerateTree()
        {
            // создаём дерево с нуля из массива BSTArray
            // ...
        }

        public bool IsBalanced(BSTNode root_node)
        {
            return false; // сбалансировано ли дерево с корнем root_node
        }

    }
}