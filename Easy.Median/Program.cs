using System;

namespace Easy.Median
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var median = FindMedian(array);
        }

        private static int FindMedian(int[] array)
        {
            if (array.Length == 0)
                throw new Exception("empty");

            Array.Sort(array);
            int median;

            if (array.Length % 2 == 0)
            {
                int middle1 = array[array.Length / 2] - 1;
                int middle2 = array[array.Length / 2];
                median = (middle1 + middle2) / 2;
            }
            else
            {
                median = array[array.Length / 2];
            }

            return median;
        }
    }
}