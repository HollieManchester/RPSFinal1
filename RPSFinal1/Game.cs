// Game.cs
using System;
using System.Collections.Generic;

public class Game
{
    private readonly IRules rules;
    private readonly Random random;
    private int playerScore;
    private int computerScore;
    private readonly int roundsToWin;
    private readonly GameHistory gameHistory;
    private Dictionary<string, int> playerChoiceFrequency = new Dictionary<string, int>();
    private string playerName;
    private readonly string computerName = "Computer";

    public Game(IRules rules, int roundsToWin = 3)
    {
        this.rules = rules;
        this.roundsToWin = roundsToWin;
        random = new Random();
        gameHistory = new GameHistory();
    }

    public void Play()
    {
        string[] choices = rules.GetChoices();

        Console.WriteLine("================================");
        Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!");
        Console.WriteLine("================================");

        Console.WriteLine("Enter your name:");
        playerName = Console.ReadLine();

        while (playerScore < roundsToWin && computerScore < roundsToWin)
        {
            playerChoiceFrequency.Clear();

            gameHistory.DisplayHistory();

            string computerChoice = GetComputerChoice(choices);

            Console.WriteLine($"\n{playerName}, choose your weapon: ({string.Join(", ", choices)})");
            string playerChoice = Console.ReadLine().ToLower();

            if (!rules.IsValidChoice(playerChoice))
            {
                Console.WriteLine("Invalid choice. Please choose from the available options.");
                continue;
            }

            Console.WriteLine($"{computerName} chose: {computerChoice}");

            bool playerWinsRound = rules.IsWinner(playerChoice, computerChoice);
            Console.WriteLine(playerWinsRound ? $"{playerName} wins this round!" : $"{computerName} wins this round!");

            gameHistory.AddResult(playerWinsRound
                ? $"{playerName} chose {playerChoice}, {computerName} chose {computerChoice}. {playerName} wins!"
                : $"{playerName} chose {playerChoice}, {computerName} chose {computerChoice}. {computerName} wins.");

            UpdatePlayerChoiceFrequency(playerChoice);

            if (playerWinsRound) playerScore++;
            else computerScore++;

            Console.WriteLine($"{playerName}: {playerScore} - {computerName}: {computerScore}");

            if (playerScore >= roundsToWin || computerScore >= roundsToWin)
            {
                break;
            }

            Console.WriteLine("\nDo you want to stick (s) or twist (t)?");
            string stickOrTwist = Console.ReadLine().ToLower();

            if (stickOrTwist == "s" && playerScore >= roundsToWin)
            {
                break;
            }
        }

        gameHistory.SaveToFile("game_history.txt");

        AnalysePlayerStrategy();

        gameHistory.DisplayHistory();

        Console.WriteLine(playerScore > computerScore
            ? $"\nCongratulations, {playerName}! You win the game!"
            : $"\n{computerName} wins the game. Better luck next time!");

        Console.WriteLine("\nThanks for playing!");
    }

    private string GetComputerChoice(string[] choices)
    {
        string mostFrequentChoice;

        if (playerChoiceFrequency.Any())
        {
            mostFrequentChoice = playerChoiceFrequency.OrderByDescending(pair => pair.Value).First().Key;
        }
        else
        {
            mostFrequentChoice = choices[random.Next(choices.Length)];
        }

        int randomIndex = random.Next(choices.Length);
        string computerChoice = choices[randomIndex];

        return computerChoice;
    }

    private void UpdatePlayerChoiceFrequency(string playerChoice)
    {
        if (playerChoiceFrequency.ContainsKey(playerChoice))
        {
            playerChoiceFrequency[playerChoice]++;
        }
        else
        {
            playerChoiceFrequency[playerChoice] = 1;
        }
    }

    private void AnalysePlayerStrategy()
    {
        Console.WriteLine("\nPlayer's Strategy Analysis:");

        foreach (var pair in playerChoiceFrequency.OrderByDescending(pair => pair.Value))
        {
            Console.WriteLine($"Choice: {pair.Key}, Frequency: {pair.Value}");
        }
    }
}
