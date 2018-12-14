using System;
using System.Collections.Generic;

namespace LinkedList2
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

        // не проверяется
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

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    return node;
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

        public void Clear()
        {
            head = null;
            tail = null;
        }

        // не проверяется 
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

    class MainProgram
    {
        static void Main(string[] args)
        {
            //// тест метода InsertAfter, если список непустой и узел _nodeAfter непустой 

            //LinkedList2 testList = new LinkedList2();
            //testList.AddInTail(new Node(1));
            //testList.AddInTail(new Node(2));
            //testList.AddInTail(new Node(4));
            //testList.AddInTail(new Node(5));
            //Console.WriteLine("Вставка в непустой список");
            //Console.WriteLine("Перед вставкой:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //testList.InsertAfter(new Node(2), new Node(3));

            //Console.WriteLine("\nПосле вставки:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //Node node = testList.head;
            //while (node != null)
            //{
            //    if (node.value == 3)
            //    {
            //        Console.WriteLine("Предыдущий узел: {0}", node.prev.value);
            //        Console.WriteLine("Следующий узел: {0}", node.next.value);
            //    }

            //    node = node.next;
            //}

            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("==============================");

            //// тест метода InsertAfter, если список пустой и узел _nodeAfter пустой 

            //testList = new LinkedList2();

            //Console.WriteLine("Вставка в пустой список после пустого узла");
            //Console.WriteLine("Перед вставкой:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("Голова: {0}", testList.head);
            //Console.WriteLine("Хвост: {0}", testList.tail);

            //testList.InsertAfter(null, new Node(3));

            //Console.WriteLine("\nПосле вставки:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //node = testList.head;
            //while (node != null)
            //{
            //    if (node.value == 3)
            //    {
            //        Console.WriteLine("Предыдущий узел: {0}", node.prev == null);
            //        Console.WriteLine("Следующий узел: {0}", node.next == null);
            //    }

            //    node = node.next;
            //}

            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("==============================");

            //Console.WriteLine("Вставка в непустой список если узел _nodeAfter не существует");
            //Console.WriteLine("Перед вставкой:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //testList.InsertAfter(null, new Node(4));

            //Console.WriteLine("\nПосле вставки:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //node = testList.head;
            //while (node != null)
            //{
            //    if (node.value == 4)
            //    {
            //        Console.WriteLine("Предыдущий узел: {0}", node.prev.value);
            //        Console.WriteLine("Следующий узел: {0}", node.next == null ? "null" : node.next.value.ToString());
            //    }

            //    node = node.next;
            //}

            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("==============================");

            //Console.WriteLine("Вставка в конец непустого списка если узел _nodeAfter существует");
            //Console.WriteLine("Перед вставкой:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Число узлов: {0}", testList.Count());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //testList.InsertAfter(new Node(4), new Node(5));

            //Console.WriteLine("\nПосле вставки:");
            //Console.WriteLine("Список: " + testList.PrintList());
            //Console.WriteLine("Голова: {0}", testList.head.value);
            //Console.WriteLine("Хвост: {0}", testList.tail.value);

            //node = testList.head;
            //while (node != null)
            //{
            //    if (node.value == 5)
            //    {
            //        Console.WriteLine("Предыдущий узел: {0}", node.prev.value);
            //        Console.WriteLine("Следующий узел: {0}", node.next == null ? "null" : node.next.value.ToString());
            //    }

            //    node = node.next;
            //}

            LinkedList2 testList2 = new LinkedList2();
            testList2.InsertAfter(null, new Node(1));
            testList2.InsertAfter(null, new Node(2));
            testList2.InsertAfter(null, new Node(3));
            testList2.InsertAfter(null, new Node(4));
            testList2.InsertAfter(null, new Node(5));
            testList2.InsertAfter(null, new Node(6));
            testList2.InsertAfter(null, new Node(7));
            testList2.InsertAfter(null, new Node(8));
            testList2.InsertAfter(null, new Node(9));
            testList2.InsertAfter(null, new Node(10));

            //Console.WriteLine("Удаление с конца непустого списка если удаляемый узел существует");
            //Console.WriteLine("Перед удалением:");
            //Console.WriteLine("Список: " + testList2.PrintList());
            //Console.WriteLine("Число узлов: {0}", testList2.Count());
            //Console.WriteLine("Голова: {0}", testList2.head.value);
            //Console.WriteLine("Хвост: {0}", testList2.tail.value);

            //testList2.Remove(4);
            //Console.WriteLine("\nПосле удаления:");
            //Console.WriteLine("Список: " + testList2.PrintList());
            //Console.WriteLine("Голова: {0}", testList2.head.value);
            //Console.WriteLine("Хвост: {0}", testList2.tail.value);
            //Console.WriteLine("Предыдущий узел хвоста: {0}", testList2.tail.prev.value);
            //Console.WriteLine("Следующий узел хвоста: {0}", testList2.tail.next == null ? "null" : testList2.tail.next.value.ToString());


            //Console.WriteLine("\nУдаление узла 2: {0}", testList2.Remove(2));
            //Console.WriteLine("Список: " + testList2.PrintList());
            //Console.WriteLine("Голова: {0}", testList2.head.value);
            //Console.WriteLine("Хвост: {0}", testList2.tail.value);
            //Console.WriteLine("Предыдущий узел до удаленного узла считает следующим: {0}", testList2.head.next.value);
            //Console.WriteLine("Следующий узел после удаленного узла считает предыдущим: {0}", testList2.tail.prev.value);
            //Console.WriteLine("Предыдущий узел хвоста: {0}", testList2.tail.prev.value);
            //Console.WriteLine("Следующий узел хвоста: {0}", testList2.tail.next == null ? "null" : testList2.tail.next.value.ToString());

            //Console.WriteLine("\nУдаление узла из головы (1): {0}", testList2.Remove(1));
            //Console.WriteLine("Список: " + testList2.PrintList());
            //Console.WriteLine("Голова: {0}", testList2.head.value);
            //Console.WriteLine("Хвост: {0}", testList2.tail.value);
            //Console.WriteLine("Предыдущий узел до головы: {0}", testList2.head.prev == null ? "null" : testList2.head.prev.value.ToString());
            //Console.WriteLine("Следующий узел после головы: {0}", testList2.head.next == null ? "null" : testList2.head.next.value.ToString());
            //Console.WriteLine("Узел перед хвостом: {0}", testList2.tail.prev == null ? "null" : testList2.tail.prev.value.ToString());
            //Console.WriteLine("Узел после хвоста: {0}", testList2.tail.next == null ? "null" : testList2.tail.next.value.ToString());

            Console.WriteLine("Список: " + testList2.PrintList());
            Console.WriteLine("\nУдаление нескольких узлов из списка: ");
            testList2.RemoveAll(9);
            Console.WriteLine("Список: " + testList2.PrintList());
            Console.WriteLine("Голова: {0}", testList2.head.value);
            Console.WriteLine("Хвост: {0}", testList2.tail.value);
            Console.WriteLine("Предыдущий узел до головы: {0}", testList2.head.prev == null ? "null" : testList2.head.prev.value.ToString());
            Console.WriteLine("Следующий узел после головы: {0}", testList2.head.next == null ? "null" : testList2.head.next.value.ToString());
            Console.WriteLine("Узел перед хвостом: {0}", testList2.tail.prev == null ? "null" : testList2.tail.prev.value.ToString());
            Console.WriteLine("Узел после хвоста: {0}", testList2.tail.next == null ? "null" : testList2.tail.next.value.ToString());

            //Console.WriteLine("\nУдаление единственного узла в списке (3): {0}", testList2.Remove(3));
            //Console.WriteLine("Список: " + testList2.PrintList());
            //Console.WriteLine("Голова: {0}", testList2.head == null);
            //Console.WriteLine("Хвост: {0}", testList2.tail == null);

            Console.ReadKey(true);
        }
    }
}
