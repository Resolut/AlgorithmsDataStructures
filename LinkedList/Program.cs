using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }

        public int GetValue()
        {
            return value;
        }
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
                if (node.GetValue() == _value)
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
                if (node.GetValue() == _value)
                {
                    if (node == head)
                        head = node.next;
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
            Node previousNode = null;
            Node node = head;
            while (node != null)
            {
                if (node.GetValue() == _value)
                {
                    if (node == head)
                        head = node.next;
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
                        if (node.GetValue() == _nodeAfter.GetValue())
                        {
                            _nodeToInsert.next = node.next;
                            node.next = _nodeToInsert;
                            return true;
                        }
                        node = node.next;
                    }
                }
                else if (node.GetValue() == _nodeAfter.GetValue())
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

            Console.WriteLine("Список до вставки:\t" + testList.PrintList());
            bool isAdded = testList.InsertAfter(new Node(4), new Node(6));
            Console.WriteLine("Список после вставки:\t" + testList.PrintList());
            Console.WriteLine($"Метод insertAfter() вернул {isAdded}");

            int expected = 7;
            int actual = testList.Count();
            Console.WriteLine("Число элементов списка совпадает после вставки? - " + (expected == actual));

            Console.Write("Проверка поиска всех элементов по значению.\nМетод FindAll(4) вернул массив: ");
            testList.FindAll(4).ForEach(el => Console.Write(el.GetValue() + " "));

            Console.WriteLine("\nПроверка удаления одного элемента");
            testList.Remove(5);
            Console.WriteLine("Список после выполнения метода Remove(5):" + testList.PrintList());

            Console.WriteLine("Проверка удаления нескольких элементов");
            testList.RemoveAll(4);
            Console.WriteLine("Список после выполнения метода RemoveAll(4):" + testList.PrintList());

            Console.ReadKey(true);
        }
    }
}