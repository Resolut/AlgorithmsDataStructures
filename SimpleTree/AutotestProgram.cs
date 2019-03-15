using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode
            List<SimpleTreeNode<T>> targetList = FindNodesByValue(ParentNode.NodeValue); // получаем список узлов

            if (targetList != null)
            {
                SimpleTreeNode<T> targetNode = targetList[0]; // берем первый узел, если узлов с таким значением в дереве несколько
                targetNode.Children.Add(NewChild);
            }

            // TODO проверить, что узел добавлен к текущему узлу
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            List<SimpleTreeNode<T>> targetList = FindNodesByValue(NodeToDelete.NodeValue);

            if (targetList != null)
            {
                SimpleTreeNode<T> targetNode = targetList[0];
                targetNode.Parent.Children.Remove(targetNode);
                targetNode.Parent.Children.AddRange(targetNode.Children);
                targetNode = null;

                // TODO проверить, что родитель имеет потомков и узел удалён
                // TODO проверить, что потомки ссылаются на родителя
            }
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
            SimpleTreeNode<T> node = Root;
            int count = node.Children.Count;
            List<SimpleTreeNode<T>> result = null;

            result.Add(node);

            for (int i = 0; result == null && i < count; i++)
            {
                node = node.Children[i];
                result = GetAllNodes();
            }

            return result;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            // ваш код поиска узлов по значению
            SimpleTreeNode<T> node = Root;
            int count = node.Children.Count;
            List<SimpleTreeNode<T>> result = null;

            if (node.NodeValue.Equals(val))
            {
                result.Add(node);
            }

            for (int i = 0; result == null && i < count; i++)
            {
                node = node.Children[i];
                result = FindNodesByValue(val);
            }

            return result;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            // ваш код перемещения узла вместе с его поддеревом -- 
            // в качестве дочернего для узла NewParent
        }

        public int Count()
        {
            // количество всех узлов в дереве
            return 0;
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            return 0;
        }

    }

}