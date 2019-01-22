using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
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
                // версия для лексикографического сравнения строк
            }
            else
            {
                // универсальное сравнение
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            // автоматическая вставка value 
            // в нужную позицию
        }

        public Node<T> Find(T val)
        {
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            Node<T> node = head;
            Node<T> previousNode = head;

            while (node != null)
            {
                if (Compare(node.value, val) == 0) // Сравниваться могут раззные типы данных, поэтому используем метод Compare
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
                ++count;
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

}