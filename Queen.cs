using System;
using System.Collections.Generic;
using System.Text;

namespace AzMogaTukISega
{
    public class Queen
    {
        int x;
        int y;
        public Queen(int y, int x)
        {
            setX(x);
            setY(y);
        }

        private void setX(int x)
        {
            while (x < 1 || x > Board.GetN)
            {
                Console.WriteLine($"Please set value for x in range[1-{Board.GetN}]");
                while (true)
                {
                    try
                    {
                        x = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Please set new value for x that have type integer!!!");
                    }
                }
            }
            this.x = x-1;
        }
        private void setY(int y)
        {
            while (y < 1 || y > Board.GetM)
            {
                Console.WriteLine($"Please set value  for y in range[1-{Board.GetM}]");
                while (true)
                {
                    try
                    {
                        y = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Please set new value for y that have type integer!!!");
                    }
                }
            }
            this.y = y-1;
        }

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }
}
