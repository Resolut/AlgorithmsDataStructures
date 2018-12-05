using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
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
                        head = node.next;
                    else if (node == tail)
                    {
                        previousNode.next = null;
                        tail = previousNode;
                    }
                    else
                        previousNode.next = node.next;
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
                    if (node == head)
                        head = node.next;
                    else if (node == tail)
                    {
                        previousNode.next = null;
                        tail = previousNode;
                    }
                    else
                        previousNode.next = node.next;
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

        public bool InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            Node node = head;

            if (head != null)
            {
                if (node != tail)
                {
                    while (node != null)
                    {
                        if (node.value == _nodeAfter.value)
                        {
                            _nodeToInsert.next = node.next;
                            node.next = _nodeToInsert;
                            return true;
                        }
                        node = node.next;
                    }
                }
                else if (node.value == _nodeAfter.value)
                {
                    tail.next = _nodeToInsert;
                    tail = _nodeToInsert;
                    return true;
                }

            }
            else if (_nodeAfter == null)
            {
                head = _nodeToInsert;
                return true;
            }

            return false;
        }

        public String PrintList()
        {
            Node node = head;
            String res = "";
            while (node != null)
            {
                res += node.value + " ";
                node = node.next;
            }
            if (res.Length == 0) return "[]";
            return res;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            Console.WriteLine("Узлов {0}", testList.Count());
            Console.WriteLine("Голова {0}", testList.head.value);
            Console.WriteLine("Хвост {0}", testList.tail.value);
            testList.AddInTail(new Node(2));
            Console.WriteLine("Узлов {0}", testList.Count());
            Console.WriteLine("Голова {0}", testList.head.value);
            Console.WriteLine("Хвост {0}", testList.tail.value);
            Console.WriteLine("Удаление произошло?: {0}", testList.Remove(2));
            Console.WriteLine("Узлов {0}", testList.Count());
            Console.WriteLine("Голова {0}", testList.head.value);
            Console.WriteLine("Хвост {0}", testList.tail.value);
            Console.WriteLine("Удаление произошло?: {0}", testList.Remove(1));
            Console.WriteLine("Узлов {0}", testList.Count());
            Console.WriteLine("Хвост {0}", testList.tail.value);
            Console.WriteLine("Голова {0}", testList.head.value);
            Console.ReadKey();
        }
    }
}
