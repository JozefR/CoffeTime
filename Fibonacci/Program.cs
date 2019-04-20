using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fibo = FibonacciFunc(6);
            var fibo2 = FibonacciFunc(15);

            var dyna = FibonacciDynamic(6, new int [6]);
            var dyna2 = FibonacciDynamic(15, new int [15]);
        }

        private static int FibonacciFunc(int x)
        {
            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            return FibonacciFunc(x - 1) + FibonacciFunc(x - 2);
        }

        private static int FibonacciDynamic(int x, int[] helpArray)
        {
            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            if (helpArray[x - 1] == 0)
            {
                helpArray[x - 1] = FibonacciDynamic(x - 1, helpArray);
            }

            if (helpArray[x - 2] == 0)
            {
                helpArray[x - 2] = FibonacciDynamic(x - 2, helpArray);
            }

            return helpArray[x - 2] + helpArray[x - 1];
        }
    }
}