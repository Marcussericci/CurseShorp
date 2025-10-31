using System;

public class Calculator
{
    public double Calculate(double a, double b, string operation)
    {
        switch (operation)
        {
            case "1":
                return a + b;
            case "2":
                return a - b;
            case "3":
                return a * b;
            case "4":
                if (b == 0)
                {
                    throw new DivideByZeroException("Division by zero!");
                }
                return a / b;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }

    public string GetOperationName(string operation)
    {
        return operation switch
        {
            "1" => "addition",
            "2" => "subtraction",
            "3" => "multiplication",
            "4" => "division",
            _ => "unknown operation"
        };
    }
}