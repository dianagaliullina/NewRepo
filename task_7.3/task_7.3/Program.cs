using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите позицию белой ладьи: ");
        var whiteRookPosition = Console.ReadLine();
        Console.WriteLine("Введите позицию черного короля: ");
        var blackKingPosition = Console.ReadLine();
        Console.WriteLine("Введите позицию хода белой ладьи: ");
        var move = Console.ReadLine();

        if (DoesWhiteRookMoveCorrect(whiteRookPosition, move, blackKingPosition))
        {
            if (!CanBlackKingStrike(blackKingPosition, move))
            {
                Console.WriteLine("ход разрешен");
            }
            else
            {
                Console.WriteLine("Ладья не может ходить сюда, так как находится под боем");
            }
        }
        else
        {
            Console.WriteLine("Ладья не может сделать этот ход");
        }

        Console.ReadKey();
    }

    static void DecodePosition(string position, out int column, out int row)
    {
        column = (int)position[0] - 0x60;
        row = int.Parse(position[1].ToString());
    }

    static bool CanWhiteRookStrike(string whiteRookPosition, string position)
    {
        int wrRow, wrColumn, pRow, pColumn;
        DecodePosition(whiteRookPosition, out wrColumn, out wrRow);
        DecodePosition(position, out pColumn, out pRow);
        return wrRow == pRow && wrColumn == pColumn;
    }

    static bool CanBlackKingStrike(string blackKingPosition, string position)
    {
        int bkRow, bkColumn, pRow2, pColumn2;
        DecodePosition(blackKingPosition, out bkColumn, out bkRow);
        DecodePosition(position, out pColumn2, out pRow2);
        return Math.Abs(bkRow - pRow2) <= 1 && Math.Abs(bkColumn - pColumn2) <= 1;
    }

    static bool DoesWhiteRookMoveCorrect(string whiteRookPosition, string move, string blackKingPosition)
    {
        int wr, wc, br, bc, mr, mc;
        DecodePosition(whiteRookPosition, out wc, out wr);
        DecodePosition(blackKingPosition, out bc, out br);
        DecodePosition(move, out mc, out mr);

        return (wc == mc || wr == mr);
    }
}
