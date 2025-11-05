using System;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions
{
    public static bool AllEx<T>(this List<T> list, Func<T, bool> predicate)
    {
        return list.All(predicate);
    }

    public static bool AnyEx<T>(this List<T> list, Func<T, bool> predicate)
    {
        return list.Any(predicate);
    }

    public static bool FindEx<T>(this List<T> list, Func<T, bool> predicate, out T result)
    {
        result = default!;
        foreach (var item in list)
        {
            if (predicate(item))
            {
                result = item;
                return true;
            }
        }
        return false;
    }

    public static List<T> FilterEx<T>(this List<T> list, Func<T, bool> predicate)
    {
        return list.Where(predicate).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine()?.Split().Select(int.Parse).ToList();
        if (input == null)
            return;

        var list = new List<int>(input);

        string line;
        while ((line = Console.ReadLine()) != null)
        {
            Console.WriteLine(line);
            var parts = line.Split();
            var command = parts[0];
            var op = parts[1];
            var argument = int.Parse(parts[2]);

            switch (command)
            {
                case "all":
                    Console.WriteLine(list.AllEx(x => Compare(x, op, argument)));
                    break;
                case "any":
                    Console.WriteLine(list.AnyEx(x => Compare(x, op, argument)));
                    break;
                case "find":
                    if (list.FindEx(x => Compare(x, op, argument), out int result))
                        Console.WriteLine(result);
                    else
                        Console.WriteLine("not found");
                    break;
                case "filter":
                    var filteredList = list.FilterEx(x => Compare(x, op, argument));
                    Console.WriteLine(string.Join(" ", filteredList));
                    break;
            }
        }
    }

    static bool Compare(int value, string op, int argument)
    {
        switch (op)
        {
            case "<": return value < argument;
            case "<=": return value <= argument;
            case ">": return value > argument;
            case ">=": return value >= argument;
            case "==": return value == argument;
            case "!=": return value != argument;
            default: throw new ArgumentException("Invalid operator");
        }
    }
}
