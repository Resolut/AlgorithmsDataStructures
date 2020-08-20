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
                if(array == null || array.Length == 0) 
                {
                    throw new Exception("Ссылка на массив null или массив не содержит элементов.");
                }

                this.array = array;
                findFlag = 0;
                left = 0;
                right = array.Length - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
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
                findFlag = 1;
            else if (N < array[mid])
                right = mid - 1;
            else 
                left = mid + 1;

            if (left == right)
                findFlag = -1;
        }
    }
}
