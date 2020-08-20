using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortSpace
{
    public class BinarySearch
    {
        public int left;
        public int right;
        private int findFlag;
        public BinarySearch(int[] array) 
        {
            findFlag = 0;
            left = 0;
            right = array.Length - 1;
        }

        public int GetResult() 
        {
            return findFlag;
        }

        public void Step(int N) 
        {
        
        }
    }
}
