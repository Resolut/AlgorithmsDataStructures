using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        LinkedList<T> items;

        public Deque()
        {
            // инициализация внутреннего хранилища
            items = new LinkedList<T>();
        }

        public void addFront(T item)
        {
            // добавление в голову
            items.AddLast(item);
        }

        public void addTail(T item)
        {
            // добавление в хвост
            items.AddFirst(item);
        }

        public T removeFront()
        {
            // удаление из головы
            T lastItem = default(T);

            if (size() > 0)
            {
                lastItem = items.Last.Value;
                items.RemoveLast();

                return lastItem;
            }

            return default(T);
        }

        public T removeTail()
        {
            // удаление из хвоста
            T firstItem = default(T);

            if (size() > 0)
            {
                firstItem = items.First.Value;
                items.RemoveFirst();

                return firstItem;
            }

            return default(T);
        }

        public int size()
        {   // размер очереди
            return items.Count; 
        }
    }

}