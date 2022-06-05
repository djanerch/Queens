using System;
using System.Collections.Generic;
using System.Text;

namespace AzMogaTukISega
{
    public class HardRobot:IRobot
    {
        public Queen GetQueen(List<int[]> freeFields)
        {
            return null;
        }

        public Queen GetQueen(List<int[]> freeFields, char[,] board)
        {
            Queen queen = null;
            int bestSolution = -1;
            foreach (int[] cordinates in freeFields)
            {
                int countOfKilledField = CountAttackedFields(cordinates[1], cordinates[0], board);
                if (countOfKilledField > bestSolution)
                {
                    bestSolution = countOfKilledField;
                    queen = new Queen(cordinates[0]+1, cordinates[1]+1);
                }
            }

            Console.WriteLine($"x: {queen.getX() + 1}");
            Console.WriteLine($"y: {queen.getY() + 1}");
            return queen;
        }

        private int CountAttackedFields(int x, int y, char[,] board)
        {
            int count = 0;
            count += AttackingFieldsRight(x, y, board);
            count += AttackingFieldsLeft(x, y, board);
            count += AttackingFieldsUp(x, y, board);
            count += AttackingFieldsDown(x, y, board);
            count += AttackingFieldsUpLeft(x, y, board);
            count += AttackingFieldsUpRight(x, y, board);
            count += AttackingFieldsDownLeft(x, y, board);
            count += AttackingFieldsDownRight(x, y, board);
            return count;
        }

        private int AttackingFieldsRight(int x, int y, char[,] board)
        {
            int count = 0;
            for (x = x + 1; x < board.GetLength(1); x++)
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
            }
            return count;
        }
        private int AttackingFieldsLeft(int x, int y, char[,] board)
        {
            int count = 0;
            for (x = x - 1; x >= 0; x--)
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
            }
            return count;
        }
        private int AttackingFieldsDown(int x, int y, char[,] board)
        {

            int count = 0;
            for (y = y + 1; y < board.GetLength(0); y++)
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
            }
            return count;
        }
        private int AttackingFieldsUp(int x, int y, char[,] board)
        {
            int count = 0;
            for (y = y - 1; y >= 0; y--)
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
            }
            return count;
        }
        private int AttackingFieldsUpRight(int x, int y, char[,] board)
        {
            int count = 0;
            x = x + 1;
            y = y - 1;
            while (x >= 0 && x < board.GetLength(1) && y >= 0 && y < board.GetLength(0))
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
                x++;
                y--;
            }
            return count;
        }

        private int AttackingFieldsUpLeft(int x, int y, char[,] board)
        {
            int count = 0;
            x = x - 1;
            y = y - 1;
            while (x >= 0 && x < board.GetLength(1) && y >= 0 && y < board.GetLength(0))
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
                x--;
                y--;
            }
            return count;
        }

        private int AttackingFieldsDownRight(int x, int y, char[,] board)
        {
            int count = 0;
            x = x + 1;
            y = y + 1;
            while (x >= 0 && x < board.GetLength(1) && y >= 0 && y < board.GetLength(0))
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
                x++;
                y++;
            }
            return count;
        }
        private int AttackingFieldsDownLeft(int x, int y, char[,] board)
        {
            int count = 0;
            x = x - 1;
            y = y + 1;
            while (x >= 0 && x < board.GetLength(1) && y >= 0 && y < board.GetLength(0))
            {
                if (board[y, x] == ' ')
                {
                    count++;
                }
                x--;
                y++;
            }
            return count;
        }
    }
}
