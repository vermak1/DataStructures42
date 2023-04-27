using System;

namespace DataStructures42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestMyListOfStack();
        }

        private static void TestMyStack()
        {
            MyStack<Int32> stack = new MyStack<Int32>();

            stack.Push(123);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.MinValue);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.MinValue);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.MinValue);
        }

        private static void TestMyListOfStack()
        {
            ListOfStack<string> list = new ListOfStack<string>(2);

            for(int i = 0; i < 1000; i++)
            {
                list.Push(i.ToString());
            }

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(list.Pop());
            }
        }
    }
}
