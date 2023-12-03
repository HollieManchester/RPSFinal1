// GameFactory.cs
public class GameFactory
{
    public static Game CreateGame(IRules rules, int roundsToWin = 3)
    {
        return new Game(rules, roundsToWin);
    }
}
