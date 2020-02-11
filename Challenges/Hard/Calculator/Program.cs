using System;
using NUnit.Framework;

/*
Create a simple calculator that given a string of operators (), +, -, *, / and numbers separated by spaces returns the value of that expression

Example:

Calculator().evaluate("2 / 2 + 3 * 4 - 6") # => 7
Remember about the order of operations! Multiplications and divisions have a higher priority and should be performed left-to-right.
Additions and subtractions have a lower priority and should also be performed left-to-right.
 */

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Evaluator
        {
            public double Evaluate(string expression)
            {
                return 0.0;
            }
        }
    }

    [TestFixture]
    public class CalculatorTests
    {
        private Program.Evaluator Evaluator { get; set; } = new Program.Evaluator();

        [Test]
        [TestCase("1-1", ExpectedResult = 0)]
        [TestCase("1+1", ExpectedResult = 2)]
        public double TestCases(string expression)
        {
            return Evaluator.Evaluate(expression);
        }
    }
}