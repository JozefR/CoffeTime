using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Easy.Dubstep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var solution = SongDecoder("RWUBWUBWUBLWUB");
        }

        public static string SongDecoder(string input)
        {
            var stringWhite = input.Replace("WUB", " ").Trim();
            return Regex.Replace(stringWhite, @"\s+", " ");
        }

        public static string SongDecoder2(string input)
        {
            return String.Join(" ", new string[] {"WUB"}, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    [TestFixture]
    public class DubstepTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("ABC", Program.SongDecoder("WUBWUBABCWUB"));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("R L", Program.SongDecoder("RWUBWUBWUBLWUB"));
        }
    }
}