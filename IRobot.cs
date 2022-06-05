using System.Collections.Generic;

namespace AzMogaTukISega
{
    public interface IRobot
    {
        Queen GetQueen(List<int[]> freeFields, char[,] board);
    }
}
