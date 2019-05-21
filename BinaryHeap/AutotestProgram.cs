using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            int tree_size = (int)Math.Pow(2, depth + 1) - 1;
            HeapArray = new int[tree_size];

            for (int i = 0; i < a.Length; i++) { Add(a[i]); }
        }

        public int GetMax()
        {
            if (HeapArray == null || HeapArray[0] == 0) return -1; // если куча пуста

            int maxKey = HeapArray[0];
            int lastIndex = Array.FindLastIndex(HeapArray, (item) => item > 0); // индекс крайнего элемента
            HeapArray[0] = HeapArray[lastIndex];
            HeapArray[lastIndex] = 0;

            int index = 0;
            int maxChildIndex = HeapArray[index * 2 + 1] > HeapArray[index * 2 + 2] ? (index * 2 + 1) : (index * 2 + 2);

            while (index < lastIndex - 1 && maxChildIndex <= lastIndex)
            {
                if (HeapArray[index] < HeapArray[maxChildIndex])
                {
                    int temp = HeapArray[index];
                    HeapArray[index] = HeapArray[maxChildIndex];
                    HeapArray[maxChildIndex] = temp;
                }

                index = maxChildIndex;
                if ((index * 2 + 2) <= lastIndex )
                maxChildIndex = HeapArray[index * 2 + 1] > HeapArray[index * 2 + 2] ? (index * 2 + 1) : (index * 2 + 2);
            }

            return maxKey;
        }

        public bool Add(int key)
        {
            int index = Array.IndexOf(HeapArray, 0);    // первый свободный слот
            if (index == -1) return false;              // вся куча заполнена

            HeapArray[index] = key;
            int parentIndex = (index - 1) / 2;              // индекс родительского узла

            while (index > 0 && parentIndex >= 0)
            {
                if (HeapArray[index] > HeapArray[parentIndex]) {
                    int temp = HeapArray[index];
                    HeapArray[index] = HeapArray[parentIndex];
                    HeapArray[parentIndex] = temp;
                }

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }

            return true;
        }

    }
}