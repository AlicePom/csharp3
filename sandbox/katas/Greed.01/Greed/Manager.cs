using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Manager
{
    public Player player;
    public Scoring scoring;

    public Manager()
    {
        player = new Player();
        scoring = new Scoring();
    }

    public void IntroduceGame() // Introduces the game to the player
    {
        Console.WriteLine("Hello, this is a press-your-luck dice rolling game called 'Greed'. Let's roll the dice 6 times and earn as many points as possible. Press Enter to roll the dice!");
    }

    public void ReturnThrownNumbers(Player player) // writes down all the thrown numbers to the console (optional)
    {
        Console.WriteLine();
        Console.WriteLine($"You threw the following numbers: {string.Join(", ", player.AllThrows)}.");
        Console.WriteLine();
    }

    public void ReturnScore(Scoring scoring) // Returning the score
    {
        Console.WriteLine();
        Console.WriteLine($"Your score is {scoring.Score} points!");
        Console.WriteLine();
    }

    public void ClearAllThrows(Player player) // clears the allThrows List before the next game starts
    {
        player.AllThrows.Clear();
    }
}
