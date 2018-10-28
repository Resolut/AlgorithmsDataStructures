using System;


namespace DynArray
{

    public class DynArray
    {
        private int count = 0;
        private int capacity;
        private object[] array;

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
            if (GetCount() <= GetCapacity() / 2 && GetCapacity() >= 16)
            {
                SetCapacity((int)Math.Round(GetCapacity() / 1.5));
                if (GetCapacity() < 16)
                    SetCapacity(16);
            }

            object[] tempArray = new object[GetCapacity()];

            for (int i = 0; i < GetCount(); i++)
            {
                if (i < index)
                    tempArray[i] = array[i];
                else if (i == index)
                    tempArray[i] = array[i + 1];
                else
                    tempArray[i] = array[i - 1];
            }
            array = tempArray;
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
            DynArray testDyn = new DynArray();
            int item = 1;
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.AppEnd(item++);
            testDyn.Print();
            Console.WriteLine("Емкость {0}", testDyn.GetCapacity());
            testDyn.Delete(15);
            testDyn.Print();
            Console.WriteLine("Емкость после удаления одного элемента {0}", testDyn.GetCapacity());
            testDyn.Print();
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления второго элемента {0}", testDyn.GetCapacity());
            testDyn.Print();
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 3 элемента {0}", testDyn.GetCapacity());
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 4 элемента {0}", testDyn.GetCapacity());
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 5 элемента {0}", testDyn.GetCapacity());
            Console.WriteLine("Емкость после удаления 6 элемента {0}", testDyn.GetCapacity());
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 7 элемента {0}", testDyn.GetCapacity());
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 8 элемента {0}", testDyn.GetCapacity());
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 9 элемента {0}", testDyn.GetCapacity());
            testDyn.Delete(16);
            Console.WriteLine("Емкость после удаления 10 элемента {0}", testDyn.GetCapacity());
            testDyn.Print();
            Console.ReadKey();

        }
    }
}
