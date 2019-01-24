using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    int result = Compare(node.value, value);

                    // Выполнение вставки нового элемента в конец списка 
                    // с учётом признака упорядоченности
                    if (Compare(tail.value, value) == -1 && _ascending ||
                        Compare(tail.value, value) == 1 && !_ascending)
                    {
                        nodeToInsert.prev = tail.prev;
                        tail = nodeToInsert;
                        return;
                    }

                    // Выполнение вставки нового элемента между элементами 
                    // с учётом признака упорядоченности списка
                    if ((result == 1 || result == 0 && _ascending) ||
                        (result == -1 || result == 0 && !_ascending))
                    {
                        nodeToInsert.next = node;
                        nodeToInsert.prev = node.prev;
                        return;
                    }

                    node = node.next;
                }
            }
            else
            {
                // вставка в пустой список
                head = nodeToInsert;
                tail = nodeToInsert;
            }

        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;

            while (node != null)
            {
                int issue = Compare(node.value, val);

                if (issue == 0) return node; // Поиск завершен, элемент найден
                else if (issue == 1 && _ascending) break;   // Прерывание поиска для возрастающего списка 
                else if (issue == -1 && !_ascending) break; // Прерывание поиска для убывающего списка

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
                        this.Clear(false);
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderedList<int> ascList = new OrderedList<int>(true);
            OrderedList<int> descList = new OrderedList<int>(false);

            Console.WriteLine("Элементов в пустом списке: {0}", ascList.Count());
            ascList.Add(0);
            ascList.Add(1);
            ascList.Add(2);
            ascList.Add(3);
            ascList.Add(4);
            Console.WriteLine("Элементов в возрастающем списке: {0}", ascList.Count());
            
            descList.Add(7);
            descList.Add(8);
            descList.Add(9);
            descList.Add(10);
            Console.WriteLine("Элементов в убывающем списке: {0}", descList.Count());

            Console.ReadKey();
        }
    }
}
