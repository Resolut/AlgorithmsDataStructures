using System;
using System.Linq;

namespace NativeCache
{
    class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            int hash = 0;
            if (key != null)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    hash += key[i];
                }
                hash %= size;
            }

            return hash;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            if (slots[HashFun(key)] == key)
            {
                hits[HashFun(key)]++;
                return true;
            }

            return false;
        }

        public void Put(string key, T value)
        {
            if (slots[HashFun(key)] == null)
            {
                // записываем значение ключа по хэш-функции
                slots[HashFun(key)] = key;
                // гарантированно записываем 
                // значение value по ключу key
                values[HashFun(key)] = value;
            }
            else
            {
                // записываем ключ key и значение value в слот с минимальным числом обращений
                slots[GetMinHitsElem()] = key;
                values[GetMinHitsElem()] = value;
            }
        }

        public T Get(string key)
        {
            if (IsKey(key))
                return values[HashFun(key)];
            return default(T);
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
                Console.WriteLine("key: {0}  value: {1}  hits: {2}", slots[i], values[i], hits[i]);
            Console.WriteLine();
        }

        private int GetMinHitsElem()
        {
            return Array.IndexOf(hits, hits.Min()); // индекс слота с минимальным числом обращений
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            NativeCache<string> testCache = new NativeCache<string>(10);

            // Формируем уникальные пары ключ - значение по размеру таблицы
            for (int i = 0; i < testCache.size; i++) 
            {
                string key = "Key0" + i;
                string value = "" + (char)(i + 33);
                testCache.Put(key, value);
            }

            // отображаем внутренние массивы ключей, значений и обращений
            Console.WriteLine("Исходная заполненная таблица:");
            testCache.Print();

            for (int i = 0; i < 10; i++) // имитируем обращения к таблице
            {
                switch (i)
                {
                    case 0: testCache.IsKey("Key00"); goto case 1;
                    case 1: testCache.IsKey("Key01"); goto case 2;
                    case 2: testCache.IsKey("Key02"); goto case 3;
                    case 3: testCache.IsKey("Key03"); goto case 4;
                    case 4: testCache.IsKey("Key04"); goto case 5;
                    case 5: testCache.IsKey("Key05"); goto case 6;
                    case 6: testCache.IsKey("Key06"); goto case 7;
                    case 7: testCache.IsKey("Key07"); goto case 8;
                    case 8: testCache.IsKey("Key08"); goto case 9;
                    case 9: testCache.IsKey("Key09"); break;
                }
            }

            // отображаем массивы, число обращений теперь изменилось 
            Console.WriteLine("Таблица после обращений:");
            testCache.Print();

            testCache.Put("Key46", "A"); // Добавлем новый ключ в слот с уже существующим ключом 

            Console.WriteLine("Таблица после записи новой пары ключ \\ значение :");
            testCache.Print(); // Ключ и значение с минимальным числом обращений перезаписаны 

            testCache.Get("Key46"); // увеличиваем число обращений по ключу Key46 
            testCache.Get("Key46"); // теперь ключ Key01 с минимальным числом обращений 2 
            testCache.Put("Key47", "B"); // Добавляяем новый ключ

            Console.WriteLine("Таблица после записи 2й новой пары ключ \\ значение :");
            
            testCache.Print(); // Ключ с минимальным числом обращений (Key01) перезаписан 

            testCache.Get("Key47"); // увеличиваем число обращений по ключу Key47 
            testCache.Get("Key47"); // после обращений к ключу Key 47 теперь ключи Key46 и Key02 с минимальным числом обращений
            testCache.Put("Key47", "C"); // Добавляяем новый ключ

            Console.WriteLine("Таблица после записи 3й новой пары ключ \\ значение :");
            testCache.Print(); // Ключ с минимальным числом обращений (Key46) перезаписан 

            Console.ReadKey();
        }
    }
}
