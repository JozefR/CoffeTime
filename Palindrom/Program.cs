using System;

namespace Palindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            var nonRec = PalindromNonRec("rotor");
            var rec = PalindromRecursion("rotor", 0);
        }

        private static bool PalindromRecursion(string rotor, int i)
        {
            if (rotor.Length <= 1)
            {
                return true;
            }

            if (i == rotor.Length - i - 1)
            {
                return true;
            }

            if (rotor[i] != rotor[rotor.Length - i - 1])
                return false;

            return PalindromRecursion(rotor, i + 1);
        }

        private static bool PalindromNonRec(string rotor)
        {
            var result = "";

            for (int i = rotor.Length - 1; i >= 0; i--)
            {
                result += rotor[i];
            }

            if (result == rotor)
                return true;

            return false;
        }
    }
}