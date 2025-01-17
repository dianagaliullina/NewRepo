using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество административных единиц: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double totalArea = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nАдминистративная единица {i}:");

                Console.Write("Введите количество жителей: ");
                double population = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите плотность населения: ");
                double density = Convert.ToDouble(Console.ReadLine());

                double area = population / density;

                totalArea += area;
            }

            Console.WriteLine($"\nОбщая площадь страны: {totalArea:F2}");
            Console.ReadKey();
        }
    }
}
