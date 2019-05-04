using System;

namespace Easy.Median
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var array = new[] {1, 3, 5, 2, 3, 7, 8, 9, 10, 11};
            FindMedian(array);
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