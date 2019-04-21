using System;

namespace InterpolationSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedArray = new int[] {0, 1, 2, 3, 4, 5, 8, 9, 10};
            var inter = interpolation(sortedArray, 8);
        }

        private static int interpolation(int[] sortedArray, int target)
        {
            if (sortedArray.Length == 0)
                return -1;

            int left = 0;
            int right = sortedArray.Length - 1;

            if (sortedArray[left] > target || sortedArray[right] < target)
                return -1;

            int candidat = 0;
            while (left <= right)
            {
                if (left == right)
                    candidat = left;
                else
                    candidat = left + (right - left) * (target - sortedArray[left]) /
                               (sortedArray[right] - sortedArray[left]);

                if (candidat < left)
                    return -1;
                if (candidat > right)
                    return -1;

                if (target == sortedArray[candidat])
                    return target;

                if (target < sortedArray[candidat])
                    right = candidat - 1;
                else
                    left = candidat + 1;
            }

            return -1;
        }
    }
}