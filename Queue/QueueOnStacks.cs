using System;
using System.Collections.Generic;

namespace QueueBasedStack
{
    public class Queue<T>
    {
        private int count;
        Stack<T> headStack;
        Stack<T> tailStack;

        public Queue()
        {
            headStack = new Stack<T>();
            tailStack = new Stack<T>();
            count = 0;
        }

        public void Enqueue(T item)
        {
            tailStack.Push(item);
            ++count;
        }

        public T Dequeue()
        {
            T lastItem = default(T);
            int innerCount = Size();

            while (innerCount > 0)
            {
                headStack.Push(tailStack.Pop());
                lastItem = headStack.Pop();
                --innerCount;
            }

            if (count > 0) --count;
            else count = 0;

            return lastItem;
        }

        public int Size()
        {
            return count;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> testQue = new Queue<int>();
            testQue.Enqueue(1);
            testQue.Enqueue(2);
            testQue.Enqueue(3);
            testQue.Enqueue(4);

            Console.WriteLine("Размер очереди до изъятия элемента: {0}", testQue.Size());
            int firstElement = testQue.Dequeue();
            Console.WriteLine("Первый элемент из очереди: {0}", firstElement);
            Console.WriteLine("Размер очереди после изъятия: {0}", testQue.Size());

            Console.ReadKey();
        }
    }
}