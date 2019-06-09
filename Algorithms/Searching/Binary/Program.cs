namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
            var target = 53;

            BinarySearch(primes, target);
            BinarySearchRecursion(primes, 3, 0, primes.Length);
        }

        #region binarySearch
        private static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (right > left)
            {
                var guess = (left + right) / 2;

                if (array[guess] == target)
                {
                    return guess;
                }

                if (array[guess] < target)
                {
                    left = guess + 1;
                }
                else
                {
                    right = guess - 1;
                }
            }

            return -1;
        }
        #endregion

        #region binarySearchRecursion
        private static int BinarySearchRecursion(int[] array, int target, int left, int rightIndex)
        {
            if (left > rightIndex)
                return -1;

            int middle = (left + rightIndex) / 2;

            if (array[middle] == target)
                return target;

            if (target > array[middle])
                return BinarySearchRecursion(array, target, middle + 1, rightIndex);

            if (target < array[middle])
                return BinarySearchRecursion(array, target, left, middle - 1);

            return middle;
        }
        #endregion
    }
}