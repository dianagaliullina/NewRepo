using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число b (b > a): ");
            int b = Convert.ToInt32(Console.ReadLine());

            // Проверка, что b > a
            if (a >= b)
            {
                Console.WriteLine("Число b должно быть больше числа a");
                Console.ReadKey();
                return;
            }

            int totalSum = 0;  

            for (int i = a; i <= b; i++)
            {
                int sumDividers = 0;  

                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        sumDividers += j;
                    }
                }

                totalSum += sumDividers;
            }

            Console.WriteLine($"Общая сумма делителей: {totalSum}");
            Console.ReadKey();
        }
    }
}
