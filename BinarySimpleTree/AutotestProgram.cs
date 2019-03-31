using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если не найден узел, и в дереве только один корень
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
            BSTNode<T> currentNode = Root; // поиск начинатся с корня

            while (key != currentNode.NodeKey) // пока совпадение не найдено
            {
                if (key < currentNode.NodeKey)
                    currentNode = currentNode.LeftChild; //  двигаемся влево
                else
                    currentNode = currentNode.RightChild; // двигаемся вправо
                if (currentNode == null) return new BSTFind<T> { Node = null, NodeHasKey = false }; // узел отсутствует
            }

            return new BSTFind<T> { Node = currentNode, NodeHasKey = true }; // возвращаем найденный узел
        }


        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            BSTFind<T> targetFound = FindNodeByKey(key);
            if (targetFound.Node == null)
            {
                // TODO реализовать добавление узла с помощью метода FindNodeByKey(int key)
                return true;
            }

            return false; // если ключ уже есть
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // TODO реализовать поиск минимального/ максимального значения
            // ищем максимальное/минимальное в поддереве
            return null;
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            return false; // если узел не найден
        }
    }
}