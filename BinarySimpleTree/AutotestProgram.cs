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
            if (Root == null) return null; // досрочное прекращение поиска если дерево не содержит корня

            BSTNode<T> currentNode = Root; // поиск начинатся с корня
            BSTNode<T> parrent; // родитель, к которому добавится новый узел в случае, если по ключу совпадений не обнаружено 

            while (key != currentNode.NodeKey) // пока совпадение не найдено
            {
                parrent = currentNode;

                if (key < currentNode.NodeKey)
                {
                    currentNode = currentNode.LeftChild; // двигаемся влево
                    if (currentNode == null)
                        return new BSTFind<T> { Node = parrent, NodeHasKey = false, ToLeft = true }; // узел-родитель для добавления нового узла левым потомком
                }
                else
                {
                    currentNode = currentNode.RightChild; // двигаемся вправо
                    if (currentNode == null)
                        return new BSTFind<T> { Node = parrent, NodeHasKey = false, ToLeft = false }; // 
                }
            }

            return new BSTFind<T> { Node = currentNode, NodeHasKey = true }; // найденный узел
        }


        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево, если кроень не null
            if (Root != null)
            {
                BSTFind<T> foundNode = FindNodeByKey(key);

                if (!foundNode.NodeHasKey)
                {
                    if (foundNode.ToLeft)
                        foundNode.Node.LeftChild = new BSTNode<T>(key, val, foundNode.Node);
                    else
                        foundNode.Node.RightChild = new BSTNode<T>(key, val, foundNode.Node);

                    return true;
                }
            }
            else
            {
                Root = new BSTNode<T>(key, val, null); // создаем корень дерева
            }

            return false; // если ключ уже есть
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            BSTNode<T> current = FromNode;
            BSTNode<T> tempNode;
            if (FindMax)
                tempNode = current.RightChild;
            else
                tempNode = current.LeftChild;

            while (tempNode != null)
                current = tempNode;

            return current;
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            return false; // если узел не найден
        }

        public int Count()
        {
            return Recursive(Root); // количество узлов в дереве
        }

        // вспомогательная функция для обхода дерева
        private int Recursive(BSTNode<T> node) 
        {
            int count = 0;

            while (node != null)
            {
                Recursive(node.LeftChild);
                ++count;
                Recursive(node.RightChild);
            }

            return count;
        }
    }
}