using System;


namespace DynArray
{

    public class DynArray
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

        public DynArray()
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
            if (GetCount() == GetCapacity())
            {
                MakeArray(GetCapacity() * 2);
            }
            array[GetCount()] = item;
            ChangeCount('+');
        }

        public void Insert(int index, object item)
        {
            if (GetCount() == GetCapacity())
            {
                MakeArray(GetCapacity() * 2);
            }

            object[] tempArray = new object[GetCapacity()];

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

            if (array.Length <= GetCapacity() / 2 && GetCapacity() >= 16)
            {
                SetCapacity((int)Math.Round(GetCapacity() / 1.5));
                if (GetCapacity() < 16)
                    SetCapacity(16);
            }

            ChangeCount('-');
        }

        public void Print()
        {
            for (int i = 0; i < GetCount(); i++)
            { 
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            DynArray testDynArr = new DynArray();
            int item = 1;
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            Console.WriteLine("Размерность буфера дин.массива:\t {0}", testDynArr.GetCapacity());
            Console.WriteLine("Количество элементов дин.массива: {0}", testDynArr.GetCount());
            testDynArr.AppEnd(item++);
            Console.WriteLine("Размерность буфера дин.массива:\t {0}", testDynArr.GetCapacity());
            Console.WriteLine("Количество элементов дин.массива: {0}", testDynArr.GetCount());
            testDynArr.AppEnd(item++);
            testDynArr.AppEnd(item++);
            Console.WriteLine("Размерность буфера дин.массива:\t {0}", testDynArr.GetCapacity());
            Console.WriteLine("Количество элементов дин.массива: {0}", testDynArr.GetCount());
            Console.WriteLine("Первый элемент: {0}", testDynArr.GetItem(0));
            Console.WriteLine("Последний элемент: {0}", testDynArr.GetItem(testDynArr.GetCount() - 1));
            testDynArr.Print();
            Console.ReadKey();
        }
    }
}
