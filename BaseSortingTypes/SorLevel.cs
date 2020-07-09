using System;
using System.Collections.Generic;

namespace SortSpace
{
    public static class SortLevel
    {
        public static void SelectionSortStep(int[] array, int i)
        {
            if (array.Length <= 1) return;

            int minIndex = i + 1;
            for (int j = i + 1; j < array.Length; ++j)
            {
                if (array[j] < array[minIndex]) 
                { 
                    minIndex = j;
                }
            }

            if (array[i] > array[minIndex]) 
            {
                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }

        public static bool BubbleSortStep(int[] array)
        {
            bool unShuffled = true;
            if (array.Length <= 1) return unShuffled;
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int tmp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = tmp;
                    unShuffled = false;
                }
            }

            return unShuffled;
        }

        public static void InsertionSortStep(int[] array, int step, int index)
        {
            if (array.Length <= 1) return;

            for (int i = index; i < array.Length-1; i += step)
            {
                for (int j = i; j >= 0 && (j + step < array.Length); j -= step) 
                {
                    if (array[j] > array[j + step]) 
                    {
                        int tmp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = tmp;
                    }
                }
            }
        }

        public static List<int> KnuthSequence(int array_size) 
        {
            // TODO реализовать генерацию последовательности
            return new List<int> { }; 
        }
    }
}