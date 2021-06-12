using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {5, 3, 5, 2, 10, 6, 7};
            int[] array2 = {11, 3, 4, 5, 10, 2, 5, 6};

            PrintResults(InsertionSort(array));
            PrintResults(InsertionSortRefactored(array2));
        }

        private static int[] InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var leftIndex = i - 1;

                while (leftIndex > 0 && array[leftIndex] > key)
                {
                    array[leftIndex + 1] = array[leftIndex];
                    leftIndex -= 1;
                }

                array[leftIndex + 1] = key;
            }

            return array;
        }

        private static int[] InsertionSortRefactored(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var leftIndex = i - 1;
                Insert(array, leftIndex, key);
            }

            return array;
        }

        private static void Insert(int[] array, int leftIndex, int key)
        {
            while (leftIndex > 0 && array[leftIndex] > key)
            {
                array[leftIndex + 1] = array[leftIndex];
                leftIndex = leftIndex - 1;
            }

            array[leftIndex + 1] = key;
        }

        private static void PrintResults(int[] results)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}