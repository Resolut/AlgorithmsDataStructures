using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private class Node

        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T _value, Node next = null, Node prev = null)
            {
                Value = _value;
                Next = next;
                Prev = prev;
            }
        }

        public LinkedList<T> stackObject;

        public Stack()
        {
            stackObject = new LinkedList<T>();
        }

        public int Size()
        {		  
            return stackObject.Count;
        }

        public T Pop()
        {
            LinkedListNode<T> lastNode;

            if (stackObject.Count != 0)
            {
                lastNode = stackObject.Last;
                stackObject.RemoveLast();

                return lastNode.Value;
            }

            return default(T);
        }

        public void Push(T val)
        {
            stackObject.AddLast(val);
        }

        public T Peek()
        {
            LinkedListNode<T> node;

            if (stackObject.Count != 0)
            {
                node = stackObject.First;

                return node.Value;
            }

            return default(T);
        }
    }
}