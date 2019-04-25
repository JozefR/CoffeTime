using System;
using System.Collections.Generic;

namespace MultiDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Two-dimensional array. Four rows and two columns.
            int[,] array2D = {{1, 2}, {3, 4}, {5, 6}, {7, 8}};

            Console.WriteLine(array2D[0, 0]);
            Console.WriteLine(array2D[0, 1]);
            Console.WriteLine(array2D[1, 0]);
            Console.WriteLine(array2D[1, 1]);
            Console.WriteLine(array2D[2, 0]);
            Console.WriteLine(array2D[2, 1]);
            Console.WriteLine(array2D[3, 0]);
            Console.WriteLine(array2D[3, 1]);

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.Write($"{array2D[i, j]} ");
                }

                Console.WriteLine("");
            }

            Console.WriteLine($"Length of array2D {array2D.Length}");

            /* Output
             * 1 2
             * 3 4
             * 5 6
             * 7 8
             */

            int row = 3;
            int columns = 4;

            int[,] matrix = new int[row, columns];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine("");
            }

            // Three-dimensional array.
            int[,,] array3D = new int[,,] {{{1, 2, 3}, {4, 5, 6}}, {{7, 8, 9}, {10, 11, 12}}};

            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    for (int x = 0; x < array3D.GetLength(2); x++)
                    {
                        Console.Write($"{array3D[i, j, x]} ");
                    }

                    Console.WriteLine("");
                }
            }

            /*
             * 1 2 3
             * 4 5 6
             * 7 8 9
             * 10 11 12
             */

            /////////////////////////////////////////////////////////////////


            var riskList = new List<Risk>
            {
                new Risk {Name = "Low"},
                new Risk {Name = "Medium"},
                new Risk {Name = "High"},
                new Risk {Name = "Critical"}
            };

            var analysis = new List<Analysis>
            {
                new Analysis {Name = "Impact"},
                new Analysis {Name = "Vulnerability"},
                new Analysis {Name = "Integrity"}
            };

            Risk[][] arr = new Risk[3][];

            arr[0] = new Risk[4]
            {
                new Risk() {Name = "Low"}, new Risk() {Name = "Medium"}, new Risk() {Name = "High"},
                new Risk() {Name = "Critical"}
            };
            arr[1] = new Risk[4]
            {
                new Risk() {Name = "Low"}, new Risk() {Name = "Medium"}, new Risk() {Name = "High"},
                new Risk() {Name = "Critical"}
            };
            arr[2] = new Risk[4]
            {
                new Risk() {Name = "Low"}, new Risk() {Name = "Medium"}, new Risk() {Name = "High"},
                new Risk() {Name = "Critical"}
            };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j].Name);
                }

                Console.WriteLine();
            }
        }

        class Risk
        {
            public string Name { get; set; }
        }

        class Analysis
        {
            public string Name { get; set; }
        }
    }
}