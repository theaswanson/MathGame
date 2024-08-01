namespace MathGame.Core.Utilities;

public class Console : IConsole
{
    public void Print(string message) => System.Console.WriteLine(message);
    public string? Read() => System.Console.ReadLine();
}