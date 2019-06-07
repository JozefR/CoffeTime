using System;
using System.Collections.Concurrent;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            quickSort(array, 0, array.Length - 1);
        }

        #region quickSortMain
        private static void quickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                // all the real work happens in partition
                var pivot = partition(array, left, right);
                // divide arrays based on chosen pivot.
                quickSort(array, left, pivot - 1);
                quickSort(array, pivot + 1, right);
            }
        }
        #endregion

        #region partition
        private static int partition(int[] array, int left, int right)
        {
            // always pick the last elemenet as pivot
            int pivot = array[right];

            // all elements less then pivot to the left
            // all elements greater then pivot to the right
            int smaller = left - 1;
            int smallerRight = left;

            while (smallerRight < right)
            {
                if (array[smallerRight] <= pivot)
                {
                    smaller++;
                    swap(array, smaller, smallerRight);
                }

                smallerRight++;
            }

            // after sorting swap pivot
            swap(array, smaller + 1, right);

            // return pivot for divided array
            return smaller + 1;
        }
        #endregion

        #region swap
        private static void swap(int[] array, int smaller, int smallerRight)
        {
            int temp = array[smaller];
            array[smaller] = array[smallerRight];
            array[smallerRight] = temp;
        }
        #endregion
    }
}