using System;
using System.Collections.Generic;

namespace SimpleChess
{
    class Board
    {
        readonly Dictionary<string, Piece> _pieces = new Dictionary<string, Piece>();

        public void Set(string position, Piece piece)
        {
            if (_pieces.ContainsKey(position)) _pieces[position] = piece;
            else _pieces.Add(position, piece);
        }

        public bool Move(string fromPosition, string toPosition)
        {
            if (HasValue(toPosition) || !HasValue(fromPosition)) return false;
            var piece = _pieces[fromPosition];
            var isPossible = piece.Move(fromPosition, toPosition);
            if (!isPossible) return false;
            Set(toPosition, piece);
            Set(fromPosition, null);
            return true;
        }

        private bool HasValue(string position)
        {
            return _pieces.ContainsKey(position) && _pieces[position] != null;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\n8\n\n\n7\n\n\n6\n\n\n5\n\n\n4\n\n\n3\n\n\n2\n\n\n1");
            for (var row = 8; row >= 1; row--)
                for (var col = 'a'; col <= 'h'; col++)
                {
                    var left = 1 + (col - 'a') * 5;
                    var top = (8 - row) * 3;
                    var fillChar = row % 2 == col % 2 ? ' ' : '█';
                    Write(5, fillChar, left, top);
                    Write(1, fillChar, left, top + 1);
                    Console.Write(GetPieceSymbol(col, row));
                    Write(1, fillChar);
                    Write(5, fillChar, left, top + 2);
                }
            Console.WriteLine();
            Console.WriteLine("   A    B    C    D    E    F    G    H");
        }

        private string GetPieceSymbol(char col, int row)
        {
            var position = "" + col + row;
            if (!_pieces.ContainsKey(position) || _pieces[position] == null) return "   ";
            return _pieces[position].Symbol;
        }

        private static void Write(int count, char c, int? left = null, int? top = null)
        {
            if (left != null) Console.CursorLeft = left.Value;
            if (top != null) Console.CursorTop = top.Value;

            Console.Write("".PadLeft(count, c));
        }
    }
}
