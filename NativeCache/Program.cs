using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int GetMinHitsElem()
        {
            return Array.IndexOf(hits, hits.Min());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
