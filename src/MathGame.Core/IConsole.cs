namespace MathGame.Core;

public interface IConsole
{
    void Print(string message);
    string? Read();
}
