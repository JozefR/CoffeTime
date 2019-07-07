using System;
using System.Linq;
using NUnit.Framework;

namespace Easy.PersistentBugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Persistence(39);
        }

        public static long Persistence(long n)
        {
            // 1. convert to string
            // 2. iterate over characters
            // 3. each char convert back to long and multiple all of them => result
            // 4. If string lengh greater then 1 continue to point 1.
            // 5. Return result.
            var chars = n.ToString();
            long result = 0;

            while (chars.Length > 1)
            {
                long multiplication = int.Parse(chars[0].ToString());

                for (int i = 1; i < chars.Length; i++)
                {
                    multiplication *= int.Parse(chars[i].ToString());
                }

                chars = multiplication.ToString();
                result++;
            }

            return result;
        }

        public static int Persistence1(long n)
        {
            int count = 0;
            while (n > 9)
            {
                count++;
                n = n.ToString().Select(digit => int.Parse(digit.ToString())).Aggregate((x, y) => x * y);
            }
            return count;
        }

        public static int Persistence2(long n)
        {
            int count = 0;

            string number = n.ToString();
            while(number.Length > 1)
            {
                n = 1;
                Array.ForEach(number.ToArray(), c => n = n * (long)Char.GetNumericValue(c));
                number = n.ToString();
                count++;
            }

            return count;
        }
    }

    [TestFixture]
    public class PersistTests {

        [Test]
        public void Test1() {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual(3, Program.Persistence(39));
            Assert.AreEqual(0, Program.Persistence(4));
            Assert.AreEqual(2, Program.Persistence(25));
            Assert.AreEqual(4, Program.Persistence(999));
        }
    }
}