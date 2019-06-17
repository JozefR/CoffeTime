using System.Collections.Generic;
using System.Linq;

namespace Easy.MaxMinArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new List<int> {15, 11, 10, 7, 12};
            var sln = Solve(array);
        }

        private static List<int> Solve(List<int> arr)
        {
            var result = new List<int>();

            while (arr.Count > 1)
            {
                var max = arr.Max();
                var min = arr.Min();
                
                result.Add(max);
                result.Add(min);
                
                arr.Remove(max);
                arr.Remove(min);

                if (arr.Count == 1)
                {
                    result.Add(arr[0]);
                }
            }

            return result;
        }
    }
}