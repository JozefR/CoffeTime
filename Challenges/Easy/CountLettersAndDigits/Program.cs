using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CountLettersAndDigits
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
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
            var allowedCharacters = string.Concat(Enumerable.Range(0,26).Select(i => (i < 10 ? i.ToString() : "") + (char)(i + 65) + (char)(i+97)));

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
            return input.Length-new Regex(@"\d|[a-zA-Z]").Replace(input, "").Length;
        }
    }

    [TestFixture]
    public class CountLettersAndDigitsTests
    {
        [Test]
        public void TestCases()
        {
            Assert.AreEqual(0, Program.CountLettersAndDigits(null));
            Assert.AreEqual(3, Program.CountLettersAndDigits("Aba"));
            Assert.AreEqual(6, Program.CountLettersAndDigits("hel2!lo"));
            Assert.AreEqual(6, Program.CountLettersAndDigits("wicked .. !"));
            Assert.AreEqual(1, Program.CountLettersAndDigits("!?..A"));
        }
    }
}
