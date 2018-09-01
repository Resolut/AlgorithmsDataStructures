using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int getValue()
        {
            return value;
        }
    }

    class LinkedList
    {
        private Node head;
        private Node tail;

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
        public void RemoveNode(int val)
        {
            Node node = head;
            while (node != null)
            {
                if (node.getValue() == val)
                {
                    node = node.next;
                    return;
                }
            }
        }

        public void RemoveAll(int val)
        {
            Node node = head;
            while (node != null)
            {
                if (node.getValue() == val)
                {
                    node = node.next;

                }
            }
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
            sList.RemoveNode(196);
            sList.RemoveAll(55);
            Console.WriteLine(19071988);
            Console.WriteLine(sList.ToString());
            return;
        }
    }
}
