using System;

namespace LinkedList
{

    class Node
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

    class LinkedList
    {
        private Node head;
        private Node tail;

        // Написать функцию суммирования элементов списков, если равны их длины
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

        public LinkedList findAll(int value)
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

        // Реализовать метод возвращения длины списка
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

        // Реализовать метод вставки узла после заданного узла
        public void addNode(int value)
        {
            throw new System.NotImplementedException();
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
            sList.AddInTail(new Node(55));
            Console.WriteLine(sList.PrintList());
            Console.WriteLine(sList.GetLength());
            //sList.RemoveAll(55);
            sList.RemoveNode(12);
            Console.WriteLine(sList.PrintList());

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
