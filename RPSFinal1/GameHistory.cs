// GameHistory.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GameHistory
{
    private List<string> history;

    public GameHistory()
    {
        history = new List<string>();
    }

    public void AddResult(string result)
    {
        history.Add(result);
    }

    public void SaveToFile(string filePath)
    {
        File.WriteAllLines(filePath, history);
    }

    public void DisplayHistory()
    {
        if (history.Count > 0)
        {
            Console.WriteLine("\nGame History:");
            Console.WriteLine(string.Join("\n", history));
            Console.WriteLine();
        }
    }
}
