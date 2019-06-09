using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibo2 = FibonacciFunc(15);

            var dyna = FibonacciDynamic(6, new int [6]);
            var  dyna2 = FibonacciDynamic(15, new int [15]);

            var down = FibonacciFromDown(6);
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

            return helpArray[x - 1] + helpArray[x - 2];
        }

        private static int FibonacciFromDown(int x)
        {
            var array = new int[x + 1];

            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i <= x; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            var result = array[x];

            return result;
        }
    }
}