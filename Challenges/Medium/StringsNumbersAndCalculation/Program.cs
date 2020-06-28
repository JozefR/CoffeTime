using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace StringsNumbersAndCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class OtherSolutions
    {
        public string calculateString(string calcIt)
        {
            string expression = string.Concat(Regex.Matches(calcIt, @"[\d\+\-\/\*\.]").Cast<Match>().Select(e => e.Value));
            double result = Convert.ToDouble(new DataTable().Compute(expression, null));

            return (Math.Round(result)).ToString();
        }

        public string calculateString1(string calcIt)
        {
            var temp = calcIt
                .Split('*', '/', '+', '-')
                .Select(x => String.Concat(x.ToCharArray().Where(y => Char.IsDigit(y) || y == '.')))
                .ToArray();

            double res;

            if (calcIt.Contains('*'))
                res = (double.Parse(temp[0]) * double.Parse(temp[1]));
            else if (calcIt.Contains('/'))
                res = (double.Parse(temp[0]) / double.Parse(temp[1]));
            else if (calcIt.Contains('+'))
                res = (double.Parse(temp[0]) + double.Parse(temp[1]));
            else
                res = (double.Parse(temp[0]) - double.Parse(temp[1]));

            return Convert.ToInt64(res).ToString();
        }

        public string calculateString2(string calcIt)
        {
            char operation = calcIt[calcIt.IndexOfAny("+-*/".ToCharArray())];
            var numbers = calcIt.Split(operation).Select(s=>double.Parse(string.Concat(s.Where(c=>char.IsDigit(c)||c=='.')))).ToArray();
            return operation switch
            {
                '+' => Convert.ToInt64(numbers[0] + numbers[1]).ToString(),
                '-' => Convert.ToInt64(numbers[0] - numbers[1]).ToString(),
                '*' => Convert.ToInt64(numbers[0] * numbers[1]).ToString(),
                '/' => Convert.ToInt64(numbers[0] / numbers[1]).ToString(),
            };
        }
    }

    class Calculator
    {
        private static readonly List<char> _possibleOperations = new List<char> {'+', '-', '/', '*'};
        private static string _resultOperation = "";

        public static string Calculate(string dirtyString)
        {
            var clean = CombineDigitsFromDirtyString(dirtyString);
            var result = PerformOperation(clean);
            return result.ToString();
        }

        static string CombineDigitsFromDirtyString(string input)
        {
            var result = "";

            foreach (var value in input)
            {
                if (char.IsDigit(value))
                {
                    result += value;
                }

                if (value == '.')
                {
                    result += value;
                }

                if (_possibleOperations.Contains(value))
                {
                    _resultOperation = value.ToString();
                    result += value;
                }
            }

            return result;
        }

        private static double PerformOperation(string clean)
        {
            var numbers = clean.Split(_resultOperation);

            double calculation = 0;
            if (_resultOperation == "+")
            {
                calculation = double.Parse(numbers[0]) + double.Parse(numbers[1]);
            }

            if (_resultOperation == "-")
            {
                calculation = double.Parse(numbers[0]) - double.Parse(numbers[1]);
            }

            if (_resultOperation == "*")
            {
                calculation = double.Parse(numbers[0]) * double.Parse(numbers[1]);
            }

            if (_resultOperation == "/")
            {
                calculation = double.Parse(numbers[0]) / double.Parse(numbers[1]);
            }

            return Math.Round(calculation);
        }
    }

    public class StringsNumbersAndCalculationTests
    {
        [Test]
        public void smile67KataTest_withoutRandom1()
        {
            Assert.AreEqual("47", Calculator.Calculate("sd235df/sdfgf5gh.000kk0000"));
        }

        [Test]
        public void smile67KataTest_withoutRandom2()
        {
            Assert.AreEqual("54929268", Calculator.Calculate("sdfsd23454sdf*2342"));
        }

        [Test]
        public void smile67KataTest_withoutRandom3()
        {
            Assert.AreEqual("-210908", Calculator.Calculate("fsdfsd235???34.4554s4234df-sdfgf2g3h4j442"));
        }

        [Test]
        public void smile67KataTest_withoutRandom4()
        {
            Assert.AreEqual("2513277676", Calculator.Calculate("50G74OR0.kVtvaM^O3aT0nhKkhlsZK[[91M9ZjZX5HhnUpBUM0mQAoA064*N`4Wq9\\j5B32^NKPST.1w7wZE1\\0W9F1MHku7EqWBq783"));
        }
    }
}