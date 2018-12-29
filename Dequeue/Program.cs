using System;
using System.Collections.Generic;

namespace Dequeue
{
    class Deque<T>
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
            Deque<int> testDeq = new Deque<int>();
            testDeq.AddFront(1);
            testDeq.AddFront(2);
            testDeq.AddFront(3);
            testDeq.AddFront(4);
            
            for (int i = 0; i < testDeq.Size(); i++ ) {
                Console.Write("{0} ", testDeq.RemoveTail());
            }

            Console.ReadKey();
        }
    }
}
