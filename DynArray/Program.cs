using System;


namespace DynArray
{

    class DynArray
    {
        private int count = 0;
        private int capacity;
        object[] array;

        public int GetCapacity()
        {
            return capacity;
        }

        public void SetCapacity(int newSize)
        {
            capacity = newSize;
        }

        public int GetCount()
        {
            return count;
        }

        public void ChangeCount(char op)
        {
            if (op == '+')
                count++;
            else if (op == '-')
                count--;
        }


        DynArray()
        {
            capacity = 16;
            array = new object[capacity];
        }

        public void MakeArray(int newCapacity)
        {
            SetCapacity(newCapacity);
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

        public void AppEnd(object item)
        {
            MakeArray(array.Length + 1);
            if (array.Length >= GetCapacity())
            {
                SetCapacity(GetCapacity() * 2);
            }

            array[array.Length - 1] = item;
            ChangeCount('+');
        }

        public void Insert(int index, object item)
        {
            object[] tempArray = new object[array.Length + 1];
            
            for (int i = 0; i < array.Length; i++)
            {
                if (i < index)
                    tempArray[i] = array[i];
                else if (i == index)
                {
                    tempArray[i] = item;
                    tempArray[i + 1] = array[i];
                }
                else
                    tempArray[i + 1] = array[i];
            }
            array = tempArray;

            if (array.Length >= GetCapacity())
            {
                SetCapacity(GetCapacity() * 2);
            }

            ChangeCount('+');
        }

        public void Delete(int index)
        {
            object[] tempArray = new object[array.Length - 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (i < index)
                    tempArray[i] = array[i];
                else if (i >= index)
                    tempArray[i + 1] = array[i];
            }
            array = tempArray;

            if (array.Length <= GetCapacity() / 2 && GetCapacity() >=16)
            {
                SetCapacity((int)Math.Round(GetCapacity() / 1.5));
                if (GetCapacity() < 16)
                    SetCapacity(16);
            }

            ChangeCount('-');
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
