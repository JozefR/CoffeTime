using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {-2, -10, 0, 1, 3, 5, 2, 10, 6, 7};
            int[] array2 = new[] {-1, -7, -4, 0, 5, 30, 4, 3, 2, -5};
            //var sortedArray = selectionSort(array);
            var sortedArray = selectionSortRepeat(array2);
        }

        private static int[] selectionSortRepeat(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int indexOfMinimum = indexOfMin(array, i);

                if (indexOfMinimum != i)
                {
                    Swap(array, i, indexOfMinimum);
                }
            }

            return array;
        }

        private static int indexOfMin(int[] array, int i)
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

        private static int[] selectionSortRefactored(int[] array)
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
    }
}