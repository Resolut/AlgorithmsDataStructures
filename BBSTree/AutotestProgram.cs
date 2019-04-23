using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            int[] arrBST = new int[a.Length]; // результирующий массив со структурой BBST
            int index = 0;
            int middleIndex = a.Length / 2;                                 // индекс центрального элемента массива
            arrBST[index] = a[middleIndex];                                 // корень дерева
            arrBST[2 * index + 1] = a[middleIndex / 2];                     // сюда вернуть левого потомка с помощью рекурсии
            arrBST[2 * index + 2] = a[middleIndex + middleIndex / 2 + 1];   // сюда вернуть правого потомка с помощью рекурсии
            // нужно как-то узнать индекс следующего узла

            return arrBST; 
            
        }
        // TODO возможно, потребуется создать вспомогательную рекурсивную функцию 
        private static int Recursive(int[] arr)
        {
            // выход из рекурсии : индекс превысил длину массива??

            return 0;
        }
    }
}