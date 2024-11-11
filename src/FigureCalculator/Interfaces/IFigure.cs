namespace FigureCalculator.Interfaces;



public record SquareResult(double Square, bool IsValid);

public interface IFigure<out TSquareResult> where TSquareResult : SquareResult
{ 
    TSquareResult SquareResult { get; }
}
