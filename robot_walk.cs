using System;
using System.Collections.Generic;

class Program
{
    static double CalculateProbability(char[][] maze)
    {
        int height = maze.Length;
        int width = maze[0].Length;
        List<(int, int)> emptySquares = new List<(int, int)>();
        double[][] probabilities = new double[height][];
        for (int i = 0; i < height; i++)
        {
            probabilities[i] = new double[width];
            for (int j = 0; j < width; j++)
            {
                if (maze[i][j] == '.')
                {
                    emptySquares.Add((j, i));
                }
                else if (maze[i][j] == 'g')
                {
                    probabilities[i][j] = 1;
                }
            }
        }
        List<(int, int)> GetAdjacent(int x, int y)
        {
            var adjacent = new List<(int, int)>();
            if (x > 0)
            {
                adjacent.Add((x - 1, y));
            }
            if (x < width - 1)
            {
                adjacent.Add((x + 1, y));
            }
            if (y > 0)
            {
                adjacent.Add((x, y - 1));
            }
            if (y < height - 1)
            {
                adjacent.Add((x, y + 1));
            }
            return adjacent;
        }
        while (true)
        {
            double maxChange = 0;
            foreach (var (x, y) in emptySquares)
            {
                var adjacent = GetAdjacent(x, y);
                double sum = 0;
                foreach (var (nx, ny) in adjacent)
                {
                    sum += probabilities[ny][nx];
                }
                double newProb = sum / adjacent.Count;
                maxChange = Math.Max(maxChange, Math.Abs(newProb - probabilities[y][x]));
                probabilities[y][x] = newProb;
            }
            if (maxChange < 1e-6)
            {
                break;
            }
        }
        return probabilities[0][0];
    }
    static void Main(string[] args)
    {
        List<string> lines = new List<string>();
        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            lines.Add(line);
        }
        char[][] maze = new char[lines.Count][];
        for (int i = 0; i < lines.Count; i++)
        {
            maze[i] = lines[i].ToCharArray();
        }
        double probability = CalculateProbability(maze);
        Console.WriteLine(probability.ToString("0.000"));
    }
}