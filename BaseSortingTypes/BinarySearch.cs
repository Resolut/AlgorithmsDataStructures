using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class BinarySearch
    {
        public int[] array;
        public int left;
        public int right;
        private int findFlag;
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

                this.array = array;
                findFlag = 0;
                left = 0;
                right = array.Length - 1;
            }
            catch 
            {
                Console.WriteLine("Возникло исключение");
                throw;
            }
        }

        public int GetResult() 
        {
            return findFlag;
        }

        public void Step(int N)
        {
            if (findFlag != 0)
                return;

            int mid = (left + right) / 2;

            if (array[mid] == N) 
            { 
                findFlag = 1;
                return; 
            }
            else if (N < array[mid])
                right = mid - 1;
            else 
                left = mid + 1;

            if (left > right)
                findFlag = -1;
        }
    }
}
