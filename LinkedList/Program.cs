using System;

namespace LinkedList
{

    public class Node
    {
        private readonly int value;
        public Node next;

        public Node(int itemValue)
        {
            value = itemValue;
            next = null;
        }

        public int GetValue()
        {
            return value;
        }
    }

    public class LinkedList
    {
        private Node head;
        private Node tail;

        public static LinkedList ReduceLinkedLists(LinkedList oneList, LinkedList anotherList)
        {
            LinkedList resList = new LinkedList();
            if (oneList.GetLength() == anotherList.GetLength())
            {
                Node nodeOneList = oneList.head;
                Node nodeAnotherList = anotherList.head;

                while (nodeOneList != null)
                {
                    resList.AddInTail(new Node(nodeOneList.GetValue() + nodeAnotherList.GetValue()));
                    nodeOneList = nodeOneList.next;
                    nodeAnotherList = nodeAnotherList.next;
                }
                
            }
            return resList;
        }

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node item)
        {
            if (head == null)
                head = item;
            else
                tail.next = item;
            tail = item;
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public LinkedList FindAll(int value)
        {
            Node node = head;
            LinkedList resList = new LinkedList();

            while (node != null)
            {
                if (node.GetValue() == value)
                    resList.AddInTail(node);
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
                            node.next = item;
                            return;
                        }
                        node = node.next;
                    }
                }
                else
                {
                    tail.next = item;
                    tail = item;
                }
            }
        }

        public void RemoveNode(int val)
        {
            Node node = head;
            Node previousNode = head;
            while (node != null)
            {
                if (node.GetValue() == val)
                {
                    if (node == head)
                        head = node.next;
                    else
                        previousNode.next = node.next;
                    return;
                } else
                    previousNode = node;

                node = node.next;
            }
        }

        public void RemoveAll(int val)
        {
            Node previousNode = null;
            Node node = head;
            while (node != null)
            {
                if (node.GetValue() == val)
                {
                    if (node == head)
                        head = node.next;
                    else
                        previousNode.next = node.next;
                } else
                    previousNode = node;

                node = node.next;
            }
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


            LinkedList testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            testList.AddInTail(new Node(4));
            int expected = 6;
            testList.AddNode(new Node(4), 2);
            Console.WriteLine(testList.PrintList());
            int actual = testList.GetLength();

            Console.WriteLine(expected == actual);
            Console.WriteLine(testList.FindAll(4).PrintList());
            Console.ReadKey(true);
        }
    }
}
