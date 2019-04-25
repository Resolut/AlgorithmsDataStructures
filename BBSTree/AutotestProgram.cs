using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] arrayBST;

        public static int[] GenerateBBSTArray(int[] a)
        {
            arrayBST = new int[a.Length];
            Array.Sort(a);
            // Вызвать рекурсивный метод, в котором происходит заполнение массива
            Add(a, 0);
            return a;

        }
        // TODO возможно, потребуется создать вспомогательную рекурсивную функцию 
        private static void Add(int[] arr, int index)
        {
            // выход из рекурсии : индекс превысил длину массива??
            
            int middle = arr.Length / 2;
            arrayBST[index] = arr[middle];
            int[] left = new int[arr.Length / 2];
            int[] right = new int [arr.Length / 2];
            Console.WriteLine("Левый массив:");
            foreach (var item in left)
            {

            Console.Write(item + " ");
            }
            Console.WriteLine();
            arr.CopyTo(right, 0);

            Console.WriteLine("Правый массив:");
            foreach (var item in right)
            {

                Console.Write(item + " ");
            }
            Console.WriteLine();

            //Add(left, 2 * index + 1);                     // сюда вернуть левого потомка с помощью рекурсии
            //Add(right, 2 * index + 2);

        }
    }
}