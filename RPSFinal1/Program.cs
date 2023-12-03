// IRules.cs
using System;

public interface IRules
{
    bool IsWinner(string playerChoice, string computerChoice);
    bool IsValidChoice(string choice);
    string[] GetChoices();
}

