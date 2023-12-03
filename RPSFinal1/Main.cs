// Program.cs
class Program
{
    static void Main()
    {
        // Instantiate the game with default rules
        IRules defaultRules = new DefaultRules();
        Game gameWithDefaultRules = GameFactory.CreateGame(defaultRules);
        gameWithDefaultRules.Play();

        // If you want to use custom rules:
        IRules customRules = new CustomRules();
        Game gameWithCustomRules = GameFactory.CreateGame(customRules);
        gameWithCustomRules.Play();
    }
}
