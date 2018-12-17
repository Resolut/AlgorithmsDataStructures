using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private LinkedList<T> stackObject;

        public Stack()
        {
            // инициализация внутреннего хранилища стека
            stackObject = new LinkedList<T>();
        }

        public int Size()
        {
            // размер текущего стека		  
            return stackObject.Count;
        }

        public T Pop()
        {
            // ваш код
            if (stackObject.Count != 0)
            {
                lastNode = stackObject.Last();
                stackObject.RemoveLast();
            }
            return default(T); // null, если стек пустой
        }

        public void Push(T val)
        {
            // ваш код
            stackObject.AddLast(val);
        }

        public T Peek()
        {
            // ваш код
            if (stackObject.Count != 0)
                return stackObject.Last();

            return default(T); // null, если стек пустой
        }
    }
}

}