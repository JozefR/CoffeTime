using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {1, 3, 5, 2, 10, 6, 7};
            var sortedArray = selectionSort(array);
        }

        private static int[] selectionSort(int[] array)
        {
            for (int firstIndex = 0; firstIndex < array.Length; firstIndex++)
            {
                int minimum = array[firstIndex];
                int minimumIndex = firstIndex;
                var temp = minimum;

                for (int secondIndex = minimumIndex + 1; secondIndex < array.Length; secondIndex++)
                {
                    if (minimum > array[secondIndex])
                    {
                        minimum = array[secondIndex];
                        minimumIndex = secondIndex;
                    }
                }
                
                array[minimumIndex] = temp;
                array[firstIndex] = minimum;
            }

            return array;
        }
    }
}