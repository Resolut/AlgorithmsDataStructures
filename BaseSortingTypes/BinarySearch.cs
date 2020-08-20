using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class BinarySearch
    {
        public int[] Array;
        public int Left;
        public int Right;
        private int FindFlag;
        public BinarySearch(int[] array) 
        {
            try 
            {
                if(array == null) 
                {
                    throw new ArgumentNullException("Передан null в качестве аргумента.");
                }

                if(array.Length == 0) 
                {
                    throw new ArgumentException("Parameter cannot be null or empty.");
                }

                this.Array = array;
                FindFlag = 0;
                Left = 0;
                Right = array.Length - 1;
            }
            catch 
            {
                Console.WriteLine("Возникло исключение");
                throw;
            }
        }

        public int GetResult() 
        {
            return FindFlag;
        }

        public void Step(int N)
        {
            if (FindFlag != 0)
                return;

            int mid = (Left + Right) / 2;

            if (Array[mid] == N) 
            { 
                FindFlag = 1;
                return; 
            }
            else if (N < Array[mid])
                Right = mid - 1;
            else 
                Left = mid + 1;

            if (Left > Right)
                FindFlag = -1;
        }
    }
}
