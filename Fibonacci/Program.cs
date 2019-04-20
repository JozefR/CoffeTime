using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fibo = FibonacciFunc(6);
        }

        private static int FibonacciFunc(int x)
        {
            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            return FibonacciFunc(x - 1) + FibonacciFunc(x - 2);
        }
    }
}