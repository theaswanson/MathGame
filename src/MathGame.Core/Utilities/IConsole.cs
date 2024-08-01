namespace MathGame.Core.Utilities;

public interface IConsole
{
    void Print(string message);
    string? Read();
}
