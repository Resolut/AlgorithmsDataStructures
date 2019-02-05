using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            int hash = 0;
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    hash += value[i];
                }
                hash %= size;
            }

            return hash;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            int startSlot = HashFun(value);

            if (slots[startSlot] == null)
                return startSlot;
            else
            {
                int offset = startSlot;
                bool loopEnds = false; // флаг оповещает, что цикл прошёл до конца таблицы

                while (slots[offset] != null)
                {
                    offset += step;
                    if (offset >= slots.Length)
                    {
                        loopEnds = true;
                        offset -= slots.Length;
                    }
                    if (loopEnds && offset >= startSlot)
                        break;
                    if (slots[offset] == null)
                        return offset;
                }
            }

            return -1; // не удалось найти свободный слот из-за коллизий
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            int target = HashFun(value);

            if (slots[target] == null)
            {
                slots[target] = value;
                return target;
            }
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            return -1;
        }

        public int Find(string value)
        {
            //// находит индекс слота со значением, или -1
            //int startSlot = HashFun(value);

            //if (slots[startSlot] == value)
            //    return startSlot;
            //else
            //{
            //    int offset = startSlot;
            //    bool loopEnds = false; // флаг оповещает, что цикл прошёл до конца таблицы

            //    while (slots[offset] != null && offset < slots.Length)
            //    {
            //        if (offset + step >= slots.Length)
            //        {
            //            loopEnds = true;
            //            offset = offset + step - slots.Length;
            //        }
            //        if (loopEnds && offset >= startSlot)
            //            break;
            //        if (slots[offset] == value)
            //            return offset;

            //        offset += step;
            //    }
            //}

            //return -1;

            // находит индекс пустого слота для значения, или -1
            int startSlot = HashFun(value);

            if (slots[startSlot] == value)
                return startSlot;
            else
            {
                int offset = startSlot;
                bool loopEnds = false; // флаг оповещает, что цикл прошёл до конца таблицы

                while (slots[offset] != value)
                {
                    offset += step;
                    if (offset >= slots.Length)
                    {
                        loopEnds = true;
                        offset -= slots.Length;
                    }
                    if (loopEnds && offset == startSlot)
                        break;
                    if (slots[offset] == value)
                        return offset;
                }
            }

            return -1; // не удалось найти свободный слот из-за коллизий
        }
    }

}