using System;

namespace SortSpace
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
            while (true)
            {
                int maxIndex = index; // индекс для потомка
                int left = index * 2 + 1;
                int right = index * 2 + 2;

                // определяем потомка с ключом больше, чем ключ родителя 
                if (left < HeapSize && HeapArray[left] > HeapArray[maxIndex]) maxIndex = left;
                if (right < HeapSize && HeapArray[right] > HeapArray[maxIndex]) maxIndex = right;
                if (maxIndex == index) break;

                int temp = HeapArray[index];
                HeapArray[index] = HeapArray[maxIndex];
                HeapArray[maxIndex] = temp;

                index = maxIndex;
            }
        }
    }

    public class HeapSort
    {
        public Heap HeapObject;

        public HeapSort(int[] array)
        {
            int depth = (int)Math.Log(array.Length, 2);
            HeapObject = new Heap();
            HeapObject.MakeHeap(array, depth);
        }

        public int GetNextMax() { return HeapObject.GetMax(); }
    }
}
