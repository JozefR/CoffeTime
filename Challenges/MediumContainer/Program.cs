using System.Collections.Generic;
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
}