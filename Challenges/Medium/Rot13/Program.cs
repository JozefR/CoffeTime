using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Rot13
{
    class Program
    {
        static void Main(string[] args)
        {
            Rot13("10+2 is twelve.");
        }

        public static string Rot13Clever(string input)
        {
            var alphabetUpper = GetUpperAlphabet();
            var alphabetLower = GetLowerAlphabet();

            var result = "";
            for (int i = 0; i < input.Length; i++)
            {
                var chars = Char.IsUpper(input[i]);
                var index = chars ? alphabetUpper[input[i]] : alphabetLower[input[i]];
                result += index == -1 ? input[i] : input[(index + 13) % alphabetLower.Count];
            }

            return result;
        }

        public static string Rot13(string input)
        {
            var alphabetUpper = GetUpperAlphabet();
            var alphabetLower = GetLowerAlphabet();
            
            var result = "";

            for (int i = 0; i < input.Length; i++)
            {
                result += ShiftCharacter(input[i], alphabetUpper, alphabetLower);
            }

            return result;
        }

        private static string ShiftCharacter(char character, List<char> alphabetUpper, List<char> alphabetLower)
        {
            var result = "";
            
            int indexToCheck = alphabetUpper.IndexOf(character);
            bool lowerCharacter = false;

            if (indexToCheck == -1)
            {
                indexToCheck = alphabetLower.IndexOf(character);

                if (indexToCheck == -1)
                {
                    return character.ToString();
                }
                
                lowerCharacter = true;
            }
                
            var rot13 =  (indexToCheck + 13) % alphabetLower.Count;
            result += lowerCharacter ? alphabetLower[rot13] : alphabetUpper[rot13];
            return result;
        }

        private static List<char> GetUpperAlphabet()
        {
            var alphabet = new List<char>();
            for (char c = 'A'; c <= 'Z'; ++c) {
                alphabet.Add(c);
            }
            return alphabet;
        }
        
        private static List<char> GetLowerAlphabet()
        {
            var alphabet = new List<char>();
            for (char c = 'a'; c <= 'z'; ++c) {
                alphabet.Add(c);
            }
            return alphabet;
        }
    }
    
    [TestFixture]
    public class Rot13Test
    {
        [Test, Description("test")]
        public void testTest()
        {
            Assert.AreEqual("grfg", Program.Rot13("test"), String.Format("Input: test, Expected Output: grfg, Actual Output: {0}", Program.Rot13("test")));
        }
    
        [Test, Description("Test")]
        public void TestTest()
        {
            Assert.AreEqual("Grfg", Program.Rot13("Test"), String.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", Program.Rot13("Test")));
        }
    }
}