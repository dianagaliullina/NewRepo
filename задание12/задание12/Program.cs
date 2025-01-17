using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание12
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите количество строк m (5 <= m <= 20): ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество столбцов n (5 <= n <= 20): ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (m < 5 || m > 20)
            {
                Console.WriteLine("Значение числа m не соответствует условию.");
                Console.ReadKey();
                return;
            }

            if (n < 5 || n > 20)
            {
                Console.WriteLine("Значение числа n не соответствует условию.");
                Console.ReadKey();
                return;
            }

            int[,] array = new int[m, n];
            Random random = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(0, 100);
                }
            }

            Console.WriteLine("Массив:");
            PrintArray(array);
            Console.ReadKey();

            int zeroCount = CountZeroElements(array);
            Console.WriteLine($"Количество нулей в массиве: {zeroCount}");
            Console.ReadKey();

            int[] differences = RowEvenOddDifference(array);

            Console.WriteLine("Разность сумм четных и нечетных элементов для каждой строки:");
            for (int i = 0; i < differences.Length; i++)
            {
                Console.WriteLine($"Строка {i + 1}: разность = {differences[i]}");
                Console.ReadKey();
            }
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j],4} ");
                }
                Console.WriteLine();
            }
        }

        static int CountZeroElements(int[,] array)
        {
            int zeroCount = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        zeroCount++;
                    }
                }
            }
            return zeroCount;
        }

        static int[] RowEvenOddDifference(int[,] array)
        {
            int[] differences = new int[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % 2 == 0)
                        evenSum += array[i, j];
                    else
                        oddSum += array[i, j];
                }

                differences[i] = evenSum - oddSum;
            }

            return differences;
        }


    }
}