using System.Collections.Generic;
using System.Linq;

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

            for (int i = index; i < array.Length - 1; i += step)
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
            List<int> seqList = new List<int> { };
            if (array_size >= 0 && array_size <= 1)
                seqList.Add(1);

            for (int index = 0; array_size > KnuthRec(index); index++)
            {
                seqList.Insert(0, KnuthRec(index));
            }

            return seqList;
        }

        public static int KnuthRec(int step)
        {
            if (step == 0) return 1;
            return 3 * KnuthRec(step - 1) + 1;
        }

        public static int ArrayChunk(int[] M)
        {
            while (true)
            {
                int N = M[M.Length / 2];
                int N_i = M.Length / 2;
                int i1 = 0;
                int i2 = M.Length - 1;

                while (true)
                {
                    while (M[i1] < N)
                        ++i1;
                    while (M[i2] > N)
                        --i2;

                    if (i1 == i2 - 1 && M[i1] > M[i2])
                    {
                        int temp = M[i1];
                        M[i1] = M[i2];
                        M[i2] = temp;
                        break;
                    }

                    if (i1 == i2 || (i1 == i2 - 1 && M[i1] < M[i2]))
                    {
                        return N_i;
                    }

                    int temp1 = M[i1];
                    M[i1] = M[i2];
                    M[i2] = temp1;

                    if (M[i1] == N)
                        N_i = i1;
                    if (M[i2] == N)
                        N_i = i2;
                }
            }
        }

        public static int ArrayChunk(int[] M, int left, int right)
        {
            while (true)
            {
                int N = M[(left + right) / 2];
                int N_i = (left + right) / 2;
                int i1 = left;
                int i2 = right;

                while (true)
                {
                    while (M[i1] < N)
                        ++i1;
                    while (M[i2] > N)
                        --i2;

                    if (i1 == i2 - 1 && M[i1] > M[i2])
                    {
                        int temp = M[i1];
                        M[i1] = M[i2];
                        M[i2] = temp;
                        break;
                    }

                    if (i1 == i2 || (i1 == i2 - 1 && M[i1] < M[i2]))
                    {
                        return N_i;
                    }

                    int temp1 = M[i1];
                    M[i1] = M[i2];
                    M[i2] = temp1;

                    if (M[i1] == N)
                        N_i = i1;
                    if (M[i2] == N)
                        N_i = i2;
                }
            }
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int N = ArrayChunk(array, left, right);

                QuickSort(array, left, N - 1);
                QuickSort(array, N + 1, right);
            }
        }

        public static void QuickSortTailOptimization(int[] array, int left, int right)
        {
            int begin = left;
            int end = right;

            if (left < right)
            {
                int N = ArrayChunk(array, begin, end);
                if (left < end)
                {
                    QuickSortTailOptimization(array, begin, N - 1);
                }

                if (right > begin)
                {
                    QuickSortTailOptimization(array, N + 1, end);
                }
            }
        }

        public static List<int> KthOrderStatisticsStep(int[] Array, int L, int R, int k)
        {
            int N = ArrayChunk(Array, L, R);

            if (N < k)
                L = N + 1;
            else if (N > k)
                R = N - 1;

            return new List<int> { L, R };
        }

        public static List<int> MergeSort(List<int> list)
        {
            if (list.Count == 1)
                return list;

            List<int> left = list.GetRange(0, list.Count / 2);
            List<int> right = list.GetRange(list.Count / 2, list.Count - list.Count / 2);

            left = MergeSort(left);
            right = MergeSort(right);

            List<int> res = new List<int> { };

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() < right.First())
                {
                    res.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    res.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            if (left.Count > 0)
                left.ForEach(item => res.Add(item));
            else
                right.ForEach(item => res.Add(item));

            return res;
        }
    }
}