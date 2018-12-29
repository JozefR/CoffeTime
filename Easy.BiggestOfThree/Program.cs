using System;

namespace Easy.BiggestOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var sln = BiggestOfThree(3, 5, 7);
            var sln2 = BiggestOfThree(4, 8, 6);
        }

        private static int BiggestOfThree(int A, int B, int C)
        {
            int biggest = 0;

            if (A > B)
            {
                if (A > C)
                    biggest = A;
                else
                    biggest = C;
            }
            else
            {
                if (B > C)
                    biggest = B;
                else
                    biggest = C;
            }

            return biggest;
        }
    }
}