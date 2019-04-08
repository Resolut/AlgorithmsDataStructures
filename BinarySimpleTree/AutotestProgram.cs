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
                        return new BSTFind<T> { Node = parrent, NodeHasKey = false, ToLeft = false };
                }
            }

            return new BSTFind<T> { Node = currentNode, NodeHasKey = true }; // найденный узел
        }

        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево, если корень не null
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

            if (FindMax)
            {
                if (current.RightChild != null)
                    current = FinMinMax(current.RightChild, FindMax);
            }
            else
            {
                if (current.LeftChild != null)
                    current = FinMinMax(current.LeftChild, FindMax);
            }

            return current;
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            BSTFind<T> foundNode = FindNodeByKey(key);
            if (foundNode.NodeHasKey)
            {
                // удаляемый узел не имеет потомков
                if (foundNode.Node.LeftChild == null && foundNode.Node.RightChild == null)
                {
                    if (foundNode.Node.Parent.LeftChild != null && foundNode.Node.Parent.LeftChild.Equals(foundNode.Node))
                        foundNode.Node.Parent.LeftChild = null;
                    else if (foundNode.Node.Parent.RightChild != null && foundNode.Node.Parent.RightChild.Equals(foundNode.Node))
                        foundNode.Node.Parent.RightChild = null;
                }
                // удаляемый узел имеет только одного потомка
                else if (foundNode.Node.LeftChild == null ^ foundNode.Node.RightChild == null)
                {
                    if (foundNode.Node.LeftChild != null) // левый потомок привязываем к родителю удаленного узла
                    {
                        if (foundNode.Node.Parent.LeftChild != null && foundNode.Node.Parent.LeftChild.Equals(foundNode.Node))
                            foundNode.Node.Parent.LeftChild = foundNode.Node.LeftChild;
                        else
                            foundNode.Node.Parent.RightChild = foundNode.Node.LeftChild;

                        foundNode.Node.LeftChild.Parent = foundNode.Node.Parent;
                    }
                    else // правый потомок привязываем к родителю удаленного узла
                    {
                        if (foundNode.Node.Parent.LeftChild != null && foundNode.Node.Parent.LeftChild.Equals(foundNode.Node))
                            foundNode.Node.Parent.LeftChild = foundNode.Node.RightChild;
                        else
                            foundNode.Node.Parent.RightChild = foundNode.Node.RightChild;

                        foundNode.Node.RightChild.Parent = foundNode.Node.Parent;
                    }
                }
                // удаляемый узел имеет двух потомков
                else
                {
                    BSTNode<T> successorNode = FinMinMax(foundNode.Node.RightChild, false); // наименьший потомок, который больше удаляемого узла

                    if (successorNode.RightChild != null) // если наименьший потомок не является листом
                    {
                        successorNode.Parent.LeftChild = successorNode.RightChild; // передаем его правого потомка левым узлом родителю
                        successorNode.RightChild.Parent = successorNode.Parent; // правому потомку назначаем родителя
                    }
                    else
                    {
                        if (successorNode.Parent.LeftChild == successorNode)
                            successorNode.Parent.LeftChild = null; // удаляем левый лист 
                        else
                            successorNode.Parent.RightChild = null; // удаляем правый лист 
                    }
                    // преемник замещает удаленный узел
                    if (foundNode.Node.Parent.RightChild == foundNode.Node)
                        foundNode.Node.Parent.RightChild = successorNode;
                    else
                        foundNode.Node.Parent.LeftChild = successorNode;

                    successorNode.Parent = foundNode.Node.Parent; // новый родитель для узла-преемника

                    successorNode.LeftChild = foundNode.Node.LeftChild; // левый потомок удаленного узла становится потомком узла-преемника
                    successorNode.RightChild = foundNode.Node.RightChild; // правый потомок удаленного узла становится потомком узла-преемника

                    // связать потомков удаленного узла с новым родителем
                    if (foundNode.Node.RightChild != null)
                        foundNode.Node.RightChild.Parent = successorNode;
                    if (foundNode.Node.LeftChild != null)
                        foundNode.Node.LeftChild.Parent = successorNode;
                }

                return true;
            }

            return false; // если узел не найден
        }

        public int Count()
        {
            return Recursive(Root); // количество узлов в дереве
        }

        // вспомогательный метод для подсчёта узлов дерева
        private int Recursive(BSTNode<T> node, int count = 0)
        {
            if (node != null)
            {
                count++;
                count = Recursive(node.LeftChild, count);
                count = Recursive(node.RightChild, count);
            }

            return count;
        }

        // вспомогательный метод для обхода дерева
        public void PrintNodes(List<BSTNode<T>> NodesList)
        {

            foreach (var item in NodesList) Console.Write(item.NodeKey + " ");
            Console.WriteLine();

            return;
        }
        // вспомогательный метод для обхода дерева ширину
        public List<BSTNode<T>> WideAllNodes()
        {
            return null;
        }

        // вспомогательный метод для обхода дерева в глубину
        public List<BSTNode<T>> DeepAllNodes(BSTNode<T> FromNode, int orderType)
        {
            BSTNode<T> node = FromNode;
            List<BSTNode<T>> Nodes = new List<BSTNode<T>>();

            if (node != null)
            {
                switch (orderType)
                {
                    case 0: // in-Order
                        Nodes.AddRange(DeepAllNodes(node.LeftChild, orderType));
                        Nodes.Add(node);
                        Nodes.AddRange(DeepAllNodes(node.RightChild, orderType));
                        break;
                    case 1: // post-Order
                        Nodes.AddRange(DeepAllNodes(node.LeftChild, orderType));
                        Nodes.AddRange(DeepAllNodes(node.RightChild, orderType));
                        Nodes.Add(node);
                        break;
                    case 2: // pre_odrder
                        Nodes.Add(node);
                        Nodes.AddRange(DeepAllNodes(node.LeftChild, orderType));
                        Nodes.AddRange(DeepAllNodes(node.RightChild, orderType));
                        break;
                    default: return null;
                }

            }

            return Nodes;
        }
    }

}