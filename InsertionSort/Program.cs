using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            int[] array2 = {1, 3, 4, 5, 6, 7, 2};
            int[] sortedArray = insertionSort(array);
            int[] sortedArray2 = insertionSortRefactored(array2);
        }

        private static int[] insertionSort(int[] array)
        {
            for (int sortedIndex = 0; sortedIndex < array.Length; sortedIndex++)
            {
                var key = array[sortedIndex];
                var leftIndex = sortedIndex - 1;
                
                while (leftIndex > 0 && array[leftIndex] > key)
                {
                    array[leftIndex + 1] = array[leftIndex];
                    leftIndex = leftIndex - 1;
                }

                array[leftIndex + 1] = key;
            }

            return array;
        }
        
            private static int[] insertionSortRefactored(int[] array)
            {
                for (int sortedIndex = 0; sortedIndex < array.Length; sortedIndex++)
                {
                    var key = array[sortedIndex];
                    var leftIndex = sortedIndex - 1;
                    
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
    }
}