using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzMogaTukISega
{
    public class EasyRobot : IRobot
    {
        public Queen GetQueen(List<int[]> freeFields, char[,] board)
        {
            int[] indexes = freeFields[0];
            Console.WriteLine($"x: {indexes[1]+1}");
            Console.WriteLine($"y: {indexes[0]+1}");
            return new Queen(indexes[0]+1, indexes[1]+1);
        }
    }
}
