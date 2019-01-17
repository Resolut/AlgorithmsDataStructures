using System.Collections.Generic;

namespace Queue
{
    public class Queue<T>
    {
        LinkedList<T> items;

        public Queue()
        {
            items = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            items.AddFirst(item);
        }

        public T Dequeue()
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

        public int Size()
        {
            return items.Count;
        }

        public void Rotate(int offset)
        {
            while (offset > 0)
            {
                Enqueue(Dequeue());
                --offset;
            }
        }
    }
}
