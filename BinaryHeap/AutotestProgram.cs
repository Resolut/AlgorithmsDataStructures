using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи
        public int HeapSize;    // размер кучи
        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            int tree_size = (int)Math.Pow(2, depth + 1) - 1;
            HeapArray = new int[tree_size];

            for (int i = 0; i < a.Length; i++) Add(a[i]); // перестроение кучи с каждым добавлением ключа 
        }

        public int GetMax()
        {
            if (HeapArray == null || HeapSize == 0) return -1; // если куча пуста

            int maxKey = HeapArray[0];

            HeapArray[0] = HeapArray[HeapSize - 1];
            HeapArray[HeapSize - 1] = 0;
            HeapSize--;
            SiftDown(0); // перестроение дерева

            return maxKey;
        }

        public bool Add(int key)
        {
            if (HeapSize == HeapArray.Length) return false; // если вся куча заполнена

            int index = HeapSize;                           // индекс первого свободного слота
            HeapArray[index] = key;
            int parentIndex = (index - 1) / 2;              // индекс родительского узла

            while (index > 0 && parentIndex >= 0)
            {
                if (HeapArray[index] > HeapArray[parentIndex])
                {
                    int temp = HeapArray[index];
                    HeapArray[index] = HeapArray[parentIndex];
                    HeapArray[parentIndex] = temp;
                }

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
            HeapSize++;

            return true;
        }

        private void SiftDown(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            if (left < HeapSize)
            {
                if (HeapArray[index] < HeapArray[left])
                {
                    int temp = HeapArray[index];
                    HeapArray[index] = HeapArray[left];
                    HeapArray[left] = temp;

                    SiftDown(left);
                }
            }
            if (right < HeapSize)
            {
                if (HeapArray[index] < HeapArray[right])
                {
                    int temp = HeapArray[index];
                    HeapArray[index] = HeapArray[right];
                    HeapArray[right] = temp;

                    SiftDown(right);
                }
            }
        }
    }
}