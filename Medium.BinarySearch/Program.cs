using System;

namespace Medium.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
            var target = 53;
            var nonExistingTarget = 98;

            var sln = binarySearch(primes, target);
            var sln2 = binarySearch(primes, nonExistingTarget);
        }

        private static int binarySearch(int[] array, int target)
        {
            int min = 0;
            int max = array.Length - 1;

            while (max > min)
            {
                var guess = (min + max) / 2;

                if (array[guess] == target)
                {
                    return guess;
                }

                if (array[guess] < target)
                {
                    min = guess + 1;
                }
                else
                {
                    max = guess - 1;
                }
            }

            return -1;
        }
    }
}