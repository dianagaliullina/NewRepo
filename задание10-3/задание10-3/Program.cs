using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите вещественное число a (1 < a < 2): ");
            double a = Convert.ToDouble(Console.ReadLine());

            if (a <= 1 || a >= 2)
            {
                Console.WriteLine("Число a должно быть в диапазоне 1 < a < 2.");
                return;
            }

            int N = 1;
            double result = 1 + 1.0 / N;

            while (result >= a)
            {
                N++;
                result = 1 + 1.0 / N;
            }

            Console.WriteLine($"Первое число меньше {a} это: 1 + 1/{N}");
            Console.ReadKey();
        }
    }
}
