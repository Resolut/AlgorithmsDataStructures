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
            int[] result = AlgorithmsDataStructures2.BalancedBST.GenerateBBSTArray(new int[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            Console.WriteLine("Отсортированный входной массив:");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
    }
}
