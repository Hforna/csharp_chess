using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;

interface IPiece
{
    public bool ValidPosition(int column, int row);
}

class Position
{
    public int column;
    public int row;
}

class Board
{
    private readonly IPiece[,] Table = new IPiece[8, 8];

    public void MovePiece(IPiece piece, char column, int row)
    {
        while (piece.ValidPosition(column, row) == false)
        {
            Console.WriteLine("Invalid move");
            if (piece.ValidPosition(column, row))
            {
                Table[column, row] = piece;
            }
        }
    }
}

class Game
{

}


class Program
{
    static void Main()
    {
        int[,] Table = new int[8, 8];
        for(int i = 0; i < 8; i++)
        {
            for(int r = 0; r < 8; r++)
            {
                Console.Write(Table[i, r]);
            }
            Console.WriteLine();
        }
}
}