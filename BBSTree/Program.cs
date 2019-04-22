using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBSTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = AlgorithmsDataStructures2.BalancedBST.GenerateBBSTArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
