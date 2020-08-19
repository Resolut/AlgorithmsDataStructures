using System;
using System.Collections.Generic;

namespace SortSpace
{
    class KSort
    {
        string[] items;
        public KSort()
        {
            int maxSize = 800;
            items = new string[maxSize];
        }

        public int Index(string str)
        {
            string pattern = "abcdefgh";
            int bigDigit;

            if (pattern.Contains(str[0].ToString()))
                bigDigit = pattern.IndexOf(str[0]) * 100;
            else
                return -1;

            int midDigit;

            if (!int.TryParse(str[1].ToString(), out midDigit))
                return -1;

            midDigit *= 10;

            int smallDigit;

            if (!int.TryParse(str[2].ToString(), out smallDigit))
                return -1;

            return bigDigit + midDigit + smallDigit;
        }

        public bool Add(string str)
        {
            int index = Index(str);
            if (index == -1)
                return false;

            items[index] = str;

            return true;
        }
    }
}
