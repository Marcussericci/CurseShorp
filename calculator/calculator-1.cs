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
    public override string Name => "Сложение";
    public override double Execute(double a, double b) => a + b;
}

class Subtraction : Operation
{
    public override string Name => "Вычитание";
    public override double Execute(double a, double b) => a - b;
}

class Multiplication : Operation
{
    public override string Name => "Умножение";
    public override double Execute(double a, double b) => a * b;
}

class Division : Operation
{
    public override string Name => "Деление";
    public override double Execute(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
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

        // Меню
        Console.WriteLine("Простой калькулятор с ООП:");
        Console.Write("Введите первое число: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("\nВыберите операцию:");
        Console.WriteLine("1 — Сложение");
        Console.WriteLine("2 — Вычитание");
        Console.WriteLine("3 — Умножение");
        Console.WriteLine("4 — Деление");
        Console.Write("Ваш выбор: ");
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
            Console.WriteLine("Неверный выбор операции.");
            return;
        }

        double result = calc.Calculate(operation, a, b);

        Console.WriteLine($"\nОперация: {operation.Name}");
        Console.WriteLine($"Результат: {result}");
    }
}