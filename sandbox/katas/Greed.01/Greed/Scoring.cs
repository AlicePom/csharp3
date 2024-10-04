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
    public double EvaluateScore(Player player) // Scoring the game
    {
        Score = 0; // Score is set zero before evaluation starts

        var groupedThrows = player.AllThrows.GroupBy(n => n) // grouping of numbers in the set
                            .Select(g => new { Number = g.Key, Count = g.Count() })
                            .ToList();

        if (groupedThrows.Count == 6) // // Scoring for Straight if there are just 6 groups (6 unique numbers)
        {
            Score += 1200;
            Console.WriteLine("You scored a Straight!");
        }
        else if (groupedThrows.Count == 3 && groupedThrows.All(g => g.Count == 2)) // // Scoring for Three Pairs if there are just 3 groups and within each group just 2 members
        {
            Score += 800;
            Console.WriteLine("You scored Three Pairs!");
        }
        else // Scoring for Three- or More-of-a-Kind & for remaining individual 1s and 5s
        {
            foreach (var group in groupedThrows)
            {
                int coefficient = group.Number == 1 ? 10 : 1; // A coefficient is introduced for number 1 to be evaluated by 10x more points than other numbers

                if (group.Count >= 3) // Scoring for Three- or More-of-a-Kind
                {
                    Score += 100 * group.Number * coefficient * Math.Pow(2, group.Count - 3);
                    Console.WriteLine($"You scored a {group.Count}-of-a-Kind made of {group.Number}!");
                }
                else if (group.Number == 1 || group.Number == 5) // Scoring for any remaining individual 1s and 5s
                {
                    Score += 10 * group.Number * coefficient * group.Count;
                    Console.WriteLine($"You scored {group.Count}x number {group.Number}.");
                }
            }
        }

        return Score;
    }
}
