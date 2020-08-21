using System;
using System.Collections.Generic;

namespace Dequeue
{
    public class Deque<T>
    {
        LinkedList<T> items;

        public Deque()
        {
            items = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            items.AddLast(item);
        }

        public void AddTail(T item)
        {
            items.AddFirst(item);
        }

        public T RemoveFront()
        {
            T lastItem = default(T);

            if (Size() > 0)
            {
                lastItem = items.Last.Value;
                items.RemoveLast();

                return lastItem;
            }

            return default(T);
        }

        public T RemoveTail()
        {
            T firstItem = default(T);

            if (Size() > 0)
            {
                firstItem = items.First.Value;
                items.RemoveFirst();

                return firstItem;
            }

            return default(T);
        }

        public int Size()
        {
            return items.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string targetWord = "belle";
            Console.WriteLine("проверяем, является ли слово палиндромом...");
            bool checkResult = IsPalindrome(targetWord);
            Console.WriteLine("Слово \"{0}\" палиндром? - {1}", targetWord, checkResult);

            Deque<string> visitors = new Deque<string>();
            visitors.AddFront("f1");
            visitors.AddTail("f2");
            visitors.AddTail("f3");
            visitors.AddTail("f4");
            while (visitors.Size() > 0)
            {
                Console.WriteLine(visitors.RemoveFront() + " ");
            }

            Console.ReadKey();
        }

        static bool IsPalindrome(string str)
        {
            if (str.Length < 1) return false;

            Deque<char> checkDeq = new Deque<char>();

            for (int i = 0; i < str.Length; i++)
            {
                checkDeq.AddFront(str[i]);
            }

            while (checkDeq.Size() > 1)
            {
                if (checkDeq.RemoveFront() != checkDeq.RemoveTail()) return false;
            }

            return true;
        }
    }
}
