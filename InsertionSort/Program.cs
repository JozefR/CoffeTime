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
            // var sorted = insertionSortRepeat(array2);
        }

        private static int[] insertionSortRepeat(int[] array)
        {
            // like sorted cards in hand.
            // i need put every new card from dealer in correct place.

            for (int i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var leftIndex = i - 1;

                while (leftIndex >= 0 && key < array[leftIndex])
                {
                    var temp = array[leftIndex];
                    array[leftIndex] = key;
                    array[i] = temp;

                    leftIndex -= 1;
                }
            }

            return array;
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
                    leftIndex -= 1;
                }

                array[leftIndex + 1] = key;
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