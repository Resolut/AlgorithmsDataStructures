using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            capacity = new_capacity;
            if (array == null)
                array = new T[new_capacity];

            T[] resArr = new T[new_capacity];

            for (int i = 0; i < array.Length; i++)
                resArr[i] = array[i];

            array = resArr;
        }

        public T GetItem(int index)
        {
            if (index < count && index >= 0)
                return array[index];
            else
                new IndexOutOfRangeException("Введён Недопустимый индекс массива!");

            return default(T);
        }

        public void Append(T itm)
        {
            if (count == capacity)
                MakeArray(capacity * 2);

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException("Введён недопустимый индекс массива!");
            else if (index == count)
                this.Append(itm);
            else
            {
                if (count == capacity)
                    MakeArray(capacity * 2);

                T[] tempArr = new T[capacity];

                for (int i = 0; i < count; i++)
                {
                    if (i < index)
                        tempArr[i] = array[i];
                    else if (i == index)
                    {
                        tempArr[i] = itm;
                        tempArr[i + 1] = array[i];
                    }
                    else
                        tempArr[i + 1] = array[i];
                }

                array = tempArr;
                count++;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Введён недопустимый индекс массива!");
            if (count <= capacity / 2 && capacity >= 16)
            {
                capacity = (int)(capacity / 1.5);
                if (capacity < 16)
                    capacity = 16;
            }

            T[] tempArr = new T[capacity];

            for (int i = 0; i < count - 1; i++)
            {
                if (i < index)
                    tempArr[i] = array[i];
                else
                    tempArr[i] = array[i + 1];
            }
            array = tempArr;
            count--;
        }
    }
}