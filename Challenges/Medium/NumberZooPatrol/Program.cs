using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NumberZooPatrol
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int FindNumber(int[] shuffledArray)
        {
            var missingNumber = 1;
            var orderedArray = shuffledArray.OrderBy(x => x).ToArray();
            for (int i = 0; i < orderedArray.Count(); i++)
            {
                if (missingNumber != orderedArray[i]) break;
                
                missingNumber++;
            }
            
            return missingNumber;
        }

        public static int FindNumber1(int[] array)
        {
            // We use a HashSet here because since a HashSet is composed of unique items and our inputs only has unique items
            // This allows use to use `HashSet.Contains`, which is a constant O(1) operation, opposed to `Array.IndexOf`, which is a linear O(n) operation.
            // Alternatively, we could have sorted our input array using `Array.Sort` or `IEnumerable.OrderBy` and iterated over that, but that's a O(n + n log(n)) solution. That's OK, but we can do better!
            // With HashSet.Contains, our solution is done in O(n) time (~1 * n), as opposed to O(n ^ 2) for Array.IndexOf (n * n).
    
            // Relevant links:
    
            // Big O notation cheat sheet:
            // http://bigocheatsheet.com/
    
            // HashSet.Contains:
            // https://msdn.microsoft.com/en-us/library/bb356440(v=vs.110).aspx
    
            // Array.IndexOf:
            // https://msdn.microsoft.com/en-us/library/7eddebat(v=vs.110).aspx
    
            // O(n) -- Best
    
            HashSet<int> animals = new HashSet<int>(array);
  
            // Iterate over 1 to n + 1, and return the missing number
            foreach (int i in Enumerable.Range(1, array.Length + 1))
            {
                if (!animals.Contains(i)) { return i; }
            }
    
            return -1;
    
    
            // O(n + n log(n)) -- Worse
            /*
            //Array.Sort(array) // mutates your input, don't do this!
            int[] newArray = array.OrderBy(x => x).ToArray();
            
            for (int i = 0; i < newArray.Length; ++i)
            {
              if (newArray[i] != i + 1) { return i + 1; }
            }
            
            return newArray.Length + 1;
            */
    
            // O(n ^ 2) -- Step it up, JavaScript!
            /*
            for (int i = 1; i <= array.Length + 1; ++i)
            {
              if (Array.IndexOf(array, i) < 0) { return i; }
            }
            
            return -1;
            */
        }
    }
    
    [TestFixture]
    internal class Sample_Test
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData(new[] {new int[] {1, 3, 4, 5, 6, 7, 8}}).Returns(2);
                yield return new TestCaseData(new[] {new int[] {7, 8, 1, 2, 4, 5, 6}}).Returns(3);
                yield return new TestCaseData(new[] {new int[] {1, 2, 3, 5}}).Returns(4);
                yield return new TestCaseData(new[] {new int[] {1, 2}}).Returns(3);
                yield return new TestCaseData(new[] {new int[] {2, 3, 4}}).Returns(1);
                yield return new TestCaseData(new[] {new int[] {13, 11, 10, 3, 2, 1, 4, 5, 6, 9, 7, 8}}).Returns(12);
            }
        }
  
        [Test, TestCaseSource("testCases")]
        public int Test(int[] array) => Program.FindNumber(array);
    }
}