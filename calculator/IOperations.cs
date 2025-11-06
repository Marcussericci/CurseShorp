using System;

namespace calculator
{
    public interface IOperation
    {
        double Execute(double a, double b);
        string Name { get; }
    }

    public interface ISingleOperation
    {
        double Execute(double a);
        string Name { get; }
    }
}