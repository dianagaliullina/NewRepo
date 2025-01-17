using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текущий курс доллара: ");
            decimal exchangeRate = Convert.ToDecimal(Console.ReadLine());

            StringBuilder table = new StringBuilder();

            table.AppendLine("\nТаблица перевода долларов в рубли (от $10 до $1000):\n");
            table.AppendLine($"{"Доллары",-10} {"Рубли",-15}");
            table.AppendLine(new string('-', 25));

            for (int dollars = 10; dollars <= 1000; dollars += 10)
            {
                decimal rubles = dollars * exchangeRate;
                table.AppendLine($"{dollars,-10} {rubles,-15:F2}");
            }

            Console.WriteLine(table.ToString());
            Console.ReadKey();
        }
    }
}
