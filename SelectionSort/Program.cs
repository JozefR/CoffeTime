namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {1, 3, 5, 2, 10, 6, 7};
            //var sortedArray = selectionSort(array);
            var sortedArray = selectionSortRefactored(array);
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
            for (int firstIndex = 0; firstIndex < array.Length; firstIndex++)
            {
                int indexOfMinimum = IndexOfMinimum(array, firstIndex);                
                Swap(array, firstIndex, indexOfMinimum);
            }

            return array;
        }
        
        // This function will swap element in a given array.
        private static void Swap(int[] array, int firstIndex, int indexOfMinimum)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[indexOfMinimum];
            array[indexOfMinimum] = temp;
        }
        
        // This funcion will find index of minimum value
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