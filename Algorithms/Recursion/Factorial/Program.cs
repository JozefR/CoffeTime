namespace Factorial
 {
    class Program
    {
        static void Main(string[] args)
        {
            var recursion = Factorial(6);
            var nonRec  = FactorialWithouRecursion(3);
        }

        #region factorial
        private static int Factorial(int i)
        {
            if (i == 0)
                return 1;

            return i * Factorial(i - 1);
        }

        private static int FactorialWithouRecursion(int number)
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