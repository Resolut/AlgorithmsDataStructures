﻿using System;
using System.Collections.Generic;

namespace SortSpace
{
    public static class SortLevel
    {
        public static void SelectionSortStep(ref int[] array, int i)
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

        public static bool BubbleSortStep(ref int[] array)
        {
            bool unshuffled = true;
            if (array.Length <= 1) return unshuffled;
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int tmp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = tmp;
                    unshuffled = false;
                }
            }

            return unshuffled;
        }
    }
}