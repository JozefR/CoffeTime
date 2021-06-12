using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {-2, -10, 0, 1, 3, 5, 2, 10, 6, 7};

            PrintResults(SelectionSort(array));
        }

        private static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++) // (n - 1)
            {
                int minimum = array[i];
                int minimumIndex = i;

                for (int j = minimumIndex + 1; j < array.Length; j++) // (n - i)
                {
                    if (minimum > array[j])
                    {
                        minimum = array[j];
                        minimumIndex = j;
                    }
                }
                Swap(array, i, minimumIndex); // O(1)
            }
            return array;
        }

        private static int[] SelectionSortRepeat(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int indexOfMinimum = IndexOfMin(array, i);

                if (indexOfMinimum != i)
                {
                    Swap(array, i, indexOfMinimum);
                }
            }

            return array;
        }

        private static int IndexOfMin(int[] array, int i)
        {
            var minimum = array[i];
            var indexOfMinimum = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (minimum > array[j])
                {
                    minimum = array[j];
                    indexOfMinimum = j;
                }
            }

            return indexOfMinimum;
        }

        private static int[] SelectionSortRefactored(int[] array)
        {
            for (int sortedIndex = 0; sortedIndex < array.Length; sortedIndex++)
            {
                int indexOfMinimum = IndexOfMinimum(array, sortedIndex);
                Swap(array, sortedIndex, indexOfMinimum);
            }

            return array;
        }

        private static void Swap(int[] array, int sortedIndex, int indexOfMinimum)
        {
            var temp = array[sortedIndex];
            array[sortedIndex] = array[indexOfMinimum];
            array[indexOfMinimum] = temp;
        }

        private static int IndexOfMinimum(int[] array, int startIndex)
        {
            var minimumIndex = startIndex;
            var minimumValue = array[startIndex];

            for (int secondIndex = startIndex; secondIndex < array.Length; secondIndex++)
            {
                if (minimumValue > array[secondIndex])
                {
                    minimumIndex = secondIndex;
                    minimumValue = array[secondIndex];
                }
            }

            return minimumIndex;
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