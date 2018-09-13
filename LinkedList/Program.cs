using System;

namespace LinkedList
{

    public class Node
    {
        private int value;
        public Node next;

        public Node(int itemValue)
        {
            value = itemValue;
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

        static LinkedList ReduceLinkedLists(LinkedList oneList, LinkedList anotherList)
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
                }
                return resList;
            }
            else
                return null;
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
            else
                head = item;
        }

        public void RemoveNode(int val)
        {
            Node node = head;
            Node previousNode = head;
            while (node != null)
            {
                if (node.GetValue() == val)
                {
                    previousNode.next = node.next;
                    return;
                }
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
                    previousNode.next = node.next;
                }
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

            return res;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Node n1 = new Node(12);
            Node n2 = new Node(55);
            n1.next = n2;

            LinkedList sList = new LinkedList();
            sList.AddInTail(n1);
            sList.AddInTail(n2);
            sList.AddInTail(new Node(196));
            sList.AddInTail(new Node(205));
            sList.AddInTail(new Node(54));
            Console.WriteLine(sList.PrintList());
            Console.WriteLine("Длина списка : " + sList.GetLength());
            //sList.RemoveAll(55);
            //sList.RemoveNode(12);
            sList.AddNode(new Node(2319), 12);
            Console.WriteLine(sList.PrintList());
            sList.AddNode(new Node(2320), 50);
            Console.WriteLine(sList.PrintList());
        }
    }
}
