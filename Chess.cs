using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;

enum Column
{
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H



}

class Piece
{
    public char currColumn;
    public int currRow;
    public bool alive;
    public bool killAnyPiece = false;
    public virtual bool ValidPosition(int ToColumn, int ToRow, Piece[,] table)
    {
        return false;
    }
}

class Queen : Piece
{
    public override bool ValidPosition(int ToColumn, int ToRow, Piece[,] table)
    {
        int rowDiff = Math.Abs(currRow - ToRow);
        int columnDiff = Math.Abs(currColumn - ToColumn);

        if (rowDiff == columnDiff || currRow == ToRow || currColumn == ToColumn)
        {
            for (int i = 1; i < Math.Max(rowDiff, columnDiff); i++)
            {
                int checkRow = currRow + i * Math.Sign(ToRow - currRow);
                int checkCol = currColumn + i * Math.Sign(ToColumn - currColumn);
                if (table[checkRow, checkCol] != null) return false;
            }
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "Q";
    }
}

class King : Piece
{

    public override bool ValidPosition(int ToColumn, int ToRow, Piece[,] table)
    {
        int rowDiff = Math.Abs(ToRow - currRow);
        int columnDiff = Math.Abs(ToColumn - currColumn);
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

class Pawn : Piece
{
    public override bool ValidPosition(int ToColumn, int ToRow, Piece[,] table)
    {
        int rowDiff = ToRow - ToColumn;
        int columnDiff = ToColumn - currColumn;
        if(rowDiff == 0 && columnDiff == -1)
        {
            if (table[ToRow, ToColumn] == null)
            {
                return true;
            }
        } else if(columnDiff == -1 && rowDiff != 0)
        {
            if (table[ToRow, ToColumn] != null)
            {
                killAnyPiece = true;
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return "P";
    }
}

class Board
{
    private readonly Piece[,] Table = new Piece[8, 8];

    public void MovePiece(Piece piece, char ToColumn, int ToRow)
    {
        while (piece.ValidPosition(ToColumn, ToRow, Table) == false)
        {
            if (piece.ValidPosition(ToColumn, ToRow, Table))
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