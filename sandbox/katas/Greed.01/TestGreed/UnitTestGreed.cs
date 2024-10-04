namespace TestGreed;

public class UnitTest1
{
    public Scoring scoring;
    public Player player;
    public Manager manager;

    public UnitTest1()
    {
        scoring = new Scoring();
        player = new Player();
        manager = new Manager();
    }

    [Fact]
    public void TestEvaluateScore_Straight()
    {
        player.AllThrows = new List<int>() { 1, 2, 3, 4, 5, 6, };
        double result = scoring.EvaluateScore(player);
        Assert.Equal(1200, result);
    }

    [Fact]
    public void TestEvaluateScore_Three_Pairs()
    {
        // 3 pairs comprising 1s and 5s (testing that they are not evaluated here as single 1s and 5s as well)
        player.AllThrows = new List<int>() { 1, 1, 3, 3, 5, 5, };
        double result = scoring.EvaluateScore(player);
        Assert.Equal(800, result);

        scoring = new Scoring();

        // 3 pairs without 1s and 5s
        player.AllThrows = new List<int>() { 2, 2, 4, 4, 6, 6, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(800, result);
    }

    [Fact]
    public void TestEvaluateScore_Three_of_A_Kind()
    {
        // 3* number 1 (coefficient = 10)
        player.AllThrows = new List<int>() { 1, 1, 1, 2, 3, 4, };
        double result = scoring.EvaluateScore(player);
        Assert.Equal(1000, result);

        scoring = new Scoring();

        // 3* number 3 (coefficient = 1)
        player.AllThrows = new List<int>() { 3, 3, 3, 2, 4, 6, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(300, result);

        scoring = new Scoring();

        // 3* number 4 & 3* number 5 (two three-of-a-kind, both with coefficient = 1)
        player.AllThrows = new List<int>() { 4, 4, 4, 5, 5, 5, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(900, result);
    }

    [Fact]
    public void TestEvaluateScore_More_of_A_Kind()
    {
        // 4* number 1 (coefficient = 10)
        player.AllThrows = new List<int>() { 1, 1, 1, 1, 3, 4, };
        double result = scoring.EvaluateScore(player);
        Assert.Equal(2000, result);

        scoring = new Scoring();

        // 5* number 2 (coefficient = 1)
        player.AllThrows = new List<int>() { 2, 2, 2, 2, 2, 3, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(800, result);

        scoring = new Scoring();

        // 6* number 6 (coefficient = 1)
        player.AllThrows = new List<int>() { 6, 6, 6, 6, 6, 6, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(4800, result);
    }

    [Fact]
    public void TestEvaluateScore_1s_5s_More_of_A_Kind()
    {
        // 1* number 1, 1* number 5 (evaluates 1s and 5s individually)
        player.AllThrows = new List<int>() { 1, 5, 2, 3, 3, 4, };
        double result = scoring.EvaluateScore(player);
        Assert.Equal(150, result);

        scoring = new Scoring();

        // 2* number 1, 2* number 5 (scoring is multiplied for 1s and 5s)
        player.AllThrows = new List<int>() { 1, 1, 5, 5, 3, 4, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(300, result);

        scoring = new Scoring();

        // 3* number 6, 2* number 1, 1* number 5 (evaluates three-of-a-kind as well as individual 1s and 5s)
        player.AllThrows = new List<int>() { 6, 6, 6, 1, 1, 5, };
        result = scoring.EvaluateScore(player);
        Assert.Equal(850, result);
    }

    [Fact]
    public void TestEvaluateScore_No_points()
    {
        player.AllThrows = new List<int>() { 2, 3, 3, 4, 4, 6, };
        double result = scoring.EvaluateScore(player);
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestClearAllThrows()
    {
        player.AllThrows = new List<int>() { 2, 3, 3, 4, 4, 6, };
        manager.ClearAllThrows(player);
        bool allThrowsListEmpty = player.AllThrows.Count == 0;
        Assert.True(allThrowsListEmpty);
    }

    [Fact]
    public void TestThrowAllDice()
    {
        /* IMPORTANT!
         * For the purpose of this test, it is necessary to comment the "Console.ReadLine();" command in the player.ThrowAllDice() method
         */
        player.AllThrows = new List<int>();
        player.ThrowAllDice();

        // exactly 6 numbers are obtained
        int numberOfThrows = player.AllThrows.Count();
        Assert.Equal(6, numberOfThrows);

        // all the 6 numbers are within the 1-6 range
        bool allNumbersWithinRange = player.AllThrows.All(n => (n >= 1 && n <= 6));
        Assert.True(allNumbersWithinRange);
    }
}
