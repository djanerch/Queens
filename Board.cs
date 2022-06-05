using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzMogaTukISega
{
    public class Board
    {
        private static int n = 0;
        private static int m = 0;
        char[,] board;
        List<int[]> freeFields;

        public Board(int n, int m)
        {
            setN(n);
            setM(m);
            initializeBoard();
        }
        public static int GetN { get => Board.n; }
        public static int GetM { get => Board.m; }
        public List<int[]> GetFreeFields{ get => this.freeFields; }
        public char[,] BoardMatrix { get=>board; }
        private void setN(int n)
        {
            while (n < 3 || n > 100)
            {
                Console.WriteLine("Please set new value for n! N must be an integer in interval 3-100!");
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                }
            }
            Board.n = n;
        }
        private void setM(int m)
        {
            while (m < 3 || m > 100)
            {
                Console.WriteLine("Please set new value for m! M must be an integer in interval 3-100!");
                try
                {
                    m = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                }
            }
            Board.m = m;
        }

        public void PrintBoard()
        {
            Console.Write("   ");
            for (int i = 1; i <= m; i++) Console.Write($"[{i}]");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"[{i+1}]");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"[{board[i, j]}]");
                }
                Console.WriteLine();
            }
        }
        private void DrawQueenAttackingFieldsRight(Queen queen)
        {
            int y = queen.getY();
            for (int x = queen.getX() + 1; x < board.GetLength(1); x++)
            {
                board[y,x] = '*';
                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
            }
        }
        private void DrawQueenAttackingFieldsLeft(Queen queen)
        {
            int y = queen.getY();
            for (int x = queen.getX() - 1; x >= 0; x--)
            {
                board[y,x] = '*';
                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
            }
        }
        private void DrawQueenAttackingFieldsDown(Queen queen)
        {
            int x = queen.getX();
            for (int y = queen.getY() + 1; y < board.GetLength(0); y++)
            {
                board[y,x] = '*';
                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
            }
        }
        private void DrawQueenAttackingFieldsUp(Queen queen)
        {
            int x = queen.getX();
            for (int y = queen.getY() - 1; y >= 0; y--)
            {
                board[y,x] = '*';
                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
            }
        }
        private void DrawQueenAttackingFieldsDownLeft(Queen queen)
        {
            int x = queen.getX() - 1;
            int y = queen.getY() + 1;
            while (x >= 0 && x < m && y >= 0 && y < n)
            {
                board[y,x] = '*';
                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
                x--;
                y++;
            }
        }

        private void DrawQueenAttackingFieldsUpLeft(Queen queen)
        {
            int x = queen.getX() - 1;
            int y = queen.getY() - 1;
            while (x >= 0 && x < m && y >= 0 && y < n)
            {
                board[y,x] = '*';

                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
                x--;
                y--;
            }
        }

        private void DrawQueenAttackingFieldsDownRight(Queen queen)
        {
            int x = queen.getX() + 1;
            int y = queen.getY() + 1;
            while (x >= 0 && x < m && y >= 0 && y < n)
            {
                board[y,x] = '*';

                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
                x++;
                y++;
            }
        }
        private void DrawQueenAttackingFieldsUpRight(Queen queen)
        {
            int x = queen.getX() + 1;
            int y = queen.getY() - 1;
            while (x >= 0 && x < m && y >= 0 && y < n)
            {
                board[y,x] = '*';

                freeFields.Remove(freeFields.FirstOrDefault(c => c[1] == x && c[0] == y));
                x++;
                y--;
            }
        }
        public void AddQueen(Queen queen)
        {
            while (board[queen.getY(), queen.getX()] != ' ')
            {
                Console.WriteLine("Please set new queen position!");
                this.printFreeFields();
                while (true)
                {
                    try
                    {
                        Console.Write("x: ");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("y: ");
                        int y = int.Parse(Console.ReadLine());
                        queen = new Queen(y,x);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid type of cordinates!!!");
                    }
                }
            }

            this.board[queen.getY(), queen.getX()] = 'Q';
            freeFields.Remove(freeFields.FirstOrDefault(c => c[0] == queen.getY() && c[1] == queen.getX())); this.DrawQueenAttackingFieldsDown(queen);
            this.DrawQueenAttackingFieldsUp(queen);
            this.DrawQueenAttackingFieldsRight(queen);
            this.DrawQueenAttackingFieldsLeft(queen);
            this.DrawQueenAttackingFieldsDownLeft(queen);
            this.DrawQueenAttackingFieldsDownRight(queen);
            this.DrawQueenAttackingFieldsUpRight(queen);
            this.DrawQueenAttackingFieldsUpLeft(queen);
        }

        public bool isBoardFull()
        {
            return freeFields.Count == 0;
        }

        private void printFreeFields()
        {
            Console.WriteLine("Free fields left are with coridnates!");
            foreach (int[] field in freeFields)
            {
                Console.WriteLine($"x: {field[1] + 1} y: {field[0] + 1}");
            }
        }
        private void initializeBoard()
        {
            freeFields = new List<int[]>();
            board = new char[Board.GetN,Board.GetM];
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    board[y,x] = ' ';
                    freeFields.Add(new int[2] { y,x });
                }
            }
        }
    }
}
