// BaseRules.cs
using System;
using System.Linq;

public abstract class BaseRules : IRules
{
    protected string[] choices;

    public abstract bool IsWinner(string playerChoice, string computerChoice);

    public bool IsValidChoice(string choice)
    {
        return choices.Contains(choice);
    }

    public string[] GetChoices()
    {
        return choices.OrderBy(choice => choice).ToArray();
    }
}
