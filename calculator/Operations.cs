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

    public class Sine : ISingleOperation
    {
        public string Name => "sine";
        public double Execute(double a)
        {
            
            double x = a * 3.141592653589793 / 180; 
            double result = 0;
            double term = x;

            for (int i = 1; i <= 10; i++)
            {
                result += term;
                term = -term * x * x / ((2 * i) * (2 * i + 1));
            }
            return result;
        }
    }

    public class Cosine : ISingleOperation
    {
        public string Name => "cosine";
        public double Execute(double a)
        {
            
            double x = a * 3.141592653589793 / 180; // 
            double result = 1;
            double term = 1;

            for (int i = 1; i <= 10; i++)
            {
                term = -term * x * x / ((2 * i - 1) * (2 * i));
                result += term;
            }
            return result;
        }
    }

    public class Calculator
    {
        public double Calculate(IOperation operation, double a, double b)
        {
            return operation.Execute(a, b);
        }

        public double Calculate(ISingleOperation operation, double a)
        {
            return operation.Execute(a);
        }

        public object GetOperation(string choice)
        {
            return choice switch
            {
                "1" => new Addition(),
                "2" => new Subtraction(),
                "3" => new Multiplication(),
                "4" => new Division(),
                "5" => new Sine(),
                "6" => new Cosine(),
                _ => null
            };
        }

        public bool IsSingleOperation(string choice)
        {
            return choice == "5" || choice == "6";
        }
    }
}