using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        private BitArray bloomFilter;

        public BloomFilter(int f_len)
        {
            filter_len = f_len; // для тестов передавать 32
            bloomFilter = new BitArray(filter_len);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            const int MULTIPLIER = 17; // 17 - для тестов, в общем случае должно быть случайное число
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
            const int MULTIPLIER = 223; // 223 - для тестов, в общем случае должно быть случайное число
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
            bloomFilter.Set(Hash1(str1), true);
            bloomFilter.Set(Hash2(str1), true);
        }

        public bool IsValue(string str1)
        {
            if (bloomFilter.Get(Hash1(str1)) && bloomFilter.Get(Hash2(str1))) return true;

            return false;
        }
    }
}