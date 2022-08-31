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
         * if the string is not big enough we need to extend it to the parameter n
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

    class IsPalindromSolution
    {
        public static bool IsPalindrom(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                char leftLetter = s[left];
                char rightLetter = s[right];
                
                if (!char.IsLetterOrDigit(leftLetter))
                {
                    left++;
                    continue;
                }

                if (!char.IsLetterOrDigit(rightLetter))
                {
                    right--;
                    continue;
                }

                if (!char.ToLower(leftLetter).Equals(char.ToLower(rightLetter)))
                {
                    break;
                }

                left++;
                right--;
            }

            if (left >= right)
            {
                return true;
            }

            return false;
        }
        
        [TestFixture]
        public static class IsPalindromTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(true, IsPalindrom("aa"));
                Assert.AreEqual(true, IsPalindrom("A man, a plan, a canal: Panama"));
                Assert.AreEqual(false, IsPalindrom("race a car"));
                Assert.AreEqual(true, IsPalindrom(" "));
            }
        }
    }

    class SingleNumberSolution
    {
        // https://leetcode.com/problems/single-number/
        public static int SingleNumber(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (nums[i] == nums[j])
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    return nums[i];
                }
            }

            return -1;
        }
        
        public static int SingleNumber1(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                bool found = false;

                if (nums[i] == -1)
                {
                    continue;
                }
                
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == -1) continue;
                    if (i == j) continue;

                    if (nums[i] == nums[j])
                    {
                        found = true;
                        nums[i] = -1;
                        nums[j] = -1;
                    }
                }

                if (found == false)
                {
                    return nums[i];
                }
            }

            return -1;
        }
        
        public static int SingleNumber2(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dictionary.ContainsKey(nums[i]))
                {
                    dictionary[nums[i]] = 1;
                }
                else
                {
                    dictionary[nums[i]] += 1;
                }
            }

            foreach (var single in dictionary)
            {
                if (single.Value == 1)
                {
                    return single.Key;
                }
            }

            return -1;
        }
        
        [TestFixture]
        class SingleNumberTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(4, SingleNumber2(new []{ 2, 3, 2, 3, 4}));
                Assert.AreEqual(1, SingleNumber2(new []{ 1 }));
                Assert.AreEqual(1, SingleNumber2(new []{ 1, 2, 3, 2, 3}));
            }
        }
    }
    
    class MaxSubArraySolution
    {
        // https://leetcode.com/problems/maximum-subarray/
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            var maxSubArray = nums[0];
            var tempMaxSubArray = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var currentNum = nums[i];
                
                tempMaxSubArray += currentNum;
                if (tempMaxSubArray < currentNum)
                {
                    tempMaxSubArray = currentNum;
                }
                
                if (tempMaxSubArray > maxSubArray)
                {
                    maxSubArray = tempMaxSubArray;
                }
            }

            return maxSubArray;
        }
        
        [TestFixture]
        class MaxSubArraySolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(-1, MaxSubArray(new []{-1, -2}));
                Assert.AreEqual(5, MaxSubArray(new []{1, -4, 2, 3}));
                Assert.AreEqual(23, MaxSubArray(new[]{5, 4, -1, 7, 8}));
                Assert.AreEqual(6, MaxSubArray(new []{-2, 1, -3, 4, -1, 2, 1, -5, 4}));
            }
        }

        class HistoryOfFourSolution
        {
            private static List<int> HistoryOfLastFour(List<int> latestHistoryList)
            {
                var orderedHistoryList = latestHistoryList.OrderByDescending(x => x).Take(4).ToList();
                var lastFourYears = Enumerable.Range(DateTime.Now.Year - 3, 4).Reverse().ToList();

                for (int i = 0; i < lastFourYears.Count; i++)
                {
                    if (CheckEmptyOrNotFourHistory(i, lastFourYears, orderedHistoryList))
                    {
                        AddMissingYear(i, lastFourYears, orderedHistoryList);
                    }
                }

                return orderedHistoryList.Take(4).ToList();
            }

            private static bool CheckEmptyOrNotFourHistory(int i, List<int> lastFourYears, List<int> latestHistoryList)
            {
                if (latestHistoryList.Count == 0 || i == latestHistoryList.Count)
                {
                    return true;
                }

                var year = latestHistoryList[i];

                if (year != lastFourYears[i])
                {
                    return true;
                }

                return false;
            }

            private static void AddMissingYear(int i, List<int> lastFourYears, List<int> latestHistoryList)
            {
                var missingYear = lastFourYears[i];
            
                latestHistoryList.Insert(i, missingYear);
            }
            
            [TestFixture]
            public class HistoryOfFourTests
            {
                private static readonly object[] _years = 
                {
                    new object[] {new List<int>()},   
                    new object[] {new List<int> {2020, 2019, 2018, 2017}},
                    new object[] {new List<int> {2017, 2018, 2019, 2020}},
                    new object[] {new List<int> {2020, 2019, 2018, 2017, 2016, 2015}},
                    new object[] {new List<int> {2015, 2016, 2017, 2018, 2019, 2020}},
                    new object[] {new List<int> {2016, 2015}},
                    new object[] {new List<int> {2020, 2018}},
                    new object[] {new List<int> {2017, 2016}},
                    new object[] {new List<int> {2020 }},   
                    new object[] {new List<int> {2019 }},   
                    new object[] {new List<int> {2018 }},   
                    new object[] {new List<int> {2017 }},   
                    new object[] {new List<int> {2016 }},   
                    new object[] {new List<int> {2015 }},   
                };
            
                [TestCaseSource(nameof(_years))]
                public void CheckYears(List<int> list)
                {
                    var expected = new List<int> { 2020, 2019, 2018, 2017 };
                
                    Assert.AreEqual(expected, HistoryOfLastFour(list));
                }
            }
        }

        // https://www.codewars.com/kata/persistent-bugger
        class PersistentBuggerSolution
        {
            public static int Persistence(long n)
            {
                if (n < 10)
                {
                    return 0;
                }
             
                var result = 0;
                var multiplicativePersistence = n.ToString();
                while (multiplicativePersistence.Length > 1)
                {
                    var tempPersistence = 1;
                    for (int i = 0; i < multiplicativePersistence.Length; i++)
                    {
                        tempPersistence *= int.Parse(multiplicativePersistence[i].ToString());
                    }

                    multiplicativePersistence = tempPersistence.ToString();
                    result++;
                }
                
                return result;
            }
            
            [TestFixture]
            class PersistentBuggerTests
            {
                [Test]
                public static void TestCases()
                {
                    Assert.AreEqual(0, Persistence(4));
                    Assert.AreEqual(3, Persistence(39));
                    Assert.AreEqual(2, Persistence(25));
                    Assert.AreEqual(4, Persistence(999));
                }
            }
        }

        class HopCrossSolution
        {
            /*
            You are trying to cross a river by jumping along stones.
            Every time you land on a stone, you hop forwards by the value
            of that stone. If you skip over a stone then its value doesn't
            affect you in any way. Eg:
                
                x--x-----x-->
                [1]
                [2]
                [5]
                [1]

            Of course, crossing from the other side might give you a different answer:

                ,--------x--x
                [1][2][5][1]
                
            Given an array of positive integers, return the total number of steps
            it would take to go all the way across the river(and past the end 
            of the array) and then all the way back.All arrays will contain at
            least one element, and may contain up to 100 elements.

            ### Examples

                x--x-----x-->
                [1][2][1][2]
                ----x-----x
                therefore hop_across([1, 2, 1, 2]) = 3 + 2 = 5
                x-----x--------x------>
                [2][2][3][1][1][2][1]
                --------x--x-----x--x
                therefore hop_across([2, 2, 3, 1, 1, 2, 1]) = 3 + 4 = 7 

             */
            public static int HopAcross(List<int> input)
            {
                return 0;
            }
            
            [TestFixture]
            public class HopTest
            {
                [Test]
                public void HopAcrossTest()
                {
                    Assert.That(HopAcross(new List<int> {1}), Is.EqualTo(2));
                    Assert.That(HopAcross(new List<int> {2}), Is.EqualTo(2));
                    Assert.That(HopAcross(new List<int> {1, 1}), Is.EqualTo(4));
                    Assert.That(HopAcross(new List<int> {2, 1}), Is.EqualTo(3));
                    Assert.That(HopAcross(new List<int> {2, 1, 1}), Is.EqualTo(5));
                    Assert.That(HopAcross(new List<int> {1, 2, 1, 2}), Is.EqualTo(5));
                    Assert.That(HopAcross(new List<int> {1, 2, 5, 1}), Is.EqualTo(5));
                    Assert.That(HopAcross(new List<int> {2, 2, 3, 1, 1, 2, 1}), Is.EqualTo(7));
                }
            }
        }
    }
    
    class AnagramSolution
    {
        // https://leetcode.com/problems/valid-anagram/
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            
            for (int i = 0; i < s.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < t.Length; j++)
                {
                    if (found)
                    {
                        continue;
                    }
                    
                    if (s[i] == t[j])
                    {
                        t = t.Remove(j, 1);
                        found = true;
                    }
                }

                if (found == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsAnagram2(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var sOrdered = new string(s.OrderBy(x => x).ToArray());
            var tOrdered = new string(t.OrderBy(x => x).ToArray());

            if (sOrdered == tOrdered)
            {
                return true;
            }

            return false;
        }
        
        public static bool IsAnagram3(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var tDic = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                var value = t[i];
                if (!tDic.ContainsKey(value))
                {
                    tDic[value] = 1;
                }
                else
                {
                    tDic[value] += 1;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                var value = s[i];
                if (!tDic.ContainsKey(value))
                {
                    return false;
                }

                tDic[value] -= 1;
                var tdicValue = tDic[value];
                if (tdicValue < 0)
                {
                    return false;
                }
            }

            return true;
        }
        
        [TestFixture]
        class MaxSubArraySolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.IsTrue(IsAnagram3("anagram", "nagaram"));
                Assert.IsFalse(IsAnagram3("rat", "car"));
            }
        }
    }

    class SameTreeSolution
    { 
        // https://leetcode.com/problems/same-tree/
        public class TreeNode 
        { 
            public int val; 
            public TreeNode left; 
            public TreeNode right; 
        
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
            {
                 this.val = val;
                 this.left = left;
                 this.right = right;
             } 
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        [TestFixture]
        class MaxSubArraySolutionTests
        {
            // Input: p = [1,2,3], q = [1,2,3] Output: true
            // Input: p = [1,2], q = [1,null,2] Output: false
            // Input: p = [1,2,1], q = [1,1,2] Output: false

            static TreeNode b1 = new TreeNode(1, new TreeNode(2));
            static TreeNode b2 = new TreeNode(1, null, new TreeNode(2));
            
            static TreeNode a1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            static TreeNode a2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            static TreeNode c1 = new TreeNode(1, new TreeNode(2), new TreeNode(1));
            static TreeNode c2 = new TreeNode(1, new TreeNode(1), new TreeNode(2));
            
            [Test]
            public static void TestCases()
            {
                Assert.IsFalse(IsSameTree(b1, b2));
                Assert.IsTrue(IsSameTree(a1, a2));
                Assert.IsFalse(IsSameTree(c1, c2));
            }
        }
    }

    class LengthOfTheLastWordSolution
    {
        // https://leetcode.com/problems/length-of-last-word/
        static void Main(string[] args)
        {
            var s = "   fly me   to   the moon  ";
            var s1 = "a";

            LengthOfLastWord(s);
        }
        
        static int LengthOfLastWord(string sentence)
        {
            var trimedSentence = sentence;
            var lastWord = string.Empty;
            for (int i = trimedSentence.Length - 1; i >= 0; i--)
            {
                var character = trimedSentence[i];
                if (Char.IsWhiteSpace(character))
                {
                    break;
                }

                lastWord += character;
            }

            return lastWord.Length;
        }
    }

    class PlusOneSolution
    {
        // https://leetcode.com/problems/plus-one/submissions/
        public static int[] PlusOne(int[] digits)
        {
            var digitsString = string.Join("", digits);
            var number = BigInteger.Parse(digitsString);
            var incrementedNumber = number + 1;
            return incrementedNumber.ToString().Select(x => int.Parse(x.ToString())).ToArray();
        }

        public static int[] PlusOne1(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i] += 1;
                    return digits;
                }

                digits[i] = 0;
            }

            var newDigs = new int [digits.Length + 1];
            newDigs[0] = 1;
            return newDigs;
        }

        [TestFixture]
        public static class StrStrSolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(new int [] {1,2,4}, PlusOne1(new int [] {1, 2, 3}));
                Assert.AreEqual(new int [] {4,3,2,2}, PlusOne1(new int [] {4, 3, 2, 1}));
                Assert.AreEqual(new int [] {1, 0}, PlusOne1(new int [] {9}));
            }
        }
    }    
    
    // https://leetcode.com/problems/add-binary/
    class AddBinarySolution
    {
        static string AddBinary(string a, string b)
        {
            if (a.Length > b.Length)
            {
                b = new string('0', a.Length - b.Length) + b;
            }
            else if (b.Length > a.Length)
            {
                a = new string('0', b.Length - a.Length) + a;
            }

            var result = new StringBuilder();
            var carry = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                var aNumber = int.Parse(a[i].ToString());
                var bNumber = int.Parse(b[i].ToString());
                var sum = aNumber + bNumber + carry;
                var res = sum % 2;
                carry = sum / 2;
                result.Insert(0, res);
            }

            if (carry != 0)
            {
                result.Insert(0, carry);
            }

            return result.ToString();
        }

        [TestFixture]
        public static class StrStrSolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual("100", AddBinary("11", "1"));
                Assert.AreEqual("10101", AddBinary("1010", "1011"));
            }
        }
    }
    
    // https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/727/
    class RemoveDuplicatesFromSortedArraySolution
    {
        public static int RemoveDuplicates(int[] nums) 
        {
            if (nums.Length == 1)
            {
                return 1;
            }

            int k = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var currentNum = nums[i];
                var lastOkNum = nums[k - 1];
                
                if (lastOkNum != currentNum)
                {
                    nums[i] = -111;
                    nums[k] = currentNum;
                    k++;
                    continue;
                }

                nums[i] = -111;
            }

            return k;
        }

        [TestFixture]
        public static class RemoveDuplicatesFromSortedArraySolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(5, RemoveDuplicates(new int [] {1, 2, 3, 3, 4, 5}));
                Assert.AreEqual(5, RemoveDuplicates(new int [] {0,0,1,1,1,2,2,3,3,4}));
                Assert.AreEqual(2, RemoveDuplicates(new int [] {1, 1, 2}));
            }
        }
        
        // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/
        class TheBestTimeToBuyAndSellStockSolution
        {
            public static int MaxProfit(int[] prices)
            {
                if (prices.Length == 1)
                {
                    return 0;
                }
                
                var totalProfit = 0;
                int? bought = null;
                for (int i = 0; i < prices.Length - 1; i++)
                {
                    var current = prices[i];
                    var nextDay = prices[i + 1];

                    if (current > nextDay)
                    {
                        continue;
                    }

                    if (bought == null)
                    {
                        bought = prices[i];
                    }

                    if (i < prices.Length - 2)
                    {
                        var dayAfterNext = prices[i + 2];
                        if (dayAfterNext > nextDay)
                        {
                            continue;
                        }
                    }

                    totalProfit += nextDay - bought.Value;
                    bought = null;
                }

                return totalProfit;
            }

            public static int MaxProfit2(int[] prices)
            {
                int maxProfit = 0;
                for (int i = 0; i < prices.Length - 1; i++)
                {
                    if (prices[i] < prices[i + 1])
                    {
                        maxProfit += prices[i + 1] - prices[i];
                    }
                }

                return maxProfit;
            }

            [TestFixture]
            public static class TheBestTimeToBuyAndSellStockSolutionTests
            {
                [Test]
                public static void TestCases()
                {
                    Assert.AreEqual(7, MaxProfit(new int[] {7,1,5,3,6,4}));
                    Assert.AreEqual(6, MaxProfit(new int[] {7,1,5,7,6,4}));
                    Assert.AreEqual(4, MaxProfit(new int[] {1,2,3,4,5}));
                    Assert.AreEqual(0, MaxProfit(new int[] {7,6,4,3,1}));   
                    
                    Assert.AreEqual(7, MaxProfit2(new int[] {7,1,5,3,6,4}));
                    Assert.AreEqual(6, MaxProfit2(new int[] {7,1,5,7,6,4}));
                    Assert.AreEqual(4, MaxProfit2(new int[] {1,2,3,4,5}));
                    Assert.AreEqual(0, MaxProfit2(new int[] {7,6,4,3,1}));
                }
            }
        }
    }
    
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    class RotateArraySolution
    {
        public static int[] Rotate(int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < nums.Length + i; j++)
                {
                }
            }

            return nums;
        }
        
        [TestFixture]
        public static class RotateArraySolutionTests
        {
            [Test]
            public static void TestCases()
            {
                Assert.AreEqual(new int []{5,6,7,1,2,3,4}, Rotate(new int[] {1,2,3,4,5,6,7}, 3));
            }
        }
    }
}