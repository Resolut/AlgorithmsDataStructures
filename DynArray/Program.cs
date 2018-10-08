using System;

namespace DynArray
{
    class DynArray
    {
        private int count = 0; // количество элементов в массиве
        int capacity;  // текущая емкость буфера
        int[] array;   // массив

        DynArray()
        {
            capacity = 16;
        }

        public void MakeArray(int newCapacity)
        {
            int[] resArray = new int[newCapacity];
            for (int i = 0; i < array.Length; i++)
            {
                resArray[i] = array[i];
                array = resArray;
            }
        }

        public int GetItem(int i)
        {
            try
            {
                return array[i];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("Введенный индекс находится за границами массива!", e); 
            }


        }

        public void AppEnd(int item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int i, int item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int i)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
