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
            if (FindNodesByValue(ParentNode.NodeValue) != null)
            {
                SimpleTreeNode<T> targetNode = FindNodesByValue(ParentNode.NodeValue)[0]; // берём первый узел, если узлов с таким значением в дереве несколько

                if (targetNode.Children == null)
                    targetNode.Children = new List<SimpleTreeNode<T>> { NewChild };
                else
                    targetNode.Children.Add(NewChild);

                NewChild.Parent = targetNode;
            }
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete) // Написать тесты для проверки удаления узла
        {
            List<SimpleTreeNode<T>> targetList = FindNodesByValue(NodeToDelete.NodeValue);

            if (targetList != null)
            {
                SimpleTreeNode<T> targetNode = targetList[0];
                if (targetNode != Root)
                {
                    targetNode.Parent.Children.Remove(targetNode);
                    targetNode.Parent.Children.AddRange(targetNode.Children);
                    targetNode = null;
                }
            }
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            return Recursive(Root);
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            return Recursive(Root, val, true);
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            OriginalNode.Parent.Children.Remove(OriginalNode);
            OriginalNode.Parent = NewParent;
            AddChild(NewParent, OriginalNode);
        }

        public int Count()
        {
            return GetAllNodes().Count;
        }

        public int LeafCount()
        {
            Predicate<SimpleTreeNode<T>> hasNullChildren = delegate (SimpleTreeNode<T> node) { return node.Children == null; };
            List<SimpleTreeNode<T>> allNodesList = Recursive(Root);
            return allNodesList.FindAll(hasNullChildren).Count;
        }

        private List<SimpleTreeNode<T>> Recursive(SimpleTreeNode<T> targetNode, T val = default(T), bool isFind = false)
        {
            SimpleTreeNode<T> node = targetNode;
            List<SimpleTreeNode<T>> result = new List<SimpleTreeNode<T>> { node };

            if (isFind)
            {
                result = new List<SimpleTreeNode<T>>();
                if (node.NodeValue.Equals(val))
                    result.Add(node);
            }

            for (int i = 0; node.Children != null && i < node.Children.Count; i++)
            {
                if (isFind)
                     result.AddRange(Recursive(node.Children[i], val, true));
                else
                    result.AddRange(Recursive(node.Children[i]));
            }

            return result;
        }
    }

}