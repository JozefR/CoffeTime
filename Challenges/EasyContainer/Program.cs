using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace EasyContainer
{
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
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumBruteForce(new []{ 2, 7, 11, 15 }, 9));
                Assert.AreEqual(new int[] { 1, 2 }, TwoSumBruteForce(new []{ 3, 2, 4 }, 6));
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumBruteForce(new []{ 3 ,3 }, 6));
                
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumDictionary(new []{ 2, 7, 11, 15 }, 9));
                Assert.AreEqual(new int[] { 1, 2 }, TwoSumDictionary(new []{ 3, 2, 4 }, 6));
                Assert.AreEqual(new int[] { 0, 1 }, TwoSumDictionary(new []{ 3 ,3 }, 6));
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
                        Assert.AreEqual(9, RomanToInt("IX"));
                Assert.AreEqual(40, RomanToInt("XL"));
                Assert.AreEqual(90, RomanToInt("XC"));
                Assert.AreEqual(400, RomanToInt("CD"));
                Assert.AreEqual(900, RomanToInt("CM"));
         */
        public static int RomanToInt(string s)
        {
            var romans = new Dictionary<string, int>
            {
                { "I", 1},
                { "V", 5},
                { "X", 10},
                { "L", 50},
                { "C", 100},
                { "D", 500},
                { "M", 1000},
                { "IV", 4},
                { "IX", 9},
                { "XL", 40},
                { "XC", 90},
                { "CD", 400},
                { "CM", 900},
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

        [TestFixture]
        public static class RomanToIntegerTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(4, RomanToInt("IV"));
                Assert.AreEqual(9, RomanToInt("IX"));
                Assert.AreEqual(40, RomanToInt("XL"));
                Assert.AreEqual(90, RomanToInt("XC"));
                Assert.AreEqual(400, RomanToInt("CD"));
                Assert.AreEqual(900, RomanToInt("CM"));
                Assert.AreEqual(58, RomanToInt("LVIII"));
                Assert.AreEqual(1476, RomanToInt("MCDLXXVI"));
                Assert.AreEqual(1994, RomanToInt("MCMXCIV"));
            }
        }
    }
}
