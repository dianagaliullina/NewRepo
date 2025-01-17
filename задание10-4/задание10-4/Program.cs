using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число k (1 <= k <= 8): ");
            int k = Convert.ToInt32(Console.ReadLine());

            if (k < 1 || k > 8)
            {
                Console.WriteLine("Число k должно быть в диапазоне 1 <= k <= 8.");
                return;
            }

            int product = 1;
            bool found = false;

            while (n > 0)
            {
                int digit = n % 10;  
                if (digit > k)
                {
                    product *= digit; 
                    found = true;
                }
                n /= 10; 
            }

            if (!found)
            {
                Console.WriteLine("Произведение = 1, так как в числе нет цифр, больших k.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Произведение цифр, больших {k}, равно: {product}");
                Console.ReadKey();
            }
        }
    }
}
