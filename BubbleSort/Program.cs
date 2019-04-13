using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            int[] array2 = {1, 3, 4, 5, 6, 7, 2};
            /*int[] sortedArray = bubbleSort(array);
            int[] sortedArray2 = bubbleSort(array2);*/

            var sortedArray3 = bubbleSort2(array);
        }

        private static int[] bubbleSort(int[] array)
        {
            bool continueOrdering;
            var sortedIndex = array.Length - 1;

            do
            {
                continueOrdering = false;

                for (int i = 0; i < sortedIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        continueOrdering = true;
                    }
                }

                sortedIndex = sortedIndex - 1;
            } while (continueOrdering);

            return array;
        }

        private static int[] bubbleSort2(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    var a = array[j];
                    var b = array[j + 1];

                    if (a > b)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }

            return array;
        }

        private static void Swap(int[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}