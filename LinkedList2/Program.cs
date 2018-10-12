using System;

namespace LinkedList2
{
    public class Node
    {
        private readonly int value;
        public Node next;
        public Node prev;

        public Node(int itemValue)
        {
            value = itemValue;
            next = null;
            prev = null;
        }

        public int GetValue()
        {
            return value;
        }
    }

    public class LinkedList2
    {
        private Node head;
        private Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void RemoveNode(int value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.GetValue() == value)
                {
                    if (node == head)
                    {
                        node.prev = null;
                        head = node.next;
                    }
                    else
                        node.prev.next = node.next;
                    return;
                }

                node = node.next;
            }
        }

        public void AddInTail(Node item)
        {
            if (head == null)
            {
                head = item;
                item.prev = null;
                item.next = null;
            }
            else
            {
                tail.next = item;
                item.prev = tail;
            }

            tail = item;
        }

        public void AddNode(Node item, int target)
        {
            Node node = head;
            if (head != null)
            {
                if (node != tail)
                {
                    while (node != null)
                    {
                        if (node.GetValue() == target)
                        {
                            item.next = node.next;
                            item.prev = node;
                            node.next = item;
                            return;
                        }
                        node = node.next;
                    }
                }
                else
                {
                    tail.next = item;
                    item.prev = tail;
                    tail = item;
                }
            }
        }

        public void AddInHead(Node item)
        {
            if (head == null)
            {
                head = item;
                item.prev = null;
                item.next = null;

            }
            else
            {
                item.next = head;
                item.prev = null;
            }

            head = item;
        }

        public Node Find(int val)
        {
            Node node = head;
            while (node != null)
            {
                if (node.GetValue() == val)
                    return node;
                node = node.next;
            }

            return null;
        }

        public LinkedList2 FindAll(int value)
        {
            Node node = head;
            LinkedList2 resList = new LinkedList2();

            while (node != null)
            {
                if (node.GetValue() == value)
                    resList.AddInTail(new Node(node.GetValue()));
                node = node.next;
            }

            return resList;
        }


        public int GetLength()
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

        public String PrintList()
        {
            Node node = head;
            String res = "";
            while (node != null)
            {
                res += node.GetValue() + " ";
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

            LinkedList2 testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(4));
            int expected = 7;
            testList.AddInHead(new Node(4));
            Console.WriteLine(testList.PrintList());
            int actual = testList.GetLength();

            Console.WriteLine(expected == actual);
            LinkedList2 resultsList = testList.FindAll(4);
            Console.WriteLine(resultsList.PrintList());
            Console.WriteLine(resultsList.GetLength());
            Console.ReadKey(true);
        }
    }
}
