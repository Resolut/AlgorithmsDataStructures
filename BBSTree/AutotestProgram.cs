using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            int[] left = new int[a.Length];
            int[] right = new int[a.Length];
            Array.Copy(a, 0, left, 0, a.Length / 2); // левая часть
            // Array.Copy(a, a.Length / 2 + 1, right, a.Length / 2 + 1, (a.Length-1) - (a.Length / 2)); // правая часть
            return left;
            
        }
    }
}