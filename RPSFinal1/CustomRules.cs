// CustomRules.cs
using System;
using System.Collections.Generic;

public class CustomRules : BaseRules
{
    private readonly Dictionary<string, Dictionary<string, string>> outcomes;

    public CustomRules()
    {
        choices = new string[] { "a", "b", "c", "d", "e" };

        outcomes = new Dictionary<string, Dictionary<string, string>>
        {
            { "a", new Dictionary<string, string> { /* Add custom rules for 'a' */ } },
            { "b", new Dictionary<string, string> { /* Add custom rules for 'b' */ } },
            { "c", new Dictionary<string, string> { /* Add custom rules for 'c' */ } },
            { "d", new Dictionary<string, string> { /* Add custom rules for 'd' */ } },
            { "e", new Dictionary<string, string> { /* Add custom rules for 'e' */ } }
        };
    }

    public override bool IsWinner(string playerChoice, string computerChoice)
    {
        string result = outcomes[playerChoice][computerChoice];
        Console.WriteLine(result == "Draw" ? "It's a draw!" : $"{result} wins this round!");

        return result == "Player";
    }
}
