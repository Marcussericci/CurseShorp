using System;


interface IOperation
{
    double Execute(double a, double b);
    string Name { get; }
}


abstract class Operation : IOperation
{
    public abstract string Name { get; }
    public abstract double Execute(double a, double b);
}


class Addition : Operation
{
    public override string Name => "addition";
    public override double Execute(double a, double b) => a + b;
}

class Subtraction : Operation
{
    public override string Name => "subtraction";
    public override double Execute(double a, double b) => a - b;
}

class Multiplication : Operation
{
    public override string Name => "multiplication";
    public override double Execute(double a, double b) => a * b;
}

class Division : Operation
{
    public override string Name => "division";
    public override double Execute(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: division by zero");
            return double.NaN;
        }
        return a / b;
    }
}


class Calculator
{
    public double Calculate(IOperation operation, double a, double b)
    {
        return operation.Execute(a, b);
    }
}


class ProgramCalculator
{
    static void Main()
    {
        Calculator calc = new Calculator();

        Console.Write("Enter the first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("\nSelect operation");
        Console.WriteLine("1 — addition");
        Console.WriteLine("2 — subtraction");
        Console.WriteLine("3 — multiplication");
        Console.WriteLine("4 — division");
        Console.Write("Your choise: ");
        string choice = Console.ReadLine();

        IOperation operation = choice switch
        {
            "1" => new Addition(),
            "2" => new Subtraction(),
            "3" => new Multiplication(),
            "4" => new Division(),
            _ => null
        };

        if (operation == null)
        {
            Console.WriteLine("incorrect choise of operation");
            return;
        }

        double result = calc.Calculate(operation, a, b);

        Console.WriteLine($"\nOperation: {operation.Name}");
        Console.WriteLine($"Result: {result}");
    }
}