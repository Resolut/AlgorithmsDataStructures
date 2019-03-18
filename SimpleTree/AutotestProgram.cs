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
                targetNode.Children = new List<SimpleTreeNode<T>>
                {
                    NewChild
                };
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
                // TODO проверить, что узел не является корнем дерева
            }
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            return Recursive(Root);
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            SimpleTreeNode<T> node = Root;
            List<SimpleTreeNode<T>> result = new List<SimpleTreeNode<T>> { node };

            if (node.NodeValue.Equals(val))
            {
                result.Add(node);
            }

            for (int i = 0; node.Children != null && i < node.Children.Count; i++)
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
            return GetAllNodes().Count;
        }

        public int LeafCount()
        {
            SimpleTreeNode<T> node = Root;
            int count = node.Children.Count;
            int leafCount = 0;

            if (node.Children == null)
            {
                leafCount++;
            }

            for (int i = 0; i < count; i++)
            {
                node = node.Children[i];
                leafCount = LeafCount();
            }

            return leafCount;
        }

        private List<SimpleTreeNode<T>> Recursive(SimpleTreeNode<T> targetNode, T val = default(T))
        {
            SimpleTreeNode<T> node = targetNode;
            List<SimpleTreeNode<T>> result = new List<SimpleTreeNode<T>> { node };

            //if (node.NodeValue.Equals(val))
            //{
            //    result.Add(node);
            //}

            for (int i = 0; node.Children != null && i < node.Children.Count; i++)
            {
                result = Recursive(node.Children[i]);
            }

            return result;
        }
    }

}