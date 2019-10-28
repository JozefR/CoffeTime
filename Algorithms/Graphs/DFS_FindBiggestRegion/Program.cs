using System;

namespace DFS_FindBiggestRegion
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int GetBiggestRegion(int[][] matrix)
        {
            int maxRegion = 0;
            
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 1)
                    {
                        int size = GetRegionSize(matrix, row, col);
                        maxRegion = Math.Max(size, maxRegion);
                    }
                }
            }

            return maxRegion;
        }

        private static int GetRegionSize(int[][] matrix, in int row, in int col)
        {
            if (row < 0 || col < 0 || row >= matrix.Length || col >= matrix[row].Length)
                return 0;
            if (matrix[row][col] == 0)
                return 0;

            matrix[row][col] = 0;
            int size = 1;
            for (int r = row - 1; r < row + 1; r++)
            {
                for (int c = col - 1; c < col + 1; c++)
                {
                    if (r != row || c != col)
                    {
                        size += GetRegionSize(matrix, row, col);
                    }
                }
            }

            return size;
        }
    }
}