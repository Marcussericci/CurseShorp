using System;

namespace calculator
{
    public class Addition : IOperation
    {
        public string Name => "addition";
        public double Execute(double a, double b) => a + b;
    }

    public class Subtraction : IOperation
    {
        public string Name => "subtraction";
        public double Execute(double a, double b) => a - b;
    }

    public class Multiplication : IOperation
    {
        public string Name => "multiplication";
        public double Execute(double a, double b) => a * b;
    }

    public class Division : IOperation
    {
        public string Name => "division";
        public double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero!");
            return a / b;
        }
    }

    public class Calculator
    {
        public double Calculate(IOperation operation, double a, double b)
        {
            return operation.Execute(a, b);
        }

        public IOperation GetOperation(string choice)
        {
            return choice switch
            {
                "1" => new Addition(),
                "2" => new Subtraction(),
                "3" => new Multiplication(),
                "4" => new Division(),
                _ => null
            };
        }
    }
}