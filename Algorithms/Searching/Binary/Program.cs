namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
            int[] primes2 = {2, 3, 5, 7, 11, 97};

            var target = 53;
            var nonExistingTarget = 98;

            var sln = BinarySearch(primes, target);
            var sln2 = BinarySearchRecursion(primes, 3, 0, primes.Length);
        }

        #region binarySearch
        private static int BinarySearch(int[] array, int target)
        {
            int min = 0;
            int max = array.Length - 1;

            while (max > min)
            {
                var guess = (min + max) / 2;

                if (array[guess] == target)
                {
                    return guess;
                }

                if (array[guess] < target)
                {
                    min = guess + 1;
                }
                else
                {
                    max = guess - 1;
                }
            }

            return -1;
        }
        #endregion

        #region binarySearchRecursion
        private static int BinarySearchRecursion(int[] array, int target, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return -1;

            int middle = (leftIndex + rightIndex) / 2;

            if (array[middle] == target)
                return target;

            if (target > array[middle])
                return BinarySearchRecursion(array, target, middle + 1, rightIndex);

            if (target < array[middle])
                return BinarySearchRecursion(array, target, leftIndex, middle - 1);

            return middle;
        }
        #endregion
    }
}