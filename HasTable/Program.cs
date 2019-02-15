using System.Collections.Generic;

namespace HashTable
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        public delegate int HashF(string value, int a, int b, int p);
        private int p1, p2, p3;
        List<HashF> familyHashFun = new List<HashF>();

        public HashTable(int sz, int stp)
        {
            int[,] arrPars = { { 5, 3, 7 }, { 8, 11, 17 }, { 7, 0, 13 } };

            System.DateTime time = System.DateTime.Now;
            int seed = time.Millisecond;
            System.Random rand = new System.Random(seed);
            int hPar = rand.Next(arrPars.GetLength(1)); // Случайный выбор набора параметров для хэш-функции из массива arrPar

            p1 = arrPars[hPar, 0]; // набор параметров
            p2 = arrPars[hPar, 1];
            p3 = arrPars[hPar, 2];

            familyHashFun.Add((value, a, b, p) =>
            {
                int hash = 0;

                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        hash += value[i];
                    }
                    hash = (a * hash + b) % p % size;
                }
                return hash;
            });

            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            return familyHashFun[0](value, p1 , p2, p3); // Вызываеем хэш-функцию с набором подготовленных и случайно выбранных параметров 
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            int startSlot = HashFun(value);

            if (slots[startSlot] == null)
                return startSlot;
            else
            {
                int offset = startSlot;
                bool loopEnds = false; // флаг оповещает, что цикл прошёл до конца таблицы

                while (slots[offset] != null)
                {
                    offset += step;
                    if (offset >= slots.Length)
                    {
                        loopEnds = true;
                        offset -= slots.Length;
                    }
                    if (loopEnds && offset >= startSlot)
                        break;
                    if (slots[offset] == null)
                        return offset;
                }
            }

            return -1; // не удалось найти свободный слот из-за коллизий
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            int target = SeekSlot(value);

            if (target != -1)
                slots[target] = value;
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            return target;
        }

        public int Find(string value)
        {
            // находит индекс пустого слота для значения, или -1
            int startSlot = HashFun(value);

            if (slots[startSlot] == value)
                return startSlot;
            else
            {
                int offset = startSlot;
                bool loopEnds = false; // флаг оповещает, что цикл прошёл до конца таблицы

                while (slots[offset] != value)
                {
                    offset += step;

                    if (offset >= slots.Length)
                    {
                        loopEnds = true;
                        offset -= slots.Length;
                    }
                    if (loopEnds && offset == startSlot)
                        break;
                    if (slots[offset] == value)
                        return offset;
                }
            }

            return -1; // не удалось найти свободный слот из-за коллизий
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null)
                    System.Console.WriteLine(@"slot [{0}] null", i);
                else
                    System.Console.WriteLine(@"slot [{0}] = {1}", i, slots[i]);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable(23, 5);
            HashTable table2 = new HashTable(23, 5);
            HashTable table3 = new HashTable(23, 5);

            int colCounter1 = 0;
            int colCounter2 = 0;
            int colCounter3 = 0;

            for (int i = 0; i < table.size * 10; i++)
            {
                string value = "" + (char)(i + 33);
                int putSlot = table.Put(value);
                if (putSlot == -1) ++colCounter1;

                int putSlot2 = table2.Put(value);
                if (putSlot2 == -1) ++colCounter2;

                int putSlot3 = table3.Put(value);
                if (putSlot3 == -1) ++colCounter3;
            }
            System.Console.WriteLine("Число коллизий\n хэш-функции1:{0}\n хэш-функции2:{1}\n хэш-функции3:{2}", colCounter1, colCounter2, colCounter3);

            System.Console.ReadKey();
        }


    }
}
