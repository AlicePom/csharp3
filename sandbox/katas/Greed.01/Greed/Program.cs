// Initializing classes
Game game = new Game();
Player player = new Player();
Scoring scoring = new Scoring();

// Playing the game
while (true)
{
    // Introducing the game
    game.IntroduceGame();

    // Throwing the dice by the player
    player.ThrowAllDice();

    // Returning thrown numbers (optional function here)
    player.ReturnThrownNumbers();

    // Scoring - evaluating and returning the score
    scoring.EvaluateScore(player);
    scoring.ReturnScore();

    // Restarting the game
    game.RestartGame(player, scoring);
}
