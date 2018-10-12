using System;


namespace DynArray
{

    class DynArray
    {
        private int count = 0;
        private int capacity;
        object[] array;

        DynArray()
        {
            capacity = 16;
            array = new object[capacity];
        }

        public void MakeArray(int newCapacity)
        {
            object[] resArr = new object[newCapacity];

            for (int i = 0; i < array.Length; i++)
            {
                resArr[i] = array[i];
            }
            array = resArr;
        }

        public object GetItem(int i)
        {
            try
            {
                return array[i];
            }
            catch (IndexOutOfRangeException e)
            {
                return new IndexOutOfRangeException("Недопустимый индекс массива!", e);
            }
        }

        public void AppEnd(object item) { }
        public void Insert(int i, object item) { }
        public void Delete(int i) { }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
