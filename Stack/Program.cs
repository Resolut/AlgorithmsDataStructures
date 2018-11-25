using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Node
    {
        public int value;
        public Node next;
        public Node prev;
        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }

        public int GetValue()
        {
            return value;
        }
    }

    public class Stack
    {
        private LinkedList<Node> stackObject;

        public Stack()
        {
            stackObject = new LinkedList<Node>();
        }

        public int Size()
        {
            return stackObject.Count;
        }

        public void Push(Node _item)
        {
            stackObject.AddLast(_item);
        }

        public Node Pop()
        {
            Node lastNode = null;
            if (stackObject.Count() != 0)
            {
                lastNode = stackObject.Last();
                stackObject.RemoveLast();
            }

            return lastNode;
        }

        public Node Peek()
        {
            if (stackObject.Count() != 0)
                return stackObject.Last();
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
