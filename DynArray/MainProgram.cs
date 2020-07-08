using System;


namespace DynArray
{

    public class DynArray
    {
        private int count = 0;
        private int capacity;
        public object[] array;

        // не проверяется
        public int GetCapacity()
        {
            return capacity;
        }

        // не проверяется
        public void SetCapacity(int newSize)
        {
            capacity = newSize;
        }

        // не проверяется
        public int GetCount()
        {
            return count;
        }

        // не проверяется
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
            if (i < GetCount())
                return array[i];
            else
                return new IndexOutOfRangeException("Введён Недопустимый индекс массива!");
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
            if (index < 0 || index >= GetCount())
                throw new IndexOutOfRangeException("Введён недопустимый индекс массива!");
            if (GetCount() == GetCapacity())
            {
                MakeArray(GetCapacity() * 2);
            }

            object[] tempArray = new object[GetCapacity()];

            for (int i = 0; i < GetCount(); i++)
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
            if (index < 0 || index >= GetCount())
                throw new IndexOutOfRangeException("Введён недопустимый индекс массива!");
            if (GetCount() <= GetCapacity() / 2 && GetCapacity() >= 16)
            {
                SetCapacity((int)(GetCapacity() / 1.5));
                if (GetCapacity() < 16)
                    SetCapacity(16);
            }

            object[] tempArray = new object[GetCapacity()];

            for (int i = 0; i < GetCount() - 1; i++)
            {
                if (i < index)
                    tempArray[i] = array[i];
                else
                    tempArray[i] = array[i + 1];
            }
            array = tempArray;
            ChangeCount('-');
        }

        // не проверяется
        public void Print()
        {
            for (int i = 0; i < GetCount(); i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }

    class MainProgram
    {
        static void Main()
        {
            DynArray testDynArr = new DynArray();
            for (int item = 1; item < 18; item++)
            {
                testDynArr.AppEnd(item);
            }

            Console.WriteLine("Заполненный массив:");
            testDynArr.Print();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Перед удалением\nЕмкость буфера: " + testDynArr.GetCapacity());
                Console.WriteLine("Количество элементов: "+ testDynArr.GetCount());
                testDynArr.Delete(3);
                Console.WriteLine("После удаления\nЕмкость буфера: " + testDynArr.GetCapacity());
                Console.WriteLine("Количество элементов: " + testDynArr.GetCount());
                testDynArr.Print();
                Console.WriteLine("===============================================");
            }
            Console.WriteLine(testDynArr.GetItem(4).ToString());

            Console.ReadKey();
        }
    }
}
