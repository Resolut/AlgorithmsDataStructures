using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        private int bloomFilter;

        public BloomFilter(int f_len)
        {
            filter_len = f_len; // для тестов передавать 32
            // создаём битовый массив длиной f_len ...
            bloomFilter = 0; // маска из 32 битов
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            const int MULTIPLIER = 17; // 17 - для тестов
            int code = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                if (i != 0)
                    code = (code * MULTIPLIER + (int)str1[i]) % filter_len;
            }
            
            return code;
        }

        public int Hash2(string str1)
        {
            const int MULTIPLIER = 223; // 223 - для тестов
            int code = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                if (i != 0)
                    code = (code * MULTIPLIER + (int)str1[i]) % filter_len;
            }
            
            return code;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            // bloomFilter = bloomFilter | 1 << Hash2(str1);

            bloomFilter = (bloomFilter | 1 << Hash1(str1)) | 1 << Hash2(str1);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int hashMask = 0;
            hashMask = (hashMask | 1 << Hash1(str1)) | 1 << Hash2(str1);

            if (hashMask == bloomFilter) return true;

            return false;
        }
    }
}