using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            mergeSort(array, 0, array.Length - 1);
        }

        private static void mergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (int)(left + right) / 2;
                mergeSort(array, left, mid);
                mergeSort(array, mid + 1, right);
                merge(array, left, mid, right);
            }
        }

        private static void merge(int[] array, int left, int mid, int right)
        {
            var n1 = mid - left + 1;
            var n2 = right - mid;
            var lowHalf = new int[n1];
            var highHalf = new int[n2];

            var k = left;
            var i = 0;
            var j = 0;
            for (i = 0; i < n1; i++) {
                lowHalf[i] = array[left + i];
            }
            for (j = 0; j < n2; j++) {
                highHalf[j] = array[mid + 1 + j];
            }

            k = left;
            i = 0;
            j = 0;

            while (i < n1 && j < n2)
            {
                if (lowHalf[i] <= highHalf[j])
                {
                    array[k] = lowHalf[i];
                    i++;
                }
                else
                {
                    array[k] = highHalf[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                array[k] = lowHalf[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = highHalf[j];
                j++;
                k++;
            }
        }
    }
}