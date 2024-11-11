using FigureCalculator;
using FigureCalculator.Interfaces;

namespace UnitTests;

public class CircleTest
{
    [Theory]
    [InlineData(12, 452, true, true)]
    [InlineData(0, 0, false, false)]
    [InlineData(-12, 0, false, false)]
    public void CircleSquareTest(
        double radius, 
        double squareValueForChecking, 
        bool radiusIsGreaterZero, 
        bool isValid)
    {
        var circle = new Circle(radius);

        var squareResult = circle.SquareResult;

        var roundedSquareResult = Math.Round(squareResult.Square, 0);
        var roundedSquareValueForChecking = Math.Round(squareValueForChecking, 0);
        Assert.Equal(roundedSquareResult, roundedSquareValueForChecking);
        Assert.Equal(squareResult.RadiusIsGreaterZero, radiusIsGreaterZero);
        Assert.Equal(squareResult.IsValid, isValid);
    }
    
    [Theory]
    [InlineData(12, 452, true)]
    [InlineData(0, 0, false)]
    [InlineData(-1, 0, false)]
    public void CircleSquareNoTypeTest(
        double radius,
        double squareValueForChecking,
        bool isValid)
    {
        IFigure<SquareResult> figure = new Circle(radius);
        
        var squareResult = figure.SquareResult;

        var roundedSquareResult = Math.Round(squareResult.Square, 0);
        var roundedSquareValueForChecking = Math.Round(squareValueForChecking, 0);
        Assert.Equal(roundedSquareResult, roundedSquareValueForChecking);
        Assert.Equal(squareResult.IsValid, isValid);
    }
}