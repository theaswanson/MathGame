namespace MathGame.Core.Questions;

public class DivisionQuestion(int dividend, int divisor, int quotient) : IQuestion
{
    public int Dividend => dividend;
    public int Divisor => divisor;
    public int CorrectAnswer => quotient;
    public string Prompt => $"{Dividend} / {Divisor}";
}
