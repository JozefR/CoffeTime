using System;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            var gcdNon = GCDNonRecursion(24, 12);
            var gcdNon2 = GCDNonRecursion(42, 56);
            var gcd = GCD(24, 12);
            var gcd2 = GCD(42, 56);
        }

        private static int GCDNonRecursion(int a, int b)
        {
            while (b != 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }

            return a;
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            return GCD(b, a % b);
        }
    }
}