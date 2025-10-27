using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinStack stack = new MinStack();

            stack.Push(4);
            stack.Push(6);
            stack.Push(8);
            stack.Push(10);
            Console.WriteLine($"\n\n{stack.GetMin()}");

            stack.PrintStack();

            stack.Pop();
            stack.Pop();
            Console.WriteLine($"\n\n{stack.GetMin()}");

            stack.Push(3);
            stack.Push(3);

            stack.PrintStack();

            Console.WriteLine($"\n\n{stack.GetMin()}");

            stack.Pop();
            stack.PrintStack();
            Console.WriteLine($"\n\n{stack.GetMin()}");
        }

    }

    class MinStack
    {
        private List<int> minStack = new List<int>();
        private List<int> stack = new List<int>();
        public void Push(int value)
        {
            if (minStack.Count == 0 || value <= GetMin())
                minStack.Add(value);
            
            stack.Add(value);
        }
        public int Pop()
        {
            int lastIndex = stack.Count - 1;
            int value = stack[lastIndex];

            if (value == GetMin())
            {
                minStack.RemoveAt(minStack.Count -1);
            }

            stack.RemoveAt(lastIndex);
            return value;
        }
        public int GetMin()
        {
            return minStack[minStack.Count -1];
        }
        public void PrintStack()
        {
            for (int i = stack.Count - 1; i >= 0 ; i--)
            {
                Console.WriteLine($"Элемент: {i + 1} = {stack[i]}");
            }
            Console.WriteLine(new string('@', 20));
        }
    }
}
