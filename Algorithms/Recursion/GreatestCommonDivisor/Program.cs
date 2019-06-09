using System;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            var gcdNon2 = GCDNonRecursion(54, 24);
            var gcd = GCD(54, 24);
        }

        #region greatestCommonDivisor
        private static int GCDNonRecursion(int a, int b)
        {
            while (b != 0)
            {
                int reminder = a % b;
                a = b;
                b = reminder;
            }

            return a;
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            return GCD(b, a % b);
        }
        #endregion
    }
}