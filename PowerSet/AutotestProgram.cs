using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        public int size;
        public T[] slots;

        public PowerSet(int sz)
        {
            size = sz;
            slots = new T[size];
            for (int i = 0; i < size; i++) slots[i] = default(T);
        }

        /// <summary>
        /// Вычисляет и возвращает хэш для передаваемого значения
        /// </summary>
        /// <param name="value">значение типа T для которого требуется вычислить хэш</param>
        /// <returns>Хэш типа int</returns>
        public int HashFun(T value)
        {
            int hash = 0;
            if (value != null)

            {
                if (typeof(T) == typeof(String) || typeof(T) == typeof(int) || typeof(T) == typeof(double))
                {
                    string val = value.ToString();

                    for (int i = 0; i < val.Length; i++)
                    {
                        hash += val[i];
                    }
                    hash %= size;
                }
            }

            return hash;
        }

        /// <summary>
        /// Определяет количество элементов в текущем множестве
        /// </summary>
        /// <returns>количество элементов во множестве</returns>
        public int Size() => size;

        /// <summary>
        /// производит добавление элемента в текущее множество, не допуская добавление дубликатов во множество
        /// </summary>
        /// <param name="value">добавляемый элемент</param>
        public void Put(T value)
        {
            if (slots[HashFun(value)] == null)
                slots[HashFun(value)] = value;
        }

        /// <summary>
        /// осуществляет проверку нахождения элемента в множестве 
        /// </summary>
        /// <param name="value">элемент, который предполагается найти в текущем множестве</param>
        /// <returns>возвращает true если value имеется в множестве, иначе false</returns>
        public bool Get(T value)
        {
            if (slots[HashFun(value)].Equals(value))
                return true;

            return false;
        }

        /// <summary>
        /// производит удаление элемента, если элемент входит в текущее множество 
        /// </summary>
        /// <param name="value">удаляемый элемент</param>
        /// <returns>возвращает true, если элемент найден в текущем множестве и удаление было произвеедено, иначе false</returns>
        public bool Remove(T value)
        {
            if (size == 0) return false;

            if (Get(value))
            {
                T[] outputArr = new T[size - 1];
                int counter = 0;

                for (int i = 0; i < slots.Length; i++) // копируем массив за вычетом удаляемого элемента
                {
                    if (i == HashFun(value)) continue;
                    outputArr[counter] = slots[i];
                    ++counter;
                }
                slots = outputArr;

                return true;
            }
            // иначе false
            return false;
        }
        /// <summary>
        /// вычисляет и возвращает новое множество-перечение текущего множества с множеством set2 
        /// </summary>
        /// <param name="set2">множество типа значений типа T</param>
        /// <returns>множество-пересечение PowerSet<T> текущего множества и множества set2</returns>
        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            PowerSet<T> outSet;
            int finalSize = 0; // конечный размер для возвращаемого множества

            // возвращаемому множеству задаем временный размер большего из двух множеств
            if (size < set2.size)
                outSet = new PowerSet<T>(set2.size);
            else
                outSet = new PowerSet<T>(size);

            for (int i = 0; i < size; i++)
            {
                if (set2.Get(slots[i]))
                {
                    outSet.Put(slots[i]);
                    ++finalSize;
                }
            }

            T[] tempArr = new T[finalSize];
            int counter = 0;

            for (int i = 0; i < outSet.size; i++) // копируем массив выходного множества outSet за вычетом элементов, равным null
            {
                if (outSet.slots[i] == null) continue;
                tempArr[counter] = outSet.slots[i];
                ++counter;
            }
            outSet.slots = tempArr;

            return outSet;
        }

        /// <summary>
        /// вычисляет и возвращает новое множество-объединение текущего множества со множеством set2 
        /// </summary>
        /// <param name="set2">множество типа значений типа T</param>
        /// <returns>множество-объединение PowerSet<T> текущего множества со множеством set2</returns>
        public PowerSet<T> Union(PowerSet<T> set2)
        {
            PowerSet<T> outSet = new PowerSet<T>(size + set2.size);
            int finalSize = 0; // конечный размер для возвращаемого множества

            for (int i = 0; i < size; i++) // добавляем все элементы первого множества
            {
                outSet.Put(slots[i]);
            }

            for (int i = 0; i < set2.size; i++) // добавляем все элементы второго множества, которые отсутствуют в первом
            {
                if (!Get(set2.slots[i]))
                {
                    outSet.Put(set2.slots[i]);
                    ++finalSize;
                }
            }

            T[] tempArr = new T[finalSize];
            int counter = 0;

            for (int i = 0; i < outSet.size; i++) // копируем массив выходного множества outSet за вычетом элементов, равным null
            {
                if (outSet.slots[i] == null) continue;
                tempArr[counter] = outSet.slots[i];
                ++counter;
            }
            outSet.slots = tempArr;

            return outSet;
        }

        /// <summary>
        /// вычисляет и возвращает новое разницу текущего множества и множества set2 
        /// </summary>
        /// <param name="set2">множество типа значений типа T</param>
        /// <returns>множество PowerSet<T> разница текущего множества и множества set2</returns>
        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            PowerSet<T> outSet = new PowerSet<T>(size);
            int finalSize = 0; // конечный размер для возвращаемого множества

            for (int i = 0; i < set2.size; i++) // добавляем все элементы второго множества, которые отсутствуют в первом
            {
                if (!Get(set2.slots[i]))
                {
                    outSet.Put(set2.slots[i]);
                    ++finalSize;
                }
            }

            T[] tempArr = new T[finalSize];
            int counter = 0;

            for (int i = 0; i < outSet.size; i++) // копируем массив выходного множества outSet за вычетом элементов, равным null
            {
                if (outSet.slots[i] == null) continue;
                tempArr[counter] = outSet.slots[i];
                ++counter;
            }
            outSet.slots = tempArr;

            return outSet;
        }

        /// <summary>
        /// определяет проверку того, что множество передаваемое в параметре является подмножеством текущего множества
        /// </summary>
        /// <param name="set2">множество элементов типа T</param>
        /// <returns>возвращает true если set2 есть подмножество текущего элемента, иначе false</returns>
        public bool IsSubset(PowerSet<T> set2)
        {
            for (int i = 0; i < set2.size; i++) // провекра, что все элементы второго множества присутствуют в первом
            {
                if (!Get(set2.slots[i])) return false;
            }

            return true;
        }
    }
}