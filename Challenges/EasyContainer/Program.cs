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
    
    class AddTwoNumbersMedium
    {
        /*
        https://leetcode.com/problems/add-two-numbers/
        You are given two non-empty linked lists representing two non-negative integers. 
        The digits are stored in reverse order, and each of their nodes contains a single digit. 
        Add the two numbers and return the sum as a linked list.
        
        Example 1:

        2 -> 4 -> 3
        5 -> 6 -> 4
        -----------
        7 -> 0 -> 8

        You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        
        Input: l1 = [2,4,3], l2 = [5,6,4]
        Output: [7,0,8]
        Explanation: 342 + 465 = 807.
        
        Example 2:

        Input: l1 = [0], l2 = [0]
        Output: [0]
        Example 3:

        Example 3:
        
        Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        Output: [8,9,9,9,0,0,0,1]
        
        Constraints:

        The number of nodes in each linked list is in the range [1, 100].   
        0 <= Node.val <= 9
        It is guaranteed that the list represents a number that does not have leading zeros.
         */

        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */
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
        
        // reverse the lists, also the result
        // append the numbers to string
        // sum both strings
        // return result as a reversed linked list
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1String = string.Empty;
            var iterate = l1;

            while (iterate != null)
            {
                l1String += iterate.val;

                iterate = iterate.next;
            }
            
            char[] l1ReversedChar = l1String.ToCharArray();
            Array.Reverse(l1ReversedChar);
            string l1Reversed = new string(l1ReversedChar);

            var l2string = string.Empty;
            var iterate2 = l2;
            
            while (iterate2 != null)
            {
                l2string += iterate2.val;

                iterate2 = iterate2.next;
            }

            char[] l2ReversedChar = l2string.ToCharArray();
            Array.Reverse(l2ReversedChar);
            string l2Reversed = new string(l2ReversedChar);

            var sum = (BigInteger.Parse(l1Reversed.ToString()) + BigInteger.Parse(l2Reversed.ToString())).ToString().ToList();

            ListNode temp = new ListNode(int.Parse(sum[0].ToString()), null);
            ListNode result = null;
            for (int i = 1; i < sum.Count; i++)
            { 
                var second = new ListNode(int.Parse(sum[i].ToString()), temp);
                temp = second;
            }

            return temp;
        }
        
        // Sum just like on the paper
        // start from the lest significant value, which is in this case head, because of reversed digits
        // handle carry which can be 0 or 1
        // go on until no digits left on both linked lists
        public static ListNode AddTwoNumbersPaper(ListNode l1, ListNode l2)
        {
            var p = l1;
            var q = l2;
            var carry = 0;
            var dummyHead = new ListNode();
            var curr = dummyHead;
            
            while (p != null || q != null)
            {
                var a = p != null ? p.val : 0;
                var b = q != null ? q.val : 0;

                var sum = a + b + carry;
                carry = sum / 10;
                curr.val = sum % 10;

                if (p != null) p = p.next;
                if (q != null) q = q.next;

                if (p != null || q != null)
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }
            }

            if (carry > 0) {
                curr.next = new ListNode(carry);
            }
            
            return dummyHead;
        }

        [TestFixture]
        public static class AddTwoNumbersTests
        {
            [Test]
            public static void AreAddTwoNumbers()
            {
                var l17 = new ListNode(9, null);
                var l16 = new ListNode(9, l17);
                var l15 = new ListNode(9, l16);
                var l14 = new ListNode(9, l15);
                var l13 = new ListNode(9, l14);
                var l12 = new ListNode(9, l13);
                var l11 = new ListNode(9, l12);
                
                var l24 = new ListNode(9, null);
                var l23 = new ListNode(9, l24);
                var l22 = new ListNode(9, l23);
                var l21 = new ListNode(9, l22);
                
                var l38 = new ListNode(8, null);
                var l37 = new ListNode(9, l38);
                var l36 = new ListNode(9, l37);
                var l35 = new ListNode(9, l36);
                var l34 = new ListNode(0, l35);
                var l33 = new ListNode(0, l34);
                var l32 = new ListNode(0, l33);
                var l31 = new ListNode(1, l32);
                
                Assert.AreEqual(l31, AddTwoNumbersPaper(l11, l22));
            }
        }
    }
}
