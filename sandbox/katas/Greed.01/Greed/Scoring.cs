using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Scoring
{
    public Player player;
    public double Score { get; private set; }

    public Scoring()
    {
        player = new Player();
    }
    public void EvaluateScore(Player player) // Scoring the game
    {
        var groupedThrows = player.AllThrows.GroupBy(n => n) // grouping of numbers in the set
                            .Select(g => new { Number = g.Key, Count = g.Count() })
                            .ToList();

        // Scoring for Straight
        if (groupedThrows.Count == 6) // if there are 6 groups (unique numbers)
        {
            Score += 1200;
            Console.WriteLine("You scored a Straight!");
            return; // Terminates the method since no other scoring evaluation is necessary
        }

        // Scoring for Three Pairs
        if (groupedThrows.Count == 3) // if there are 3 distinct numbers in the set
        {
            int pair = 0; //the number of all pairs

            foreach (var group in groupedThrows)
            {
                if (group.Count == 2) // if the count of each group makes a pair
                {
                    pair += 1;
                }
            }

            if (pair == 3) // pair counting => if there are 3 pairs
            {
                Score += 800;
                Console.WriteLine("You scored Three Pairs!");
                return; // Terminates the method since no other scoring evaluation is necessary
            }
        }

        // Scoring for Three- or More-of-a-Kind & for remaining individual 1s and 5s
        foreach (var group in groupedThrows)
        {
            int koeficient = 1; // A koeficient is introduced for number 1 to be evaluated by 10x more points
            if (group.Number == 1)
            {
                koeficient *= 10;
            }

            if (group.Count >= 3) // Scoring for Three- or More-of-a-Kind
            {
                Score += 100 * group.Number * koeficient * Math.Pow(2, group.Count - 3);
                Console.WriteLine($"You scored a {group.Count}-of-a-Kind made of {group.Number}!");
            }

            if (group.Count < 3) // Scoring for remaining individual 1s and 5s
            {
                if (group.Number == 1 || group.Number == 5)
                {
                    Score += 10 * group.Number * koeficient * group.Count;
                    Console.WriteLine($"You scored {group.Count}x number {group.Number}.");
                }
            }
        }
    }

    public void ResetScore() // Reseting the score
    {
        Score = 0;
    }
}
