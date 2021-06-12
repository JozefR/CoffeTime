namespace HeapSort
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] array = {5, 10, 1, 3, 6, 8, 2, 4, 7, 9};
            int[] array1 = {5, 10, 1, 3, 6, 8, 2, 4, 7, 9};
            HeapSort(array1);
        }

        private static int[] CreateUpperHeap(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                UpperHeaping(array, i);
            }
            
            return array;
        }

        private static void UpperHeaping(int[] array, int i)
        {
            var childIndex = i;
            var childValue = array[i];
            
            while (childIndex > 0)
            {
                var fatherIndex = (childIndex - 1) / 2;
                var fatherValue = array[fatherIndex];
                
                if (childValue > fatherValue)
                {
                    array[childIndex] = fatherValue;
                    array[fatherIndex] = childValue;
                    childIndex = fatherIndex;
                }
                else
                {
                    return;
                }
            }
        }

        private static int[] HeapSort(int[] array)
        {
            // First create heap from input array
            Heaping(array);

            // Start from the last index
            var lastIndex = array.Length - 1;

            // Take maximum which is always at index 0 after
            // heaping and swap it with last value. This last value
            // become lower each cycle until is equal 0 and
            // array is sorted !
            while (lastIndex > 0)
            {
                // At index 0 is always maximum !
                Swap(array,0, lastIndex);
                // Last value becomes lower each time !
                lastIndex -= 1;
                // When we swap last value with maximum we
                // need repair structure because last value
                // can interrupt heap !
                // It is basically as Upper method but we are
                // going from up to down.
                Down(array, lastIndex);
            }

            return array;
        }

        // Create heap data structure.
        private static void Heaping(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Upper(array, i);
            }
        }

        // The idea is check for each number if father is greater,
        // if not move that number up and continue until father has lower value.
        private static void Upper(int[] array, int i)
        {
            int childIndex = i;
            while (childIndex > 0)
            {
                // father for particular child index
                int fatherIndex = (childIndex - 1) / 2;

                int child = array[childIndex];
                int father = array[fatherIndex];

                if (father < child)
                {
                    // Father is lower then child, swap it.
                    Swap(array, fatherIndex, childIndex);
                    // After swapping, childIndex become fatherIndex.
                    childIndex = fatherIndex;
                }
                else
                {
                    // nothing happend father and child are in correct places.
                    return;
                }
            }
        }

        private static void Down(int[] array, int lastIndex)
        {
            // After swap last index become father and this can interrupt heap
            // we need repair it.
            int fatherIndex = 0;

            while (fatherIndex * 2 + 1 < lastIndex)
            {
                // find childs
                int childIndex = 2 * fatherIndex + 1;

                // Find which child is greater
                if (childIndex < lastIndex && array[childIndex] < array[childIndex + 1])
                {
                    childIndex += 1;
                }

                // swap if father has lower value.
                if (array[fatherIndex] < array[childIndex])
                {
                    Swap(array, fatherIndex, childIndex);
                    fatherIndex = childIndex;
                }
                else
                {
                    return;
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}