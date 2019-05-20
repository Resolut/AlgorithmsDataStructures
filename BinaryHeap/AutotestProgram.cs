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

            for (int i = 0; i < a.Length; i++)
            {
            Add(a[i]);
            }
        }

        public int GetMax()
        {
            // TODO реализовать перестроение кучи
            // вернуть значение корня и перестроить кучу
            return -1; // если куча пуста
        }

        public bool Add(int key)
        {
            int index = Array.IndexOf(HeapArray, 0);    // первый свободный слот
            if (index == -1) return false;              // вся куча заполнена

            HeapArray[index] = key;
            int parent = (index - 1) / 2;              // индекс родительского узла

            while (index > 0 && parent >= 0)
            {
                if (HeapArray[index] > HeapArray[parent]) {
                    int temp = HeapArray[index];
                    HeapArray[index] = HeapArray[parent];
                    HeapArray[parent] = temp;
                }
                index = parent;
                parent = (index - 1) / 2;
            }

            return true;
        }

    }
}