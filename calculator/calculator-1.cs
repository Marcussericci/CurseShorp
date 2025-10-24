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
    public override string Name => "��������";
    public override double Execute(double a, double b) => a + b;
}

class Subtraction : Operation
{
    public override string Name => "���������";
    public override double Execute(double a, double b) => a - b;
}

class Multiplication : Operation
{
    public override string Name => "���������";
    public override double Execute(double a, double b) => a * b;
}

class Division : Operation
{
    public override string Name => "�������";
    public override double Execute(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("������: ������� �� ����!");
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

        // ����
        Console.WriteLine("������� ����������� � ���:");
        Console.Write("������� ������ �����: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("������� ������ �����: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("\n�������� ��������:");
        Console.WriteLine("1 � ��������");
        Console.WriteLine("2 � ���������");
        Console.WriteLine("3 � ���������");
        Console.WriteLine("4 � �������");
        Console.Write("��� �����: ");
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
            Console.WriteLine("�������� ����� ��������.");
            return;
        }

        double result = calc.Calculate(operation, a, b);

        Console.WriteLine($"\n��������: {operation.Name}");
        Console.WriteLine($"���������: {result}");
    }
}