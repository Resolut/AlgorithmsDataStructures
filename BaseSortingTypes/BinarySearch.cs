using System;

namespace SortSpace
{
    public class BinarySearch
    {
        public int[] Array;
        public int Left;
        public int Right;
        private int FindFlag;
        public BinarySearch(int[] Аrray)
        {
            try
            {
                if (Аrray == null)
                {
                    throw new ArgumentNullException("Передан null в качестве аргумента.");
                }

                if (Аrray.Length == 0)
                {
                    throw new ArgumentException("Parameter cannot be null or empty.");
                }

                this.Array = Аrray;
                FindFlag = 0;
                Left = 0;
                Right = Аrray.Length - 1;
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
            }

            if (N < Array[mid])
                Right = mid - 1;
            else if (N > Array[mid])
                Left = mid + 1;
            
            mid = (Left + Right) / 2;
            if (Array[mid] == N)
            {
                FindFlag = 1;
            }
            else if (Left >= Right)
            {
                if (FindFlag != 1)
                    FindFlag = -1;
            }
        }
    }
}
