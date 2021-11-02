using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace MediumContainer
{
    class FindPrimes
    {
        static void Main(string[] args)
        {
            var findPrime = Primes(10);
        }

        private static List<int> Primes(int number)
        {
            var primes = new List<int>();

            for (int i = 0; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        private static bool IsPrime(int i)
        {
            if (i == 0 || i == 1)
            {
                return false;
            }

            if (i == 2)
            {
                return true;
            }

            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }

            return true;
        }

        [TestFixture]
        public static class GapInPrimesTests
        {
            [Test]
            public static void ArePrimes()
            {
                Assert.AreEqual(new List<int>(), FindPrimes.Primes(1));
                Assert.AreEqual(new List<int> {2}, FindPrimes.Primes(2));
                Assert.AreEqual(new List<int> {2, 3}, FindPrimes.Primes(3));
                Assert.AreEqual(new List<int> {2, 3, 5}, FindPrimes.Primes(5));
                Assert.AreEqual(new List<int> {2, 3, 5, 7}, FindPrimes.Primes(10));
                Assert.AreEqual(new List<int> {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97}, FindPrimes.Primes(100));
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