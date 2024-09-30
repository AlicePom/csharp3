using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    public Player player;
    public Scoring scoring;

    public Game()
    {
        player = new Player();
        scoring = new Scoring();
    }

    public void IntroduceGame() // Introduces the game to the player
    {
        Console.WriteLine("Hello, this is a press-your-luck dice rolling game called 'Greed'. Let's roll the dice 6 times and earn as many points as possible. Press enter to roll the dice!");
    }

    public void ReturnThrownNumbers(Player player) // Writes down all the thrown numbers to the console
    {
        Console.WriteLine();
        Console.WriteLine($"You threw the following numbers: {string.Join(", ", player.AllThrows)}.");
        Console.WriteLine();
    }

    public void RestartGame(Player player, Scoring scoring) // Restarts the game, cleans the console and allThrows List, and resets the Score
    {
        Console.WriteLine("Would you like to restart the game? To continue, press Enter. To exit the game, please enter 'x' and press Enter.");
        string input = Console.ReadLine();

        if (input.ToLower() == "x")
        {
            Environment.Exit(0);
        }

        player.ClearAllThrows();
        scoring.ResetScore();
        Console.Clear();
    }
}
