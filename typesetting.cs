using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class MainClass{
    static string FormatText(string text)
    {
        var words = Regex.Matches(text, @"\b[a-zA-Z]+\b");
        var lines = new List<string>();
        var line = "";
        foreach (Match match in words)
        {
            string word = match.Value;
            if (word.Length > 30)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    lines.Add(line.Trim());
                    line = "";
                }
                lines.Add(word);
            }
            else if (line.Length + word.Length <= 30)
            {
                line += word + " ";
            }
            else
            {
                lines.Add(line.Trim());
                line = word + " ";
            }
        }
        if (!string.IsNullOrEmpty(line))
        {
            lines.Add(line.Trim());
        }
        return string.Join("\n", lines);
    }

    static void Main(string[] args)
    {
        string text = "";
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            text += line + " ";
        }
        if (text.Length > 0)
        {
            text = text.Substring(0, text.Length - 1);
        }
        text = Regex.Replace(text, @"[^a-zA-Z\s]", " ");
        Console.WriteLine(FormatText(text));
    }
}