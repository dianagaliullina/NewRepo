using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число n (n>1000): ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 1000)
            {
                Console.WriteLine("Число должно быть больше 1000.");
                Console.ReadKey();
                return;
                
            }

            int result = 0;
            int multiplier = 1;

            while (n > 0)
            {
                int digit = n % 10;
                if (digit % 2 != 0)
                {
                    result += digit * multiplier;
                    multiplier *= 10;
                }
                n /= 10;
            }

            Console.WriteLine($"Число без четных цифр: {result}");
            Console.ReadKey();
        }
    }
}
