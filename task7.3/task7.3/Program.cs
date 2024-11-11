using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белой ладьи: ");
            var whiteRookPosition = Console.ReadLine();

           

                Console.ReadKey();
        }
        static bool IsWhiteRookCanStrike(string whiteRookposition, string position)
        {
            int wrRow, wrColumn, pRow, pColumn;
            DecodePosition(whiteRookposition, out wrColumn, out wrRow);
            DecodePosition(position, out pColumn, out pRow);

            return wrRow == pRow - 1 && Math.Abs(wrColumn - pColumn) == 1;
        }
        static void DecodePosition(string position,out int column, out int row)
        {
            column = (int)position[0] - 0x60;
            row = int.Parse(position[1].ToString());
        }
    }
}
