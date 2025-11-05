using System;
using System.Linq;

class MainClass {
    public static void Main (string[] args) {
        string s = Console.ReadLine();
        string t = Console.ReadLine();

        s = String.Concat(s.OrderBy(c => c));
        t = String.Concat(t.OrderBy(c => c));

        string u = ""; 

        foreach (char c in s) {
            for (int i = 0; i < t.Length; i++) {
                if (t[i] == c) {
                    u += c;
                    t = t.Remove(i, 1);
                    break;
                }
            }
        }
        Console.WriteLine(u);
    }
}
