using FigureCalculator.Interfaces;

namespace FigureCalculator;

public record TriangleSquareResult(
    double Square,
    bool IsValid,
    bool SidesIsGreaterZero,
    bool FirstSideIsValid,
    bool SecondSideIsValid,
    bool ThirdSideIsValid) : SquareResult(Square, IsValid);

public record Triangle(double FirstSideLength, double SecondSideLength, double ThirdSideLength) : IFigure<TriangleSquareResult>
{
    //Свойства нужны, чтобы лучше понимать где не так пошла валидация
    bool SidesIsGreaterZero => FirstSideLength > 0 && SecondSideLength > 0 && ThirdSideLength > 0;
    bool FirstSideIsValid => FirstSideLength < (SecondSideLength + ThirdSideLength);
    bool SecondSideIsValid => SecondSideLength < (FirstSideLength + ThirdSideLength);
    bool ThirdSideIsValid => ThirdSideLength < (FirstSideLength + SecondSideLength);
    
    //Общая валидация
    bool IsValid => SidesIsGreaterZero && FirstSideIsValid && SecondSideIsValid && ThirdSideIsValid;

    double HalfPerimeter => (FirstSideLength + SecondSideLength + ThirdSideLength) / 2;

    double CalculateSquare => IsValid 
        ? Math.Sqrt(
            HalfPerimeter * 
            (HalfPerimeter - FirstSideLength) * 
            (HalfPerimeter - SecondSideLength) * 
            (HalfPerimeter - ThirdSideLength)
        )
        : 0;

    public TriangleSquareResult SquareResult => 
        new (CalculateSquare, IsValid, SidesIsGreaterZero,
            FirstSideIsValid, SecondSideIsValid, ThirdSideIsValid);
}
