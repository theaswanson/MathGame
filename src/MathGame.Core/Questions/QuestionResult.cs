namespace MathGame.Core.Questions;

public class QuestionResult
{
    public IntegerAdditionQuestion Question { get; set; }
    public int Guess { get; set; }
    public TimeSpan TimeElapsed { get; set; }

    public QuestionResult()
    {
        Question = new IntegerAdditionQuestion();
        Guess = 0;
        TimeElapsed = new TimeSpan();
    }
}
