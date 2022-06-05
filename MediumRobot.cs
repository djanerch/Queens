using System;
using System.Collections.Generic;
using System.Text;

namespace AzMogaTukISega
{
    public class MediumRobot : IRobot
    {
        public Queen GetQueen(List<int[]> freeFields, char[,] board)
        {
            Random random = new Random();
            int[] cordinates = freeFields[random.Next(0, freeFields.Count)];
            Console.WriteLine($"x: {cordinates[1] + 1}");
            Console.WriteLine($"y: {cordinates[0] + 1}");
            return new Queen(cordinates[0]+1, cordinates[1]+1);
        }
    }
}
