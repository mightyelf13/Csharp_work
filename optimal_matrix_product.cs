using System;
using System.IO;

class MatrixChainMultiplication
{
    static void MatrixChainOrder(int[] p, out int[,] m, out int[,] s)
    {
        int n = p.Length - 1;
        m = new int[n, n];
        s = new int[n, n];

        for (int length = 2; length <= n; length++)
        {
            for (int i = 0; i < n - length + 1; i++)
            {
                int j = i + length - 1;
                m[i, j] = int.MaxValue;
                for (int k = i; k < j; k++)
                {
                    int q = m[i, k] + m[k + 1, j] + p[i] * p[k + 1] * p[j + 1];
                    if (q < m[i, j])
                    {
                        m[i, j] = q;
                        s[i, j] = k;
                    }
                }
            }
        }
    }

    static void PrintOptimalParenthesization(int[,] s, int i, int j, int[] dimensions)
    {
        if (i == j)
        {
            Console.Write($"A{i + 1}");
        }
        else
        {
            Console.Write("(");
            PrintOptimalParenthesization(s, i, s[i, j], dimensions);
            Console.Write("*");
            PrintOptimalParenthesization(s, s[i, j] + 1, j, dimensions);
            Console.Write(")");
        }
    }

    static void Main()
    {
        string[] lines = File.ReadAllLines("mch.in");
        int n = int.Parse(lines[0]);
        int[] dimensions = new int[n];
        for (int i = 0; i < n; i++)
        {
            dimensions[i] = int.Parse(lines[i + 1]);
        }

        int[,] m, s;
        MatrixChainOrder(dimensions, out m, out s);

        PrintOptimalParenthesization(s, 0, n - 2, dimensions);
        Console.WriteLine();
        Console.WriteLine(m[0, n - 2]);
    }
}
