using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            int[] array2 = {1, 3, 4, 5, 10, 5, 6};
            int[] sortedArray = insertionSort(array);

            // doesnt work correctly!
            int[] sortedArray2 = insertionSortRefactored(array2);
        }

        private static int[] insertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var leftIndex = i - 1;
                
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
                for (int sortedIndex = array.Length - 1; sortedIndex > 0; sortedIndex--)
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