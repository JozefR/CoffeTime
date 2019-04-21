using System;

namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedArray = new int[] {1, 2, 3, 4, 5, 6, 10, 200};
            var binary = binarySearch(sortedArray, 10);
        }

        private static int binarySearch(int[] sortedArray, int target)
        {
            if (sortedArray.Length == 0)
                return -1;

            int left = 0;
            int right = sortedArray.Length - 1;

            if (sortedArray[left] > target || sortedArray[right] < target)
                return -1;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (sortedArray[mid] == target)
                {
                    return target;
                }

                if (sortedArray[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}