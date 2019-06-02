namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            int[] array2 = {1, 3, 4, 5, 6, 7, 2};

            BubbleSort(array);
            BubbleSortSimple(array2);
        }

        #region bubbleSort
        private static int[] BubbleSort(int[] array)
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
        #endregion

        #region bubbleSortSimple
        private static int[] BubbleSortSimple(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    var a = array[j];
                    var b = array[j + 1];

                    if (a > b)
                    {
                        array[j] = b;
                        array[j + 1] = a;
                    }
                }
            }

            return array;
        }
        #endregion

        #region swapHelper
        private static void Swap(int[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
        #endregion
    }
}