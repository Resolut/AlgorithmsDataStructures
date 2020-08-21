using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        private readonly List<T> items;

        public PowerSet()
        {
            items = new List<T>();
        }

        /// <summary>
        /// Определяет количество элементов в текущем множестве
        /// </summary>
        /// <returns>количество элементов во множестве</returns>
        public int Size()
        {
            return items.Count;
        }
        /// <summary>
        /// производит добавление элемента в текущее множество, не допуская добавление дубликатов во множество
        /// </summary>
        /// <param name="value">добавляемый элемент</param>
        public void Put(T value)
        {
            if (!Get(value))
                items.Add(value);
        }

        /// <summary>
        /// осуществляет проверку нахождения элемента в множестве 
        /// </summary>
        /// <param name="value">элемент, который предполагается найти в текущем множестве</param>
        /// <returns>возвращает true если value имеется в множестве, иначе false</returns>
        public bool Get(T value)
        {
            return items.Contains(value);
        }

        /// <summary>
        /// производит удаление элемента, если элемент входит в текущее множество 
        /// </summary>
        /// <param name="value">удаляемый элемент</param>
        /// <returns>возвращает true, если элемент найден в текущем множестве и удаление было произвеедено, иначе false</returns>
        public bool Remove(T value)
        {
            return items.Remove(value);
        }

        /// <summary>
        /// вычисляет и возвращает новое множество-перечение текущего множества с множеством set2 
        /// </summary>
        /// <param name="set2">множество типа значений типа T</param>
        /// <returns>множество-пересечение PowerSet<T> текущего множества и множества set2</returns>
        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            PowerSet<T> interSet = new PowerSet<T>();

            foreach (T item in items)
            {
                // добавление всех элементов первого множества, которые присутствуют и во втором множестве
                if (set2.items.Contains(item))
                {
                    interSet.Put(item);
                }
            }

            return interSet;
        }

        /// <summary>
        /// вычисляет и возвращает новое множество-объединение текущего множества со множеством set2 
        /// </summary>
        /// <param name="set2">множество типа значений типа T</param>
        /// <returns>множество-объединение PowerSet<T> текущего множества со множеством set2</returns>
        public PowerSet<T> Union(PowerSet<T> set2)
        {
            PowerSet<T> unionSet = new PowerSet<T>();

            foreach (T item in items)
            {
                // добавление всех элементов первого множества
                unionSet.Put(item);
            }

            foreach (T item in set2.items)
            {
                // добавление всех элементов второго множества, которые отсутствуют в первом
                if (!Get(item))
                {
                    unionSet.Put(item);
                }
            }

            return unionSet;
        }

        /// <summary>
        /// вычисляет и возвращает новое множество - разницу текущего множества и множества set2 
        /// </summary>
        /// <param name="set2">множество PowerSet<T> значений типа T</param>
        /// <returns>множество PowerSet<T> разница текущего множества и множества set2</returns>
        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            PowerSet<T> difSet = new PowerSet<T>();

            foreach (T item in items)
            {
                // добавляем все элементы первого множества
                difSet.Put(item);
            }

            foreach (T item in set2.items)
            {
                // удаляем все элементы второго множества, которые присутствуют в первом
                difSet.Remove(item);
            }

            return difSet;
        }

        /// <summary>
        /// определяет проверку того, что множество, передаваемое в параметре, является подмножеством текущего множества
        /// </summary>
        /// <param name="set2">множество элементов типа T</param>
        /// <returns>возвращает true если set2 есть подмножество текущего элемента, иначе false</returns>
        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (T item in set2.items)
            {
                // провекра, что все элементы второго множества присутствуют в первом
                if (!Get(item)) return false;
            }

            return true;
        }
    }
}