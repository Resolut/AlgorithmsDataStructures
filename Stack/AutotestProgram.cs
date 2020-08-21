namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        public T[] items;
        private int count;
        int capacity;

        public Stack()
        {
            count = 0;
            Resize(16);
        }

        public int Size()
        {
            return count;
        }

        public T Pop()
        {
            if (count <= capacity / 2 && capacity >= 16)
            {
                capacity = (int)(capacity / 1.5);
                if (capacity < 16)
                    capacity = 16;
            }

            if (count > 0)
            {
                T item = items[--count];
                items[count] = default(T);

                return item;
            }

            return default(T);
        }

        public void Push(T val)
        {
            if (count == capacity)
                Resize(capacity * 2);

            items[count] = val;
            count++;
        }

        public T Peek()
        {
            if (count > 0)
                return items[count - 1];

            return default(T);
        }

        public void Resize(int new_capacity)
        {
            capacity = new_capacity;
            if (items == null)
                items = new T[new_capacity];

            T[] resArr = new T[new_capacity];

            for (int i = 0; i < items.Length; i++)
                resArr[i] = items[i];

            items = resArr;
        }
    }
}