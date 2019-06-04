namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {38, 27, 43, 3, 9, 82, 10};
            mergeSort(array, 0, array.Length - 1);
        }

        #region mergeSortMain
        private static void mergeSort(int[] array, int p, int r)
        {
            // Set base case for recursion
            if (p < r)
            {
                // find mid of the array because we need
                // divide the array each time recursion is called.
                var mid = (p + r) / 2;

                // Divide arrays
                // first sub problem
                mergeSort(array, p, mid);
                // second sub problem
                mergeSort(array, mid + 1, r);
                // Solution to subproblems merge
                merge(array, p, mid, r);
            }
        }
        #endregion

        #region merge
        private static void merge(int[] array, int p, int mid, int r)
        {
            var leftArrLength = mid - p + 1;
            var rightArrLength = r - mid;

            var leftArr = new int [leftArrLength];
            var rightArr = new int [rightArrLength];

            for (int x = 0; x < leftArrLength; x++)
            {
                leftArr[x] = array[p + x];
            }

            for (int y = 0; y < rightArrLength; y++)
            {
                rightArr[y] = array[y + 1 + mid];
            }

            int i = 0;
            int j = 0;
            int k = p;

            while (leftArrLength > i && rightArrLength > j)
            {
                if (leftArr[i] < rightArr[j])
                {
                    array[k] = leftArr[i];
                    i++;
                }
                else
                {
                    array[k] = rightArr[j];
                    j++;
                }

                k++;
            }

            while (leftArrLength > i)
            {
                array[k] = leftArr[i];
                k++;
                i++;
            }

            while (rightArrLength > j)
            {
                array[k] = rightArr[j];
                k++;
                j++;
            }
        }
        #endregion
    }
}