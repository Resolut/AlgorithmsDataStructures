namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            int hash = 0;
            if (key != null)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    hash += key[i];
                }
                hash %= size;
            }

            return hash;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            if (slots[HashFun(key)] == key) return true;

            return false;
        }

        public void Put(string key, T value)
        {
            // записываем значение ключа по хэш-функции
            slots[HashFun(key)] = key;

            // гарантированно записываем 
            // значение value по ключу key
            values[HashFun(key)] = value;
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            if (IsKey(key))
                return values[HashFun(key)];
            return default(T);
        }
    }
}