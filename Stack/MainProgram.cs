using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stack
{
    public class Node
    {
        public object value;
        public Node next;
        public Node prev;
        public Node(object _value)
        {
            value = _value;
            next = null;
            prev = null;
        }

        public object GetValue()
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
            if (stackObject.Count != 0)
                return stackObject.Last();

            return null;
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            string postfixExpr = "8 2 + 5 * 9 + =";
            int total = CalculatePostfixExpr(postfixExpr);

            Console.WriteLine($"{postfixExpr} {total}");

            Console.ReadKey();
        }

        static bool CheckBalanceBracket(string bracketsSeq)
        {
            Stack stackBrackets = new Stack();

            int index = 0;
            while (index < bracketsSeq.Length)
                if (bracketsSeq[index] == ')' && stackBrackets.Size() == 0)
                    return false;
                else if (bracketsSeq[index] == '(')
                    stackBrackets.Push(new Node(1));
                else
                    stackBrackets.Pop();
            index++;

            return stackBrackets.Size() == 0;
        }

        static int CalculatePostfixExpr(string postfixExp)
        {
            Stack stack1 = new Stack();
            Stack stack2 = new Stack();
            int index = postfixExp.Length - 1;

            while (index >= 0)
            {
                if (postfixExp[index] != ' ')
                    stack1.Push(new Node(postfixExp[index]));
                index--;
            }

            int result = 0;
            while (stack1.Size() > 0)
            {
                int operand1;
                int operand2;

                switch (stack1.Peek().GetValue())
                {
                    case '+':
                        stack1.Pop();
                        operand1 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        operand2 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        stack2.Push(new Node(operand1 + operand2));
                        break;
                    case '-':
                        stack1.Pop();
                        operand1 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        operand2 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        stack2.Push(new Node(operand1 - operand2));
                        break;
                    case '*':
                        stack1.Pop();
                        operand1 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        operand2 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        stack2.Push(new Node(operand1 * operand2));
                        break;
                    case '/':
                        stack1.Pop();
                        operand1 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        operand2 = Convert.ToInt32(stack2.Pop().GetValue().ToString());
                        stack2.Push(new Node(operand1 / operand2));
                        break;
                    case '=':
                        stack1.Pop();
                        result = Convert.ToInt32(stack2.Peek().GetValue());
                        break;
                    default:
                        stack2.Push(stack1.Pop());
                        break;
                }
            }
            return result;
        }
    }
}
