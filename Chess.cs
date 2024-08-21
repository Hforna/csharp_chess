using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;

enum Column
{
    "A",
    "B",
    "C",
    "D",
    "E",
    "F",
    "G",
    "H"
}

class Piece
{
    public int currColumn;
    public int currRow;
    public bool ValidPosition(int ToColumn, int ToRow, int CurrColumn, int CurrRow, Piece[,] table)
    {
        return false;
    }
}

class King : Piece
{
    public int currColumn;
    public int currRow;

    public bool ValidPosition(int ToColumn, int ToRow, int CurrColumn, int CurrRow, Piece[,] table)
    {
        int rowDiff = Math.Abs(ToRow - CurrRow);
        int columnDiff = Math.Abs(ToColumn - CurrColumn);
        bool veriP = rowDiff <= 1 && columnDiff <= 1;
        if (table[ToRow, ToColumn] == null && veriP)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "K";
    }

}

class Board
{
    private readonly Piece[,] Table = new Piece[8, 8];

    public void MovePiece(Piece piece, char ToColumn, int ToRow)
    {
        while (piece.ValidPosition(ToColumn, ToRow, piece.currColumn, piece.currRow, Table) == false)
        {
            Console.WriteLine("Invalid move");
            if (piece.ValidPosition(ToColumn, ToRow, piece.currColumn, piece.currRow, Table))
            {
                Table[ToRow, ToColumn] = piece;
                piece.currColumn = ToColumn;
                piece.currRow = ToRow;
                break;
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
        for (int i = 0; i < 8; i++)
        {
            for (int r = 0; r < 8; r++)
            {
                Console.Write(Table[i, r]);
            }
            Console.WriteLine();
        }
    }
}