using System;



class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        Console.Write("Enter the first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("\nSelect operation:");
        Console.WriteLine("1 - addition");
        Console.WriteLine("2 - subtraction");
        Console.WriteLine("3 - multiplication");
        Console.WriteLine("4 - division");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        try
        {
            double result = calc.Calculate(a, b, choice);
            string operationName = calc.GetOperationName(choice);

            Console.WriteLine($"\nOperation: {operationName}");
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}