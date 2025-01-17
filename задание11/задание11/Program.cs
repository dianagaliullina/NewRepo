using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание11
{
    internal class Program
    {
        static void PrintArray(double[] array)
        {
            foreach (double value in array)
            {
                Console.Write($"{value:F3} ");
            }
            Console.WriteLine();
        }

        static void ReplaceEvenElementsWithAbsolute(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    array[i] = Math.Abs(array[i]);
                }
            }
        }

        static double SqrtOfSumOfSquares(double[] array)
        {
            double sum = 0;
            foreach (double value in array)
            {
                sum += value * value;
            }
            return Math.Sqrt(sum);
        }

        static double[] CalculateSinKx(double[] array, int k)
        {
            double[] result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Math.Sin(k * array[i]);
            }
            return result;
        }

        static void Main()
        {
            Console.Write("Введите целое значение n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] array = new double[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.NextDouble() * 20 - 10; 
            }

            Console.WriteLine("Исходный массив:");
            PrintArray(array);
            Console.ReadKey();

            ReplaceEvenElementsWithAbsolute(array);

            Console.WriteLine("Массив после замены четных элементов на их модули:");
            PrintArray(array);
            Console.ReadKey();

            double sqrtSum = SqrtOfSumOfSquares(array);
            Console.WriteLine($"Квадратный корень из суммы квадратов элементов массива: {sqrtSum:F3}");
            Console.ReadKey();

            Console.Write("Введите значение k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            double[] sinKxArray = CalculateSinKx(array, k);

            Console.WriteLine("Значения функции sin(kx) для каждого элемента массива:");
            PrintArray(sinKxArray);
            Console.ReadKey();
        }
    }
}
