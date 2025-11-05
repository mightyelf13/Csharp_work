# Csharp_work
Beginner level work

This repository contains standalone C# console programs that implement classic algorithmic, data-structure, and math problems.  
Each file has its own `Main()` method and can be run independently.

---

## Program Overview

| File | Category | Description |
|------|---------|-------------|
| `sum_of_two_intgers.cs` | Basic I/O | Reads two integers and prints their sum. |
| `number_wheel.cs` | Basic I/O | Same behavior as `sum_of_two_intgers.cs`. |
| `common_permutation.cs` | Strings | Finds common characters between two strings (multiset intersection). |
| `typesetting.cs` | Text formatting | Removes non-letters and wraps text into lines up to 30 characters. |
| `rectangle_class.cs` | Geometry | Rectangle class with area, perimeter, overlap, containment, and intersection. |
| `hands_of_cards.cs` | Simulation / Games | Compares poker-style card hands by matching frequency (4-kind, 3-kind, pair, high card). |
| `matrix_expression.cs` | Matrices / Parsing | Matrix class with `+`, `-`, `*`; evaluates postfix expression over matrices and prints result. |
| `robot_walk.cs` | Probability / DP | Computes probability of reaching a goal in a grid using iterative averaging. |
| `dragon's_den.cs` | LINQ / Collections | Implements custom `All`, `Any`, `Find`, `Filter` list extension methods and processes commands. |
| `optimal_matrix_product.cs` | Dynamic Programming | Classic matrix chain multiplication: prints optimal parenthesization and minimum cost. |

---

## Key Concepts Covered

- Basic input/output
- String processing and filtering
- Text formatting
- 2D geometry and rectangle operations
- Card-hand ranking logic
- Matrix operations and expression evaluation
- Probabilistic grid computation
- Custom LINQ extension methods
- Dynamic programming (matrix chain multiplication)

---

## Running Programs

### Compile and run with C# compiler

```bash
csc filename.cs
./filename
Or run using dotnet-script:
bash
Copy code
dotnet script filename.cs
