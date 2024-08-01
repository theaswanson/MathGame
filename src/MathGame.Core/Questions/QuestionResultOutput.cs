namespace MathGame.Core.Questions;

public class QuestionResultOutput
{
    public int QuestionNumber { get; set; }
    public string? Prompt { get; set; }
    public int Guess { get; set; }
    public int CorrectAnswer { get; set; }
    public string? TimeInSeconds { get; set; }
}