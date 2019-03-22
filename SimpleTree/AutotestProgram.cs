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
                var targetNode = targetList.Find(delegate (SimpleTreeNode<T> node) { return node == NodeToDelete; });
                if (targetNode != null && targetNode != Root)
                {
                    targetNode.Parent.Children.Remove(targetNode);
                    if (targetNode.Children != null)
                    {
                        foreach (var child in targetNode.Children)
                        {
                            child.Parent = targetNode.Parent;
                        }
                        targetNode.Parent.Children.AddRange(targetNode.Children);
                    }

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
            return Recursive(Root, val, true).Count == 0 ? null : Recursive(Root, val, true);
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            List<SimpleTreeNode<T>> targetList = FindNodesByValue(OriginalNode.NodeValue);
            List<SimpleTreeNode<T>> newParentList = FindNodesByValue(NewParent.NodeValue);

            if (targetList != null && newParentList != null)
            {
                var targetNode = targetList.Find(delegate (SimpleTreeNode<T> node) { return node == OriginalNode; });
                var newParentNode = newParentList.Find(delegate (SimpleTreeNode<T> node) { return node == NewParent; });

                if (targetNode != null && targetNode != Root && newParentNode != null)
                {
                    OriginalNode.Parent.Children.Remove(OriginalNode);
                    OriginalNode.Parent = NewParent;
                    AddChild(NewParent, OriginalNode);
                }
            }
        }

        public int Count()
        {
            return GetAllNodes().Count;
        }

        public int LeafCount()
        {
            return Recursive(Root).FindAll(delegate (SimpleTreeNode<T> node) { return node.Children == null || node.Children.Count == 0; }).Count;
        }

        private List<SimpleTreeNode<T>> Recursive(SimpleTreeNode<T> targetNode, T val = default(T), bool isFind = false)
        {
            SimpleTreeNode<T> node = targetNode;
            var result = new List<SimpleTreeNode<T>> { node };

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