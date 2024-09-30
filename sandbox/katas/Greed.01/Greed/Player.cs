using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Player
{
    private List<int> allThrows = new List<int>(); // shall I make it private???
    public List<int> AllThrows => allThrows;
    private Random randomThrow = new Random();

    public void ThrowAllDice() // Generates the random dice throw from 1 to 6
    {
        for (int i = 1; i <= 6; i++) // here we can set the number of throws (i = 6 for the bonus task)
        {
            Console.ReadLine();
            Console.Write($"{i}. throw: ");
            int randomNumber = randomThrow.Next(1, 7);
            allThrows.Add(randomNumber);
            Console.Write(randomNumber);
        }
        Console.WriteLine();
    }
}
