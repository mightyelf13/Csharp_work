using System;
using System.Collections.Generic;
using static System.Console;

class Matrix {
    int size;
    int[,] a;

    public Matrix(int n) {
        size = n;
        a = new int[n, n];
    }

    public void read() {
    for (int i = 0; i < size; ++i) {
        string line;
        do {
            line = ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(line)); // Keep reading until a non-empty line is encountered

        string[] words = line.Split(null);
        if (words.Length != size) {
            WriteLine("bad input");
            return;
        }
        for (int j = 0; j < size; ++j)
            a[i, j] = int.Parse(words[j]);
    }
}



    public void print() {
        for (int i = 0 ; i < size ; ++i) {
            for (int j = 0 ; j < size ; ++j)
                Write($"{a[i, j]} ");
            WriteLine();
        }
    }

    public static Matrix operator +(Matrix m1, Matrix m2) {
        if (m1.size != m2.size)
            throw new ArgumentException("Matrix dimensions don't match");
        
        int n = m1.size;
        Matrix result = new Matrix(n);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                result.a[i, j] = m1.a[i, j] + m2.a[i, j];
            }
        }
        return result;
    }

    public static Matrix operator -(Matrix m1, Matrix m2) {
        if (m1.size != m2.size)
            throw new ArgumentException("Matrix dimensions don't match");
        
        int n = m1.size;
        Matrix result = new Matrix(n);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                result.a[i, j] = m1.a[i, j] - m2.a[i, j];
            }
        }
        return result;
    }

    public static Matrix operator *(Matrix m1, Matrix m2) {
        if (m1.size != m2.size)
            throw new ArgumentException("Matrix dimensions don't match");
        
        int n = m1.size;
        Matrix result = new Matrix(n);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    result.a[i, j] += m1.a[i, k] * m2.a[k, j];
                }
            }
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        string[] input = ReadLine()?.Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);

        Matrix[] matrices = new Matrix[M];
        for (int i = 0; i < M; i++) {
            matrices[i] = new Matrix(N);
            matrices[i].read();
            string nextLine = ReadLine()?.Trim();
            if (nextLine != null && (nextLine.EndsWith("+") || nextLine.EndsWith("-") || nextLine.EndsWith("*"))) {
                M = i + 1; // Stop further input reading
                break;
            }
        }

        string[] expression = ReadLine()?.Split();
        Stack<Matrix> stack = new Stack<Matrix>();

        foreach (string token in expression) {
            if (int.TryParse(token, out int matrixIndex)) {
                stack.Push(matrices[matrixIndex - 1]);
            } else {
                Matrix op2 = stack.Pop();
                Matrix op1 = stack.Pop();
                switch (token) {
                    case "+":
                        stack.Push(op1 + op2);
                        break;
                    case "-":
                        stack.Push(op1 - op2);
                        break;
                    case "*":
                        stack.Push(op1 * op2);
                        break;
                }
            }
        }

        Matrix result = stack.Pop();
        result.print();
    }
}