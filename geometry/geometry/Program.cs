using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometry
{

    class Program
    {
        // Структура для хранения координат точки
        struct Point
        {
            public double X;
            public double Y;

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        // Метод для вычисления расстояния между двумя точками
        static double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

        // Метод для вычисления периметра треугольника
        static double CalculatePerimeter(Point A, Point B, Point C)
        {
            double AB = Distance(A, B);
            double BC = Distance(B, C);
            double CA = Distance(C, A);
            return AB + BC + CA;
        }

        // Метод для вычисления площади треугольника по формуле Герона
        static double CalculateArea(Point A, Point B, Point C)
        {
            double AB = Distance(A, B);
            double BC = Distance(B, C);
            double CA = Distance(C, A);

            double s = (AB + BC + CA) / 2; // Полупериметр
            return Math.Sqrt(s * (s - AB) * (s - BC) * (s - CA)); // Формула Герона
        }

        static void Main(string[] args)
        {
            // Ввод координат вершин треугольника
            Console.WriteLine("Введите координаты вершины A (x1 y1):");
            var inputA = Console.ReadLine().Split();
            Point A = new Point(double.Parse(inputA[0]), double.Parse(inputA[1]));

            Console.WriteLine("Введите координаты вершины B (x2 y2):");
            var inputB = Console.ReadLine().Split();
            Point B = new Point(double.Parse(inputB[0]), double.Parse(inputB[1]));

            Console.WriteLine("Введите координаты вершины C (x3 y3):");
            var inputC = Console.ReadLine().Split();
            Point C = new Point(double.Parse(inputC[0]), double.Parse(inputC[1]));

            // Вычисление периметра и площади
            double perimeter = CalculatePerimeter(A, B, C);
            double area = CalculateArea(A, B, C);

            // Вывод результатов
            Console.WriteLine($"Периметр треугольника: {perimeter}");
            Console.WriteLine($"Площадь треугольника: {area}");

            Console.ReadKey();
        }
    }
}
