using System;
using System.Collections.Generic;
using System.Text;

namespace AzMogaTukISega
{
    public class Engine
    {
        //private Singleton1() { }
        //private static Singleton1 instance = null;
        //public static Singleton1 Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new Singleton1();
        //        }
        //        return instance;
        //    }
        //}
        private static Engine instance = null;
        private Engine() { }
        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                    return instance;
                }
                return null;
            }
        }
        public void Run()
        {
            Console.WriteLine(@"Welcome to the Queens
For the past 12 months, Sotir and Gozuma have spent an average of 7 hours a day playing
Isola. The culprits for another wasted year are the races from ''I can - here and
now ”who have developed great programs.Of course, instead of learning, career and light
future, Sotir and Gozuma dream of a new game to kill hundreds of hours more.For them
Fortunately, another wave of talent knocked on the door of ''I can - here and now'' and eagerly
prepares to deliver a new game - ''Queens''.");
            Console.WriteLine();
            Console.WriteLine(@"The queen is a chess piece that can attack another piece at random
horizontal, vertical and diagonal distance. The participants take turns like everyone else
your move participant must place a queen on the board so that she can't attack either
one of the already added queens.
The game loses the participant who is in line, but can not put a queen on the board, so yes
satisfies the above requirement.
Help Sotir and Gozuma replace Isola by writing a program that
allows them to play ''Queens'' against each other.
The initial input for the program are two integers that determine the size of
game board(NxM).
At each turn of your program you expect to get the coordinates of the cell on which the player
I put a queen.");
            Console.WriteLine();

            Console.WriteLine("Choose game type:");
            Console.WriteLine("1.Player vs Robot");
            Console.WriteLine("2.Player vs Player");
            IRobot robot = null;
            int gameType = int.Parse(Console.ReadLine());
            if (gameType == 1)
            {
                while (robot == null)
                {
                    Console.WriteLine("Choose robot difficult type:");
                    Console.WriteLine("Easy");
                    Console.WriteLine("Medium");
                    Console.WriteLine("Hard");
                    string robotType = Console.ReadLine();
                    if (robotType == "Easy")
                        robot = new EasyRobot();
                    else if (robotType == "Medium")
                        robot = new MediumRobot();
                    else if (robotType == "Hard")
                        robot = new HardRobot();
                    else
                        Console.WriteLine("Robot type is invalid");
                }

                int n, m;
                while (true)
                {
                    try
                    {
                        Console.Write("n: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("m: ");
                        m = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Please set new values for n and m that have type integer!!!");
                    }
                }
                Board board = new Board(n, m);
                board.PrintBoard();
                while (true)
                {
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("Player:");
                    int x, y;
                    while (true)
                    {
                        try
                        {
                            Console.Write("x: ");
                            x = int.Parse(Console.ReadLine());
                            Console.Write("y: ");
                            y = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Please set new values for x and y that have type integer!!!");
                        }
                    }
                    Queen queen = new Queen(y, x);
                    board.AddQueen(queen);
                    if (board.IsBoardFull())
                    {
                        Console.WriteLine("Player won!");
                        return;
                    }
                    board.PrintBoard();
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("Robot:");
                    queen = robot.GetQueen(board.GetFreeFields, board.BoardMatrix);
                    board.AddQueen(queen);
                    if (board.IsBoardFull())
                    {
                        Console.WriteLine("Robot won!");
                        return;
                    }
                    board.PrintBoard();
                }
            }

            else if (gameType == 2)
            {
                int n, m;
                while (true)
                {
                    try
                    {
                        Console.Write("n: ");
                        n = int.Parse(Console.ReadLine());
                        Console.Write("m: ");
                        m = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Please set new values for n and m that have type integer!!!");
                    }
                }
                Board board = new Board(n, m);
                board.PrintBoard();
                while (true)
                {
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("Player 1:");
                    int x, y;
                    while (true)
                    {
                        try
                        {
                            Console.Write("x: ");
                            x = int.Parse(Console.ReadLine());
                            Console.Write("y: ");
                            y = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Please set new values for x and y that have type integer!!!");
                        }
                    }
                    Queen queen = new Queen(y, x);
                    board.AddQueen(queen);
                    if (board.IsBoardFull())
                    {
                        Console.WriteLine("Player 1 won!");
                        return;
                    }
                    board.PrintBoard();
                    Console.WriteLine("_____________________________");
                    Console.WriteLine("Player 2:");
                    while (true)
                    {
                        try
                        {
                            Console.Write("x: ");
                            x = int.Parse(Console.ReadLine());
                            Console.Write("y: ");
                            y = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Please set new values for x and y that have type integer!!!");
                        }
                    }
                    queen = new Queen(y, x);
                    board.AddQueen(queen);
                    if (board.IsBoardFull())
                    {
                        Console.WriteLine("Player 2 won!");
                        return;
                    }
                    board.PrintBoard();
                }
            }
        }
    }
}
