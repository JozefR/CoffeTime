namespace Factorial
 {
    class Program
    {
        static void Main(string[] args)
        {
            var recursion = FactorialFunc(3);
            var nonRec  = WithoutRecursion(3);
        }

        #region factorial
        private static int FactorialFunc(int i)
        {
            if (i == 1)
                return 1;

            return i * FactorialFunc(i - 1);
        }

        private static int WithoutRecursion(int number)
        {
            int result = number;

            for (int i = number - 1; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
        #endregion
    }
}