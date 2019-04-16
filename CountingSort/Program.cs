using System;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 4, 1, 2, 7, 100000, 2};
            var test = countingSort2(array);
        }

        private static int[] countingSort(int[] array)
        {
            var max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }

            var countedArray = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                var numberIndex = array[i];
                countedArray[numberIndex] += 1;
            }

            for (int i = 0; i < countedArray.Length - 1; i++)
            {
                countedArray[i + 1] = countedArray[i] + countedArray[i + 1];
            }

            var sortedArray = new int[array.Length];

            for (int i = 0; i < sortedArray.Length; i++)
            {
                var numberIndex = array[i];
                var number = countedArray[numberIndex];
                countedArray[numberIndex] -= 1;
                sortedArray[number - 1] = array[i];
            }

            return sortedArray;
        }

        private static int[] countingSort2(int[] array)
        {
            var max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }

            var countArray = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                countArray[array[i]] += 1;
            }

            var sumCountArray = new int[max + 1];

            for (int i = 0; i < sumCountArray.Length; i++)
            {
                if (i == 0)
                {
                    sumCountArray[i] = countArray[i];
                    continue;
                }

                sumCountArray[i] += sumCountArray[i - 1] + countArray[i];
                Console.WriteLine(i);
            }

            var sortedArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                var temp = sumCountArray[array[i]];
                sortedArray[temp - 1] = array[i];
                sumCountArray[array[i]] -= 1;
            }

            return sortedArray;
        }
    }
}