using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace EasyContainer
{
    class CountLettersAndDigitsSolution
    {
        /*
         * Bob is a lazy man.
         * He needs you to create a method that can determine how many letters and digits are in a given string.
         * Example:
         * "hel2!lo" --> 6
         * "wicked .. !" --> 6
         * "!?..A" --> 1
         */
        public static int CountLettersAndDigits(string input)
        {
            int cnt = 0;

            for (int i = 0; i < input?.Length; i++)
            {
                var character = input[i];
                if (char.IsDigit(character))
                {
                    cnt += 1;
                }

                if (char.IsLetter(character))
                {
                    cnt += 1;
                }
            }

            return cnt;
        }

        public static int CountLettersAndDigits2(string input) => input.Count(char.IsLetterOrDigit);

        public static int CountLettersAndDigits3(string input)
        {
            var allowedCharacters = string.Concat(Enumerable.Range(0, 26)
                .Select(i => (i < 10 ? i.ToString() : "") + (char)(i + 65) + (char)(i + 97)));

            return input.Count(c => allowedCharacters.Contains(c));
        }

        public static int CountLettersAndDigits4(string input)
        {
            string pt = @"(\w)";
            Regex rg = new Regex(pt);
            MatchCollection mt = rg.Matches(input);
            return mt.Count;
        }

        public static int CountLettersAndDigits5(string input)
        {
            return input.Length - new Regex(@"\d|[a-zA-Z]").Replace(input, "").Length;
        }

        [TestFixture]
        public class CountLettersAndDigitsTests
        {
            [Test]
            public void TestCases()
            {
                Assert.AreEqual(0, CountLettersAndDigits(null));
                Assert.AreEqual(3, CountLettersAndDigits("Aba"));
                Assert.AreEqual(6, CountLettersAndDigits("hel2!lo"));
                Assert.AreEqual(6, CountLettersAndDigits("wicked .. !"));
                Assert.AreEqual(1, CountLettersAndDigits("!?..A"));
            }
        }
    }

    class ValidateSubsequence
    {
        // https://www.algoexpert.io/questions/Validate%20Subsequence
        static void Main(string[] args)
        {
            IsValidSubsequence(new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 }, new List<int> { 1, 6, -1, 10 });
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
                    new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 },
                    new List<int> { 1, 6, -1, 10 }));

                Assert.AreEqual(false, ValidateSubsequence.IsValidSubsequence(
                    new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 },
                    new List<int> { 1, 6, -1, -1 }));
            }
        }
    }

    class TwoSum
    {
        /*
        https://leetcode.com/problems/two-sum/
        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        You can return the answer in any order.
    
        Example 1:
    
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Output: Because nums[0] + nums[1] == 9, we return [0, 1].
        Example 2:
    
        Input: nums = [3,2,4], target = 6
        Output: [1,2]
        Example 3:
    
        Input: nums = [3,3], target = 6
        Output: [0,1]
    
        Constraints:
    
        2 <= nums.length <= 10 ^ 4
        -10 ^ 9 <= nums[i] <= 10 ^ 9
        -10 ^ 9 <= target <= 10 ^ 9
        Only one valid answer exists.
    
        Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
        
        Complexity Analysis
        Time complexity: O(n^2). For each element, we try to find its complement by looping through the rest of the array which takes O(n) time. Therefore, the time complexity is O(n^2).
        Space complexity: O(1). The space required does not depend on the size of the input array, so only constant space is used.
         */

        public static int[] TwoSumBruteForce(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return null;
        }

        /*
        Approach 3: One-pass Hash Table
    
        It turns out we can do it in one-pass. While we are iterating and inserting elements into the hash table, 
        we also look back to check if current element's complement already exists in the hash table. 
        If it exists, we have found a solution and return the indices immediately.
    
        Complexity Analysis
    
        Time complexity: O(n). We traverse the list containing n elements only once. Each lookup in the table costs only O(1) time.
        Space complexity: O(n). The extra space required depends on the number of items stored in the hash table, which stores at most n elements.
         */

        public static int[] TwoSumDictionary(int[] array, int target)
        {
            var dictionary = new Dictionary<int, int>();

            for (var i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey(target - array[i]))
                {
                    return new[] { dictionary[target - array[i]], i };
                }

                if (!dictionary.ContainsKey(array[i]))
                {
                    dictionary.Add(array[i], i);
                }
            }

            return null;
        }

        [TestFixture]
        public static class TwoSumTests
        {
            [Test]
            public static void AreTwoSums()
            {
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumBruteForce(new[] { 2, 7, 11, 15 }, 9));
                Assert.AreEqual(new int[] { 1, 2 }, TwoSumBruteForce(new[] { 3, 2, 4 }, 6));
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumBruteForce(new[] { 3, 3 }, 6));

                Assert.AreEqual(new int[] { 0, 1 }, TwoSumDictionary(new[] { 2, 7, 11, 15 }, 9));
                Assert.AreEqual(new int[] { 1, 2 }, TwoSumDictionary(new[] { 3, 2, 4 }, 6));
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumDictionary(new[] { 3, 3 }, 6));
            }
        }
    }

    class PalindromNumber
    {
        /*
        Given an integer x, return true if x is palindrome integer.
    
        An integer is a palindrome when it reads the same backward as forward. For example, 121 is palindrome while 123 is not.
    
        Example 1:
    
        Input: x = 121
        Output: true
        Example 2:
    
        Input: x = -121
        Output: false
        Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
        Example 3:
    
        Input: x = 10
        Output: false
        Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
        Example 4:
    
        Input: x = -101
        Output: false
    
    
        Constraints:
        -231 <= x <= 231 - 1
    
        Follow up: Could you solve it without converting the integer to a string?
         */

        public static bool IsPalindrom(int x)
        {
            var a = x.ToString();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != a[a.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        [TestFixture]
        public static class PalindromTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(true, IsPalindrom(121));
                Assert.AreEqual(false, IsPalindrom(123));
            }
        }
    }

    class RomanToInteger
    {
        /*
        https://leetcode.com/problems/roman-to-integer/
        Symbol       Value
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000
         */
        public static int RomanToInt2(string s)
        {
            var romans = new Dictionary<string, int>
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 },
                { "IV", 4 },
                { "IX", 9 },
                { "XL", 40 },
                { "XC", 90 },
                { "CD", 400 },
                { "CM", 900 },
            };

            var result = 0;
            for (int i = 0; i < s.ToString().Length; i++)
            {
                var firstChars = s[i].ToString();
                var secondChars = "";
                var thirdChars = "";

                if (i + 1 < s.ToString().Length)
                {
                    secondChars = s.Substring(i, 2);
                }

                if (i + 2 < s.ToString().Length)
                {
                    thirdChars = s.Substring(i, 3);
                }

                if (romans.ContainsKey(thirdChars))
                {
                    result += romans[thirdChars];
                    result += romans[firstChars];
                    i += 2;
                }
                else if (romans.ContainsKey(secondChars))
                {
                    result += romans[secondChars];
                    i += 1;
                }
                else
                {
                    result += romans[firstChars];
                }
            }

            return result;
        }

        public static int RomanToInt(string s)
        {
            var romans = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

            var result = 0;
            var stringLength = s.Length;
            for (int i = 0; i < stringLength; i++)
            {
                var value = romans[s[i]];
                var valueNext = i + 1 < stringLength ? romans[s[i + 1]] : 0;

                if (value >= valueNext)
                {
                    result += value;
                }
                else
                {
                    result -= value;
                }
            }

            return result;
        }

        [TestFixture]
        public static class RomanToIntegerTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(58, RomanToInt("LVIII"));
                Assert.AreEqual(4, RomanToInt("IV"));
                Assert.AreEqual(9, RomanToInt("IX"));
                Assert.AreEqual(40, RomanToInt("XL"));
                Assert.AreEqual(90, RomanToInt("XC"));
                Assert.AreEqual(400, RomanToInt("CD"));
                Assert.AreEqual(900, RomanToInt("CM"));
                Assert.AreEqual(1476, RomanToInt("MCDLXXVI"));
                Assert.AreEqual(1994, RomanToInt("MCMXCIV"));
            }
        }
    }

    class LongestCommonPrefixSolution
    {
        /*
        https://leetcode.com/problems/longest-common-prefix/
         */

        public static string LongestCommonPrefix(string[] strings)
        {
            if (strings.Length == 0)
            {
                return string.Empty;
            }

            string commonPrefix = strings[0];
            bool noCommonPrefix = false;

            for (int i = 1; i < strings.Length; i++)
            {
                var word = strings[i];

                for (int j = 0; j < commonPrefix.Length; j++)
                {
                    if (word.Length - 1 < j)
                    {
                        var startIndex = j;
                        var numberOfRestChars = commonPrefix.Length - j;
                        commonPrefix = commonPrefix.Remove(startIndex, numberOfRestChars);
                        break;
                    }

                    var prefixDoesntEqual = commonPrefix[j] != word[j];

                    if (prefixDoesntEqual && j == 0)
                    {
                        noCommonPrefix = true;
                        break;
                    }

                    if (prefixDoesntEqual)
                    {
                        commonPrefix = commonPrefix.Remove(j, commonPrefix.Length - j);
                    }
                }

                if (noCommonPrefix == true)
                {
                    return string.Empty;
                }
            }

            return commonPrefix;
        }

        public static string LongestCommonPrefix1(string[] strings)
        {
            if (strings.Length == 0)
            {
                return string.Empty;
            }

            var commonPrefix = new StringBuilder(strings[0]);

            for (int i = 1; i < strings.Length; i++)
            {
                var minimumLength = commonPrefix.Length < strings[i].Length ? commonPrefix.Length : strings[i].Length;
                var wordPrefixToCheck = strings[i];

                if (minimumLength < commonPrefix.Length)
                {
                    commonPrefix.Remove(minimumLength, commonPrefix.Length - minimumLength);
                }

                for (int j = 0; j < minimumLength; j++)
                {
                    if (commonPrefix[j] != wordPrefixToCheck[j])
                    {
                        commonPrefix.Remove(j, commonPrefix.Length - j);
                        break;
                    }
                }
            }

            return commonPrefix.ToString();
        }

        [TestFixture]
        public static class LongestCommonPrefixTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual("", LongestCommonPrefix1(new[] { "", "b" }));
                Assert.AreEqual("a", LongestCommonPrefix1(new[] { "ab", "a" }));
                Assert.AreEqual("C", LongestCommonPrefix1(new[] { "CIR", "CAR" }));
                Assert.AreEqual("fl", LongestCommonPrefix1(new[] { "flower", "flow", "flight" }));
                Assert.AreEqual("", LongestCommonPrefix1(new[] { "dog", "racecar", "car" }));
            }
        }
    }

    class MergeTwoSortedListSolution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private static ListNode MergeTwoSortedList(ListNode l1, ListNode l2)
        {
            var merged = l1 != null || l2 != null ? new ListNode() : null;

            var l1Next = l1;
            var l2Next = l2;
            var head = merged;

            while (l1Next != null || l2Next != null)
            {
                if (l1Next != null && l2Next != null)
                {
                    if (l1Next.val <= l2Next.val)
                    {
                        merged.val = l1Next.val;
                        l1Next = l1Next.next;
                        merged.next = new ListNode();
                        merged = merged.next;
                        continue;
                    }
                    else
                    {
                        merged.val = l2Next.val;
                        l2Next = l2Next.next;
                        merged.next = new ListNode();
                        merged = merged.next;
                        continue;
                    }
                }

                if (l1Next != null)
                {
                    merged.val = l1Next.val;
                    l1Next = l1Next.next;

                    if (l1Next != null)
                    {
                        merged.next = new ListNode();
                        merged = merged.next;
                    }
                    continue;
                }
                
                if (l2Next != null)
                {
                    merged.val = l2Next.val;
                    l2Next = l2Next.next;
                    if (l2Next != null)
                    {
                        merged.next = new ListNode();
                        merged = merged.next;
                    }
                    continue;
                }
            }
            
            return head;
        }
        
        [TestFixture]
        public static class MergedTwoLinkedListTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4)))))), 
                    MergeTwoSortedList(new ListNode(1, new ListNode(2, new ListNode(4))), new ListNode(1, new ListNode(3, new ListNode(4)))));
            }
        }
    }
}