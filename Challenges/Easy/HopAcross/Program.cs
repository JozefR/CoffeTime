using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HopAcross
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int HopAcross(List<int> list)
        {
            var value = list[0];
            var hop = 1;

            while (value < list.Count)
            {
                ++hop;
                value += list[value];
            }

            list.Reverse();

            var back = 1;
            var valueBack = list[0];

            while (valueBack < list.Count)
            {
                ++back;
                valueBack += list[valueBack];
            }

            return hop + back;
        }
    }
    
    [TestFixture]
    public class HopTest
    {
        [Test]
        public void HopAcrossTest()
        {
            Assert.That(Program.HopAcross(new List<int> {1}), Is.EqualTo(2));
            Assert.That(Program.HopAcross(new List<int> {2}), Is.EqualTo(2));
            Assert.That(Program.HopAcross(new List<int> {1, 1}), Is.EqualTo(4));
            Assert.That(Program.HopAcross(new List<int> {2, 1}), Is.EqualTo(3));
            Assert.That(Program.HopAcross(new List<int> {2, 1, 1}), Is.EqualTo(5));
            Assert.That(Program.HopAcross(new List<int> {1, 2, 1, 2}), Is.EqualTo(5));
            Assert.That(Program.HopAcross(new List<int> {1, 2, 5, 1}), Is.EqualTo(5));
            Assert.That(Program.HopAcross(new List<int> {2, 2, 3, 1, 1, 2, 1}), Is.EqualTo(7));
        }
    }
}