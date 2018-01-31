using System;

public static class Dice
{
    private static readonly Random rand = new Random();
    private static readonly object randLock = new object();

    public static int Roll(uint diceCount)
    {
        int total = 0;
        for (uint i = 0; i < diceCount; i++)
        {
            lock (randLock)
            {
                total += rand.Next(5) + 1;
            }
        }
        return total;
    }
}
