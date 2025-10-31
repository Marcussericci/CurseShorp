using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace calculator
{
    public class Program
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
                IOperation operation = calc.GetOperation(choice);

                if (operation == null)
                {
                    Console.WriteLine("Invalid operation choice!");
                    return;
                }

                double result = calc.Calculate(operation, a, b);

                Console.WriteLine($"\nOperation: {operation.Name}");
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}