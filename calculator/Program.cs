using System;

namespace calculator
{
    public class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();

            Console.WriteLine("\nSelect operation:");
            Console.WriteLine("1 - addition");
            Console.WriteLine("2 - subtraction");
            Console.WriteLine("3 - multiplication");
            Console.WriteLine("4 - division");
            Console.WriteLine("5 - sine");
            Console.WriteLine("6 - cosine");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            try
            {
                object operation = calc.GetOperation(choice);

                if (operation == null)
                {
                    Console.WriteLine("Invalid operation choice!");
                    return;
                }

                if (calc.IsSingleOperation(choice))
                {
                    Console.Write("Enter the angle in degrees: ");
                    double angle = double.Parse(Console.ReadLine());

                    ISingleOperation singleOp = (ISingleOperation)operation;
                    double result = calc.Calculate(singleOp, angle);

                    Console.WriteLine($"\nOperation: {singleOp.Name}");
                    Console.WriteLine($"Result: {result:F6}");
                }
                else
                {
                    Console.Write("Enter the first number: ");
                    double a = double.Parse(Console.ReadLine());

                    Console.Write("Enter the second number: ");
                    double b = double.Parse(Console.ReadLine());

                    IOperation doubleOp = (IOperation)operation;
                    double result = calc.Calculate(doubleOp, a, b);

                    Console.WriteLine($"\nOperation: {doubleOp.Name}");
                    Console.WriteLine($"Result: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}