namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 2, 10, 6, 7};
            int[] array2 = {1, 3, 4, 5, 6, 7, 2};
            int[] sortedArray = bubbleSort(array);
            int[] sortedArray2 = bubbleSort(array2);
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

        private static void Swap(int[] array, int firstIndex, int indexOfMinimum)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[indexOfMinimum];
            array[indexOfMinimum] = temp;
        }
    }
}