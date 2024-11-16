using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите трехзначное число: ");
            int n = int.Parse(Console.ReadLine());

            int hundreds = n / 100;
            int tens = (n / 10) % 10;
            int units = n % 10;
            int x = hundreds * 100 + units * 10 + tens;


            Console.WriteLine(x);

            Console.ReadKey();
        }
    }
}
