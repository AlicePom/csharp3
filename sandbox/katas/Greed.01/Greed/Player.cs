using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Player
{
    private List<int> allThrows = new List<int>();
    public List<int> AllThrows
    {
        get => allThrows;
        set => allThrows = value;
    }
    private Random randomThrow = new Random();

    public List<int> ThrowAllDice() // Generates the random dice throw from 1 to 6
    {
        for (int i = 1; i <= 6; i++) // here we can set the number of throws (i = 6 for the bonus task)
        {
            Console.ReadLine(); // this line should be commented if the Unit test is run!
            int randomNumber = randomThrow.Next(1, 7);
            allThrows.Add(randomNumber);
            Console.Write($"{i}. throw: {randomNumber}");
        }
        Console.WriteLine();

        return allThrows;
    }
}
