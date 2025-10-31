using System;

namespace calculator
{
    public interface IOperation
    {
        double Execute(double a, double b);
        string Name { get; }
    }
}