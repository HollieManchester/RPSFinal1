// DefaultRules.cs
using System;
using System.Collections.Generic;

public class DefaultRules : BaseRules
{
    private readonly Dictionary<string, Dictionary<string, string>> outcomes;

    public DefaultRules()
    {
        choices = new string[] { "rock", "paper", "scissors", "lizard", "spock" };

        outcomes = new Dictionary<string, Dictionary<string, string>>
        {
            { "rock", new Dictionary<string, string> { { "rock", "Draw" }, { "paper", "Computer" }, { "scissors", "Player" }, { "lizard", "Player" }, { "spock", "Computer" } } },
            { "paper", new Dictionary<string, string> { { "rock", "Player" }, { "paper", "Draw" }, { "scissors", "Computer" }, { "lizard", "Computer" }, { "spock", "Player" } } },
            { "scissors", new Dictionary<string, string> { { "rock", "Computer" }, { "paper", "Player" }, { "scissors", "Draw" }, { "lizard", "Player" }, { "spock", "Computer" } } },
            { "lizard", new Dictionary<string, string> { { "rock", "Computer" }, { "paper", "Player" }, { "scissors", "Computer" }, { "lizard", "Draw" }, { "spock", "Player" } } },
            { "spock", new Dictionary<string, string> { { "rock", "Player" }, { "paper", "Computer" }, { "scissors", "Player" }, { "lizard", "Computer" }, { "spock", "Draw" } } }
        };
    }

    public override bool IsWinner(string playerChoice, string computerChoice)
    {
        string result = outcomes[playerChoice][computerChoice];
        Console.WriteLine(result == "Draw" ? "It's a draw!" : $"{result} wins this round!");

        return result == "Player";
    }
}
