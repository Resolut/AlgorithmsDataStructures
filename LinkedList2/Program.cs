using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }

            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                    nodes.Add(node);
                node = node.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            Node previousNode = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (head == tail)
                        this.Clear();
                    else if (node == head)
                    {
                        head = node.next;
                        head.prev = null;
                    }
                    else if (node == tail)
                    {
                        previousNode.next = null;
                        tail = previousNode;
                    }
                    else
                    {
                        previousNode.next = node.next;
                        node.next.prev = previousNode;
                    }
                    return true;
                }
                else
                    previousNode = node;

                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node previousNode = head;
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (head == tail)
                        this.Clear();
                    else if (node == head)
                    {
                        head = node.next;
                        head.prev = null;
                    }
                    else if (node == tail)
                    {
                        previousNode.next = null;
                        tail = previousNode;
                    }
                    else
                    {
                        previousNode.next = node.next;
                        node.next.prev = previousNode;
                    }
                }
                else
                    previousNode = node;

                node = node.next;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            while (node != null)
            {
                node = node.next;
                count++;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            Node node = head;

            if (head != null)
            {
                if (_nodeAfter == null)
                {
                    tail.next = _nodeToInsert;
                    _nodeToInsert.prev = tail;
                    tail = _nodeToInsert;
                }
                else
                {
                    while (node != null)
                    {
                        if (node.value == _nodeAfter.value)
                        {
                            if (node == tail)
                            {
                                tail.next = _nodeToInsert;
                                _nodeToInsert.prev = tail;
                                tail = _nodeToInsert;
                            }
                            else
                            {
                                _nodeToInsert.next = node.next;
                                _nodeToInsert.prev = node;
                                node.next = _nodeToInsert;
                            }
                        }

                        node = node.next;
                    }
                }
            }
            else if (_nodeAfter == null && head == null)
            {
                head = _nodeToInsert;
                tail = _nodeToInsert;
            }
        }
    }
}