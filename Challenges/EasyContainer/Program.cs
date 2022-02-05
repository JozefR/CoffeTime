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
        // https://leetcode.com/problems/merge-two-sorted-lists/
        
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

            var head = merged;

            while (l1 != null || l2 != null)
            {
                if (l1 != null && l2 != null)
                {
                    if (l1.val <= l2.val)
                    {
                        merged.val = l1.val;
                        l1 = l1.next;
                        merged.next = new ListNode();
                        merged = merged.next;
                        continue;
                    }
                    else
                    {
                        merged.val = l2.val;
                        l2 = l2.next;
                        merged.next = new ListNode();
                        merged = merged.next;
                        continue;
                    }
                }

                if (l1 != null)
                {
                    merged.val = l1.val;
                    l1 = l1.next;

                    if (l1 != null)
                    {
                        merged.next = new ListNode();
                        merged = merged.next;
                    }
                    continue;
                }
                
                if (l2 != null)
                {
                    merged.val = l2.val;
                    l2 = l2.next;
                    if (l2 != null)
                    {
                        merged.next = new ListNode();
                        merged = merged.next;
                    }
                    continue;
                }
            }
            
            return head;
        }

        private void SetCurrent(ListNode current, ListNode merged)
        {
            merged.val = current.val;
            current = current.next;
            if (current != null)
            {
                merged.next = new ListNode();
                merged = merged.next;
            }
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

    class CountLetterForGivenNStrings
    {
        /*
         * Given string aacbea, count how many letters "a" appear in this string.
         * Consider parameter n which is the length of the string for which we need count letter "a"
         * if the string is not big enought we need to extend it to the parameter n
         * if the string is greater then n we need to cut it to the parameter n
         */

        static void Main()
        {
            
        }

        static int CountLetter(string inputString, int lengthOfTheString)
        {
            if (lengthOfTheString == 0)
            {
                return 0;
            }
            
            if (lengthOfTheString == 1)
            {
                if (inputString.Length >= 1 && inputString[0] == 'a')
                {
                    return 1;
                }
            }
            
            while (inputString.Length < lengthOfTheString)
            {
                inputString += inputString;
            }

            inputString = inputString.Substring(0, lengthOfTheString);
            
            var result = 0;
            
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == 'a')
                {
                    result++;
                }
            }

            return result;
        }

        static int CountLetter1(string inputString, int givenLength)
        {
            if (givenLength == 0)
            {
                return 0;
            }
            
            if (givenLength == 1)
            {
                if (inputString.Length >= 1 && inputString[0] == 'a')
                {
                    return 1;
                }
            }

            var result = 0;
            if (inputString.Length > givenLength)
            {
                for (int i = 0; i < givenLength; i++)
                {
                    if (inputString[i] == 'a')
                    {
                        result++;
                    }
                }

                return result;
            }
            
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == 'a')
                {
                    result++;
                }
            }

            var multiply = givenLength / inputString.Length;

            if (multiply != 0)
            {
                result = result * multiply;
            }

            var remind = givenLength % inputString.Length;

            if (remind > 0)
            {
                for (int i = 0; i < inputString.Length - remind; i++)
                {
                    if (inputString[i] == 'a')
                    {
                        result++;
                    }
                }
            }
            
            return result;
        }

        static int CountLetter2(string input, int n)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 0;
            }
            
            if (input.Length > n)
            {
                return CountLetterA(input, n);
            }

            var result = CountLetterA(input, input.Length);

            var multiplier = n / input.Length;
            result = result * multiplier;

            var reminder = n % input.Length;
            result += CountLetterA(input, reminder);

            return result;
        }

        private static int CountLetterA(string input, int countToIndex)
        {
            var result = 0;
            for (var i = 0; i < countToIndex; i++)
            {
                if (input[i] == 'a')
                {
                    result++;
                }
            }

            return result;
        }

        [TestFixture]
        public static class CountLetterForGivenNStringsTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(3, CountLetter2("aacbea", 6));
                Assert.AreEqual(2, CountLetter2("aacbea", 5));
                Assert.AreEqual(5, CountLetter2("aacbea", 9));
                Assert.AreEqual(5, CountLetter2("aacbea", 10));
                Assert.AreEqual(6, CountLetter2("aacbea", 12));
            }
        }
    }

    class RemoveDuplicatesSolution
    {        
        //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        
        static void Main()
        {
            RemoveDuplicates(new[] { 1, 2 });
        }
        
        public static int RemoveDuplicates(int[] nums)
        {
            var k = 0;

            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return 1;
            }

            k += 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var previousIndex = k - 1;
                if (nums[previousIndex] != nums[i])
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            
            return k;
        }
    }
    
    class RemoveElementSolution
    {        
        // https://leetcode.com/problems/remove-element/
        
        static void Main()
        {
            RemoveElement(new[] { 0,1,2,2,3,0,4,2 }, 2);
        }
        
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int removedLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == -1)
                {
                    break;
                }
                
                if (nums[i] == val)
                {
                    removedLength += 1;
                    nums[i] = nums[nums.Length - removedLength];
                    nums[nums.Length - removedLength] = -1;
                    i -= 1;
                }
            }

            return removedLength;
        }
    }    
    
    class ValidParenthesesSolution
    {        
        // https://leetcode.com/problems/valid-parentheses/

        static void Main()
        {
            IsValid("(()()[][]{[()]}");
        }
        
        private static bool IsValid(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            int index = 0;
            while (s.Length > 0)
            {
                if (index >= s.Length - 1)
                {
                    return false;
                }

                int nextIndex = index + 1;
                if (s[index] == '(' && s[nextIndex] == ')')
                {
                    s = s.Remove(index, 2);
                    index = 0;
                    continue;
                }
                if (s[index] == '[' && s[nextIndex] == ']')
                {
                    s = s.Remove(index, 2);
                    index = 0;
                    continue;
                }
                if (s[index] == '{' && s[nextIndex] == '}')
                {
                    s = s.Remove(index, 2);
                    index = 0;
                    continue;
                }

                index++;
            }

            return true;
        } 
        
        private static bool IsValid2(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(s[i]);
                        break; 
                    case ')' :
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            return false;
                        };
                        break;
                    case '}' :
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            return false;
                        };
                        break;
                    case ']' :
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            return false;
                        };
                        break;
                    default:
                        return false;
                }
            }

            return stack.Count == 0;
        }
    }
    
    class SearchInsertPositionSolution
    {        
        // https://leetcode.com/problems/search-insert-position/

        static void Main()
        {
            SearchInsert(new int[] {1, 3}, 2);
            SearchInsert(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 10);
        }
        
        public static int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;

            while (right > left)
            {
                var half = (left + right) / 2;
                var guess = nums[half];

                if (guess == target)
                {
                    return half;
                }

                if (guess > target)
                {
                    right = half - 1;
                }
                else
                {
                    left = half + 1;
                }
            }

            if (nums[left] == target)
            {
                return left;
            }

            return left == right ? left + 1 : right;
        }
    }
    
    class FirstBadVersionSolution
    {        
        // https://leetcode.com/problems/first-bad-version/

        static void Main()
        {
            FirstBadVersion(5); // 3 is bad
        }
        
        public static int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        public static bool IsBadVersion(int version)
        {
            // implemented in leetCode;
            return version == 3;
        }
    }
    
    class StrStrSolution
    {        
        // https://leetcode.com/problems/implement-strstr/
        static void Main()
        {
        }
        
        public static int StrStr(string haystack, string needle)
        {
            var index = haystack.IndexOf(needle);
            return index;
        }        
        
        public static int StrStr1(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(haystack))
            {
                return -1;
            }

            for (var i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    var x = i + 1;
                    bool found = true;
                    for (var j = 1; j < needle.Length; j++)
                    {
                        if (x >= haystack.Length)
                        {
                            return -1;
                        }
                        
                        if (haystack[x] != needle[j])
                        {
                            found = false;
                            break;
                        }

                        x++;
                    }

                    if (found)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
        
        [TestFixture]
        public static class StrStrSolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(4, StrStr1("mississippi", "issip"));
                Assert.AreEqual(2, StrStr1("hello", "ll"));
                Assert.AreEqual(-1, StrStr1("aaaaa", "baa"));
                Assert.AreEqual(0, StrStr1("", ""));
            }
        }
    }
}