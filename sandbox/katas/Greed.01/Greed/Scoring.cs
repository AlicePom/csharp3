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
        // Scoring for a Straight - 1, 2, 3, 4, 5, 6
        player.AllThrows.Sort(); // sorting the thrown numbers
        List<int> straight = new List<int>() { 1, 2, 3, 4, 5, 6 };

        if (player.AllThrows.SequenceEqual(straight))
        {
            Score += 1200;
            Console.WriteLine("You scored a Straight!");
            return; // Terminates the method since no other scoring evaluation is necessary
        }

        // Scoring of Three Pairs
        var groupedThrows = player.AllThrows.GroupBy(n => n) // grouping of numbers in the set
                            .Select(g => new { Number = g.Key, Count = g.Count() })
                            .ToList();

        if (groupedThrows.Count == 3) // if there are 3 distinct numbers in the set
        {
            int pair = 0;

            foreach (var group in groupedThrows)
            {
                if (group.Count == 2) // if the count of each group makes a pare
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
        for (int i = 1; i <= 6; i++) // evaluation of count of individual number from 1 to 6
        {
            // Counting the number of i
            int countI = player.AllThrows.Count(n => n == i);

            // A koeficient is introduced for i == 1 to be evaluated by 10x more points
            int koeficientI = 1;
            if (i == 1)
            {
                koeficientI *= 10;
            }

            // Scoring
            int extraCount = countI - 3; // extraCount is a utility number that expresses extra multiples (More-of-a-Kind) above 3
            if (extraCount >= 0)
            {
                Score += (100 * i * koeficientI) * Math.Pow(2, extraCount);
                Console.WriteLine($"You scored a {countI}-of-a-Kind made of {i}!");

                // removing the numbers counted for scoring from the allThrows list for further possible scoring (e.g., other triples,
                for (int j = 1; j <= countI; j++)
                {
                    player.AllThrows.Remove(i);
                }

                // re-counting individual number i count after removal of the possible matches above
                countI = player.AllThrows.Count(n => n == i);
            }

            // Scoring each individual 1 or 5 that remained in the set after all previous Three- or More-of-a-Kind scorings
            if (i == 1 && countI > 0)
            {
                Score += 100 * countI;
                Console.WriteLine($"You scored {countI}x number 1.");
            }

            if (i == 5 && countI > 0)
            {
                Score += 50 * countI;
                Console.WriteLine($"You scored {countI}x number 5.");
            }
        }
    }

    public void ReturnScore() // Returning the score
    {
        Console.WriteLine();
        Console.WriteLine($"Your score is {Score} points!");
        Console.WriteLine();
    }

    public void ResetScore() // Reseting the score
    {
        Score = 0;
    }
}
