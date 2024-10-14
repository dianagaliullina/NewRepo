using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты первой вершины (x1 y1):");
            string[] input1 = Console.ReadLine().Split(' ');
            double x1 = double.Parse(input1[0]);
            double y1 = double.Parse(input1[1]);

            Console.WriteLine("Введите координаты второй вершины (x2 y2):");
            string[] input2 = Console.ReadLine().Split(' ');
            double x2 = double.Parse(input2[0]);
            double y2 = double.Parse(input2[1]);

            Console.WriteLine("Введите координаты третьей вершины (x3 y3):");
            string[] input3 = Console.ReadLine().Split(' ');
            double x3 = double.Parse(input3[0]);
            double y3 = double.Parse(input3[1]);

            double a = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); 
            double b = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2)); 
            double c = Math.Sqrt((x3 - x1) * (x3 - x1) + (y3 - y1) * (y3 - y1)); 

            double perimeter = a + b + c;
            perimeter = Math.Round(perimeter, 2);

            double half = perimeter / 2; 
            double s = Math.Sqrt(half * (half - a) * (half - b) * (half - c));
            s = Math.Round(s, 2);

            Console.WriteLine($"Периметр треугольника: {perimeter}");
            Console.WriteLine($"Площадь треугольника: {s}");

            Console.ReadKey();
        }
    }
}
