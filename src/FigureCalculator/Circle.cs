using FigureCalculator.Interfaces;

namespace FigureCalculator;

public record CircleSquareResult(double Square, bool IsValid, bool RadiusIsGreaterZero) : SquareResult(Square, IsValid);

public record Circle(double Radius) : IFigure<CircleSquareResult>
{
    bool RadiusIsGreaterZero => Radius > 0;
    bool IsValid => RadiusIsGreaterZero;
    double SquareCalculated => IsValid
        ? Math.PI * Radius * Radius
        : 0;
    
    public CircleSquareResult SquareResult => new CircleSquareResult(SquareCalculated, IsValid, RadiusIsGreaterZero);
}
