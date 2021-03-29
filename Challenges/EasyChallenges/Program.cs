using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace EasyChallenges
{
    class ValidateSubsequence
    {
        // https://www.algoexpert.io/questions/Validate%20Subsequence
        static void Main(string[] args)
        {
            IsValidSubsequence(new List<int> {5, 1, 22, 25, 6, -1, 8, 10}, new List<int> {1, 6, -1, 10});
        }

        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int subSequence = 0;
            bool isValid = false;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == sequence[subSequence])
                {
                    subSequence++;
                }

                if (subSequence == sequence.Count)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        public static bool IsValidSubsequence2(List<int> array, List<int> sequence)
        {
            int arrIdx = 0;
            int seqIdx = 0;
            while (arrIdx < array.Count && seqIdx < sequence.Count)
            {
                if (array[arrIdx] == sequence[seqIdx])
                {
                    seqIdx++;
                }

                arrIdx++;
            }

            return seqIdx == sequence.Count;
        }

        [TestFixture]
        public class CountLettersAndDigitsTests
        {
            [Test]
            public void TestCases()
            {
                Assert.AreEqual(true, ValidateSubsequence.IsValidSubsequence(
                    new List<int> {5, 1, 22, 25, 6, -1, 8, 10},
                    new List<int> {1, 6, -1, 10}));

                Assert.AreEqual(false, ValidateSubsequence.IsValidSubsequence(
                    new List<int> {5, 1, 22, 25, 6, -1, 8, 10},
                    new List<int> {1, 6, -1, -1}));
            }
        }
    }
}