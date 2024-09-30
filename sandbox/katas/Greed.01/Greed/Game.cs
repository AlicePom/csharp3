using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    public Manager manager;
    public Player player;
    public Scoring scoring;

    public Game()
    {
        manager = new Manager();
        player = new Player();
        scoring = new Scoring();
    }

    public void PlayGame() // Plays the game
    {
        // Game introduction
        manager.IntroduceGame();

        // The dice is thrown by the player
        player.ThrowAllDice();

        // Thrown numbers are returned (optional function here)
        manager.ReturnThrownNumbers(player);

        // The score is evaluated and returned
        scoring.EvaluateScore(player);
        manager.ReturnScore(scoring);
    }

    public void RestartGame() /// Restarts/exits the game, clears the Score and the 'allThrows' list
    {
        Console.WriteLine("Would you like to restart the game? To exit the game, please enter 'x' and press Enter. To continue, press Enter.");
        string input = Console.ReadLine();

        if (input.ToLower() == "x")
        {
            Environment.Exit(0);
        }

        manager.ClearAllThrows(player);
        scoring.ResetScore();
        Console.Clear();
    }
}
