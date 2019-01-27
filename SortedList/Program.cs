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
                    if ((Compare(tail.value, value) == -1 && _ascending) ||
                        (Compare(tail.value, value) == 1 && !_ascending))
                    {
                        tail.next = nodeToInsert;
                        nodeToInsert.prev = tail;
                        tail = nodeToInsert;
                        tail.next = null;
                        Console.WriteLine("lOG: ADD in TAIL======\nnodeToInsert.value:{0}\nnodeToInsert.next is null: {1}\nnodeToInsert.prev is null: {2}", nodeToInsert.value, nodeToInsert.next == null, nodeToInsert.prev == null);
                        Console.WriteLine("LOG: ADD in TAIL======\nHead.value: {0}\nHead.prev is null: {1}\nHead.next is null: {2}", head.value, head.prev == null, head.next == null);
                        Console.WriteLine("LOG: ADD in TAIL======\nTail.value: {0}\nTail.prev is null: {1}\nTail.next is null: {2}\nLOG's END ======", tail.value, tail.prev == null, tail.next == null);

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
                        Console.WriteLine("lOG: ADD in HEAD======\nnodeToInsert.value:{0}\nnodeToInsert.next is null: {1}\nnodeToInsert.prev is null: {2}", nodeToInsert.value, nodeToInsert.next == null, nodeToInsert.prev == null);
                        Console.WriteLine("LOG: ADD in HEAD======\nHead.value: {0}\nHead.prev is null: {1}\nHead.next is null: {2}", head.value, head.prev == null, head.next == null);
                        Console.WriteLine("LOG: ADD in HEAD======\nTail.value: {0}\nTail.prev is null: {1}\nTail.next is null: {2}\nLOG's END ======", tail.value, tail.prev == null, tail.next == null);

                        return;
                    }

                    int result = Compare(node.value, value);

                    // Вставка нового элемента между элементами 
                    // с учётом признака упорядоченности списка
                    if ((result == 1 && _ascending) ||
                        ((result == -1 || result == 0) && !_ascending))
                    {
                        nodeToInsert.next = node;
                        nodeToInsert.prev = node.prev;
                        node.prev.next = nodeToInsert;
                        node.prev = nodeToInsert;

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
            Console.WriteLine("Count: {0}\nHead is null: {1}\nTail is null: {2}\n",
            ascList.Count(),
            ascList.head == null,
            ascList.tail == null);
            ascList.Add(123);
            Console.WriteLine("\nCount: {0}\nHead: {1}\nTail: {2}\nHead.next is null: {3}\nHead.prev is null: {4}\nTail.next is null: {5}\nTail.prev is null: {6}",
                ascList.Count(),
                ascList.head.value,
                ascList.tail.value,
                ascList.head.next == null,
                ascList.head.prev == null,
                ascList.tail.prev == null,
                ascList.tail.next == null);
            Console.WriteLine(ascList.PrintList());
            ascList.Add(12);
            Console.WriteLine("\nCount: {0}\nHead: {1}\nTail: {2}\nHead.next is null: {3}\nHead.prev is null: {4}\nTail.next is null: {5}\nTail.prev is null: {6}",
                ascList.Count(),
                ascList.head.value,
                ascList.tail.value,
                ascList.head.next == null,
                ascList.head.prev == null,
                ascList.tail.prev == null,
                ascList.tail.next == null);
            //OrderedList<int> descList = new OrderedList<int>(false);
            //Console.WriteLine("Count: {0}\nHead is null: {1}\nTail is null: {2}",
            //descList.Count(),
            //descList.head == null,
            //descList.tail == null);
            //descList.Add(9);
            //Console.WriteLine("Count: {0}\nHead: {1}\nTail: {2}\nHead.next is null: {3}\nHead.prev is null: {4}\nTail.next is null: {5}\nTail.prev is null: {6}",
            //    descList.Count(),
            //    descList.head.value,
            //    descList.tail.value,
            //    descList.head.next == null,
            //    descList.head.prev == null,
            //    descList.tail.prev == null,
            //    descList.tail.next == null);
            //Console.WriteLine(descList.PrintList());

            //OrderedList<string> strList = new OrderedList<string>(true);
            //Console.WriteLine("Count before Adding: {0}\nHead is null: {1}\nTail is null: {2}",
            //strList.Count(),
            //strList.head == null,
            //strList.tail == null);
            //strList.Add("привет");
            //Console.WriteLine("Count: {0}\nHead: {1}\nTail: {2}\nHead.next is null: {3}\nHead.prev is null: {4}\nTail.next is null: {5}\nTail.prev is null: {6}",
            //    strList.Count(),
            //    strList.head.value,
            //    strList.tail.value,
            //    strList.head.next == null,
            //    strList.head.prev == null,
            //    strList.tail.prev == null,
            //    strList.tail.next == null);
            //Console.WriteLine(strList.PrintList());

            //OrderedList<string> str2List = new OrderedList<string>(false);
            //Console.WriteLine("Count before Adding: {0}\nHead is null: {1}\nTail is null: {2}",
            //str2List.Count(),
            //str2List.head == null,
            //str2List.tail == null);
            //str2List.Add("пока");
            //Console.WriteLine("Count: {0}\nHead: {1}\nTail: {2}\nHead.next is null: {3}\nHead.prev is null: {4}\nTail.next is null: {5}\nTail.prev is null: {6}",
            //    str2List.Count(),
            //    str2List.head.value,
            //    str2List.tail.value,
            //    str2List.head.next == null,
            //    str2List.head.prev == null,
            //    str2List.tail.prev == null,
            //    str2List.tail.next == null);
            //Console.WriteLine(str2List.PrintList());

            Console.ReadKey();
        }
    }
}
