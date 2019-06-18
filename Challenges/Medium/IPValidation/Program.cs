using System;
using System.Net;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace IPValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool is_valid_IP(string ipAddress)
        {
            if (Regex.IsMatch(ipAddress, @"^(?:(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])(\.(?!$)|$)){4}$"))
            {
                return true;
            }

            return false;
        }

        public static bool is_valid_IP2(string ipAddress)
        {
            IPAddress ip;
            bool validIp = IPAddress.TryParse(ipAddress, out ip);
            return validIp && ip.ToString() == ipAddress;
        }

        public static bool is_valid_IP3(string IpAddress)
        {
            var octet = "([1-9][0-9]{0,2})";
            var reg = $@"{octet}\.{octet}\.{octet}\.{octet}";
            return new Regex(reg).IsMatch(IpAddress);
        }


    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void TestCases()
        {
            Assert.AreEqual(true, Program.is_valid_IP("0.0.0.0"));
            Assert.AreEqual(true, Program.is_valid_IP("12.255.56.1"));
            Assert.AreEqual(true, Program.is_valid_IP("137.255.156.100"));

            Assert.AreEqual(false, Program.is_valid_IP(""));
            Assert.AreEqual(false, Program.is_valid_IP("abc.def.ghi.jkl"));
            Assert.AreEqual(false, Program.is_valid_IP("123.456.789.0"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.56"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.56.00"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.56.7.8"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.256.78"));
            Assert.AreEqual(false, Program.is_valid_IP("1234.34.56"));
            Assert.AreEqual(false, Program.is_valid_IP("pr12.34.56.78"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.56.78sf"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.56 .1"));
            Assert.AreEqual(false, Program.is_valid_IP("12.34.56.-1"));
            Assert.AreEqual(false, Program.is_valid_IP("123.045.067.089"));
        }
    }
}