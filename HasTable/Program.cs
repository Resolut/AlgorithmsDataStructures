using System.Collections.Generic;

namespace HashTable
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        private int currentHash;
        private delegate int HashF(string value);
        List<HashF> familyHashFun = new List<HashF>();

        public HashTable(int sz, int stp)
        {
            // Хэш-функция 1
            HashF func1 = (value) =>
            {
                int hash = 0;
                int a = 5;
                int b = 3;
                int p = 7;

                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        hash += value[i];
                    }
                    hash = ((a * hash + b) % p) % size;
                }
                return hash;
            };  

            HashF func2 = (value) => { return value.Length; }; // TODO Добавить код хэш-функции 2
            HashF func3 = (value) => { return value.Length; }; // TODO добавить код хэш-функции 3

            familyHashFun.Add(func1);
            familyHashFun.Add(func2);
            familyHashFun.Add(func3);
            
            System.DateTime time = System.DateTime.Now;
            int seed = time.Millisecond;
            System.Random rand = new System.Random(seed);
            currentHash = rand.Next(familyHashFun.Count); // Случайный выбор хэш-функции из списка

            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;

        }

        public int HashFun(string value)
        {
            return familyHashFun[currentHash](value); // Вызываеем хэш-функцию, определённую случайным образом в конструкторе
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
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
