using System;

class MainClass {
    public static void Main (string[] args) {
        int N = int.Parse(Console.ReadLine());
        int denominator = (N + 1) * (N + 1) * (N + 1); 
            int numerator = 0;         
        for (int i = 0; i <= N; i++) {
            for (int j = 0; j <= N; j++) {
                for (int k = 0; k <= N; k++) {
                    if ((i + j + k) % 10 == 0) {
                        numerator++; 
                    }
                }
            }
        }        
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
        
        Console.WriteLine($"{numerator}/{denominator}");
    }
    static int GCD(int num1, int num2)
    {
        int Remainder;
 
        while (num2 != 0)
        {
            Remainder = num1 % num2;
            num1 = num2;
            num2 = Remainder;
        }
 
        return num1;
    }
}