using System;
using System.Linq;
using System.Collections.Generic;

namespace JordanNohle
{
    public class JordanNohle
    {
        private static readonly HashSet<string> _patterns;
        private static readonly string[,] _board;
        private static readonly HashSet<string> _vowels;

        static JordanNohle()
        {
            _patterns = new HashSet<string>();
            _board = new string[5, 5] { 
                { "a", "b", "c", "0", "e" }, 
                { "0", "g", "h", "i", "j" },
                {"k","l","m","n","o" },
                {"p","q","r","s","t" },
                {"u", "v","0","0","y" }
            };
            _vowels = new HashSet<string>
            {

                "a","e","i","o","u","y"
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SolveMatrix());
            //var patterns = _patterns.ToList();
            //patterns.Sort();
            //foreach (var pattern in patterns) Console.WriteLine(pattern);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        

        public static long SolveMatrix()
        {
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    if (_board[x, y].Equals("0")) continue;
                    KnightMove(x, y, 0, string.Empty);
                }
            }

            return _patterns.Count;
        }

        private static string KnightMove(int xCoord, int yCoord, int vowelCount, string currentPattern)
        {
            if (currentPattern.Length == 8)
            {
                if (!_patterns.Contains(currentPattern)) _patterns.Add(currentPattern);
                return currentPattern;
            }
            if (IsValidMove(xCoord - 2, yCoord - 1, vowelCount, currentPattern))
                KnightMove(xCoord - 2, yCoord - 1, _vowels.Contains(_board[xCoord - 2, yCoord - 1]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord - 2, yCoord -1]);
            if (IsValidMove(xCoord + 2, yCoord - 1, vowelCount, currentPattern))
                KnightMove(xCoord + 2, yCoord - 1, _vowels.Contains(_board[xCoord + 2, yCoord - 1]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord + 2, yCoord - 1]);
            if (IsValidMove(xCoord - 2, yCoord + 1, vowelCount, currentPattern))
                KnightMove(xCoord - 2, yCoord + 1, _vowels.Contains(_board[xCoord - 2, yCoord + 1]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord - 2, yCoord + 1]);
            if (IsValidMove(xCoord + 2, yCoord + 1, vowelCount, currentPattern))
                KnightMove(xCoord + 2, yCoord + 1, _vowels.Contains(_board[xCoord + 2, yCoord + 1]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord + 2, yCoord + 1]);
            if (IsValidMove(xCoord - 1, yCoord - 2, vowelCount, currentPattern))
                KnightMove(xCoord - 1, yCoord - 2, _vowels.Contains(_board[xCoord - 1, yCoord - 2]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord - 1, yCoord - 2]);
            if (IsValidMove(xCoord + 1, yCoord - 2, vowelCount, currentPattern))
                KnightMove(xCoord + 1, yCoord - 2, _vowels.Contains(_board[xCoord + 1, yCoord - 2]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord + 1, yCoord - 2]);
            if (IsValidMove(xCoord - 1, yCoord + 2, vowelCount, currentPattern))
                KnightMove(xCoord - 1, yCoord + 2, _vowels.Contains(_board[xCoord - 1, yCoord + 2]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord - 1, yCoord + 2]);
            if (IsValidMove(xCoord + 1, yCoord + 2, vowelCount, currentPattern))
                KnightMove(xCoord + 1, yCoord + 2, _vowels.Contains(_board[xCoord + 1, yCoord + 2]) ? vowelCount + 1 : vowelCount, currentPattern + _board[xCoord + 1, yCoord + 2]);

            return currentPattern;
        }

        private static bool IsValidMove(int xCoord, int yCoord, int vowelCount, string currentPattern)
        {
            return 
                (xCoord >= 0 && xCoord < 5) &&
                (yCoord >= 0 && yCoord < 5) && 
                currentPattern.Length <= 8 &&
                !_board[xCoord, yCoord].Equals("0") &&
                !(vowelCount == 2 && _vowels.Contains(_board[xCoord, yCoord])) &&
                !(currentPattern.Length == 7 && _patterns.Contains(currentPattern + _board[xCoord, yCoord]));
        }
    }
}
