using System;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = (int)Math.Pow(2, depth) - 1;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            // ищем в массиве индекс ключа
            if (Tree[0] == null) return null;
            int? currentKey = Tree[0];
            int index = 0;

            while (true)
            {
                if (key == currentKey) return index; // ключ найден

                if (key < currentKey)
                    index = 2 * index + 1; // двигаемся влево
                else
                    index = 2 * index + 2; // двигаемся вправо
                if (index < Tree.Length)  // проверка, не превышена ли макс. глубина дерева
                {
                    currentKey = Tree[index];

                    if (currentKey == null)
                        return -index; // индекс незаполненного слота
                }
                else break; // глубина превышена
            }

            return null; // ключ не найден, дерево пройдено до макс. глубины
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            return -1;
            // индекс добавленного/существующего ключа или -1 если не удалось
        }

    }
}