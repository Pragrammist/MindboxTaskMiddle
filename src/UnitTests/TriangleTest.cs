using FigureCalculator;
using FigureCalculator.Interfaces;

namespace UnitTests;

public class TriangleTest
{
    [Theory]
    [InlineData(
        12, 
        12, 
        12, 
        62, 
        true, 
        true, 
        true, 
        true, 
        true)]
    [InlineData(
        25, 
        12, 
        12, 
        0, 
        false, 
        true, 
        false, 
        true, 
        true)]
    [InlineData(
        12, 
        25, 
        12, 
        0, 
        false, 
        true, 
        true, 
        false, 
        true)]
    [InlineData(
        12, 
        12, 
        25, 
        0, 
        false, 
        true, 
        true, 
        true, 
        false)]
    [InlineData(
        0, 
        0, 
        0, 
        0, 
        false, 
        false, 
        false, 
        false, 
        false)]
    public void TriangleSquareTest(
        double firstSideLength, 
        double secondSideLength, 
        double thirdSideLength,
        double square,
        bool isValid,
        bool sidesIsGreaterZero,
        bool firstSideIsValid,
        bool secondSideIsValid,
        bool thirdSideIsValid)
    {
        var triangle = new Triangle(firstSideLength, secondSideLength, thirdSideLength);

        
        var triangleResult = triangle.SquareResult;
        
        
        var squareRounded = Math.Round(square, 0);
        var triangleResultSquareRounded = Math.Round(triangle.SquareResult.Square, 0);
        Assert.Equal(squareRounded, triangleResultSquareRounded);
        Assert.Equal(isValid, triangleResult.IsValid);
        Assert.Equal(sidesIsGreaterZero, triangleResult.SidesIsGreaterZero);
        Assert.Equal(firstSideIsValid, triangleResult.FirstSideIsValid);
        Assert.Equal(secondSideIsValid, triangleResult.SecondSideIsValid);
        Assert.Equal(thirdSideIsValid, triangleResult.ThirdSideIsValid);
    }

    
    [Theory]
    [InlineData(
        12, 
        12, 
        12, 
        62, 
        true)]
    [InlineData(
        25, 
        12, 
        12, 
        0, 
        false)]
    [InlineData(
        12, 
        25, 
        12, 
        0, 
        false)]
    [InlineData(
        12, 
        12, 
        25, 
        0, 
        false)]
    [InlineData(
        0, 
        0, 
        0, 
        0, 
        false)]
    public void TriangleSquareNoTypeTest(
        double firstSideLength, 
        double secondSideLength, 
        double thirdSideLength,
        double square,
        bool isValid)
    {
        IFigure<SquareResult> triangle = new Triangle(firstSideLength, secondSideLength, thirdSideLength);

        
        var triangleResult = triangle.SquareResult;
        
        
        var squareRounded = Math.Round(square, 0);
        var triangleResultSquareRounded = Math.Round(triangle.SquareResult.Square, 0);
        Assert.Equal(squareRounded, triangleResultSquareRounded);
        Assert.Equal(isValid, triangleResult.IsValid);
        
    }
}