namespace MathGame.Core.Questions;

public class IntegerAdditionQuestion : IQuestion
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public int CorrectAnswer { get; set; }
    public string Prompt => $"{FirstNumber} + {SecondNumber}";
}
