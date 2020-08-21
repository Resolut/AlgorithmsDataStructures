using System;
using System.Collections.Generic;

namespace OrderedList
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;

            if (typeof(T) == typeof(String))
            {
                string strV1 = v1.ToString().Trim();
                string strV2 = v2.ToString().Trim();

                if (strV1.Length < strV2.Length)
                {
                    result = -1;
                }
                else if (strV1.Length > strV2.Length)
                {
                    result = 1;
                }
                else
                {
                    for (int i = 0; i < strV1.Length; i++)
                    {
                        if (strV1[i] < strV2[i])
                        {
                            result = -1;
                            break;
                        }
                        if (strV1[i] > strV2[i])
                        {
                            result = 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (typeof(T) == typeof(int))
                {
                    int digit1 = Convert.ToInt32(v1);
                    int digit2 = Convert.ToInt32(v2);

                    if (digit1 < digit2)
                        result = -1;
                    else if (digit1 > digit2)
                        result = 1;
                }
            }

            return result;
        }

        public void Add(T value)
        {
            Node<T> node = head;
            Node<T> nodeToInsert = new Node<T>(value);

            if (node != null)
            {
                while (node != null)
                {

                    // Вставка нового элемента в конец списка 
                    // с учётом признака упорядоченности
                    if (((Compare(tail.value, value) == -1 || Compare(tail.value, value) == 0) && _ascending) ||
                        ((Compare(tail.value, value) == 1 || Compare(tail.value, value) == 0) && !_ascending))
                    {
                        tail.next = nodeToInsert;
                        nodeToInsert.prev = tail;
                        tail = nodeToInsert;
                        tail.next = null;
                        Console.WriteLine("=== LOG: ADD in TAIL ===\n======\nnodeToInsert.value:{0}\nnodeToInsert.next is null: {1}\nnodeToInsert.prev: {2}", nodeToInsert.value, nodeToInsert.next == null, nodeToInsert.prev.value);
                        Console.WriteLine("======\nHead.value: {0}\nHead.prev is null: {1}\nHead.next: {2}", head.value, head.prev == null, head.next.value);
                        Console.WriteLine("======\nTail.value: {0}\nTail.prev: {1}\nTail.next is null: {2}\n=== LOG ADD in TAIL END ===", tail.value, tail.prev.value, tail.next == null);

                        return;
                    }

                    // Вставка нового элемента в начало списка 
                    // с учётом признака упорядоченности
                    if ((Compare(head.value, value) == 1 && _ascending) ||
                        (Compare(head.value, value) == -1 && !_ascending))
                    {
                        nodeToInsert.next = head;
                        head.prev = nodeToInsert;
                        nodeToInsert.prev = null;
                        head = nodeToInsert;
                        head.prev = null;
                        Console.WriteLine("=== LOG: ADD in HEAD ===\n======\nnodeToInsert.value:{0}\nnodeToInsert.next: {1}\nnodeToInsert.prev is null: {2}", nodeToInsert.value, nodeToInsert.next.value, nodeToInsert.prev == null);
                        Console.WriteLine("======\nHead.value: {0}\nHead.prev is null: {1}\nHead.next: {2}", head.value, head.prev == null, head.next.value);
                        Console.WriteLine("======\nTail.value: {0}\nTail.prev: {1}\nTail.next is null: {2}\n=== LOG ADD in HEAD END ===", tail.value, tail.prev.value, tail.next == null);

                        return;
                    }

                    int result = Compare(node.value, value);

                    // Вставка нового элемента между элементами 
                    // с учётом признака упорядоченности списка
                    if ((result == 1 && _ascending) ||
                        (result == -1 && !_ascending))
                    {
                        nodeToInsert.next = node;
                        nodeToInsert.prev = node.prev;
                        node.prev.next = nodeToInsert;
                        node.prev = nodeToInsert;
                        Console.WriteLine("=== LOG: ADD in MIDDLE ===\n======\nnodeToInsert.value:{0}\nnodeToInsert.next: {1}\nnodeToInsert.prev: {2}", nodeToInsert.value, nodeToInsert.next.value, nodeToInsert.prev.value);
                        Console.WriteLine("======\nHead.value: {0}\nHead.prev is null: {1}\nHead.next: {2}", head.value, head.prev == null, head.next.value);
                        Console.WriteLine("======\nTail.value: {0}\nTail.prev: {1}\nTail.next is null: {2}\n=== LOG ADD in MIDDLE END ===", tail.value, tail.prev.value, tail.next == null);
                        return;
                    }

                    node = node.next;
                }
            }
            else
            {
                // вставка в пустой список
                head = nodeToInsert;
                head.next = null;
                head.prev = null;
                tail = nodeToInsert;
                tail.next = null;
                tail.prev = null;
            }

        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;

            while (node != null)
            {
                int issue = Compare(node.value, val);

                if (issue == 0) return node; // Поиск завершен, элемент найден
                else if (issue == 1 && _ascending) break;   // Прерывание поиска для списка с признаком возрастания 
                else if (issue == -1 && !_ascending) break; // Прерывание поиска для списка с признаком убывания

                node = node.next;
            }

            return null;
        }

        public void Delete(T val)
        {
            Node<T> node = head;
            Node<T> previousNode = head;

            while (node != null)
            {
                if (Compare(node.value, val) == 0) // тип параметра val может быть разным, поэтому используем метод Compare
                {
                    if (head == tail)
                    {
                        Clear(_ascending);
                    }
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

                    return;
                }
                else
                    previousNode = node;
                node = node.next;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node<T> node = head;

            while (node != null)
            {
                node = node.next;
                count++;
            }

            return count;
        }

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                               // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }

        // не проверяется 
        public String PrintList()
        {
            Node<T> node = head;
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
            OrderedList<int> ascList = new OrderedList<int>(true);

            ascList.Add(12);
            ascList.Add(12);
            ascList.Add(12);
            ascList.Add(12);
            ascList.Add(0);
            ascList.Add(0);
            ascList.Add(0);
            ascList.Add(1);
            ascList.Add(1);
            ascList.Add(1);
            Console.WriteLine(ascList.PrintList());

            //OrderedList<int> descList = new OrderedList<int>(false);
            //OrderedList<string> strList = new OrderedList<string>(true);
            //OrderedList<string> str2List = new OrderedList<string>(false);

            Console.ReadKey();
        }
    }
}
