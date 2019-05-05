using System;
using AlgorithmsDataStructures2;

namespace BBSTgen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = BalancedBST.GenerateBBSTArray(new int[] {
                    31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21,
                    20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10,
                    9, 8, 7, 6, 5, 4, 3, 2, 1
            });
            PrintArray(result);

            result = BalancedBST.GenerateBBSTArray(new int[] {
                15, 14, 13, 12, 11, 10, 9, 8,
                7, 6, 5, 4, 3, 2, 1
            });
            PrintArray(result);

            result = BalancedBST.GenerateBBSTArray(new int[] { 7, 6, 5, 4, 3, 2, 1 });
            PrintArray(result);

            result = BalancedBST.GenerateBBSTArray(new int[] { 3, 2, 1 });
            PrintArray(result);

            Console.ReadKey();
        }
        static void PrintArray(int[] array)
        {
            Console.WriteLine("Дерево в виде массива:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
