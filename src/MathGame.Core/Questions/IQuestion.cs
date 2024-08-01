namespace MathGame.Core.Questions;

public interface IQuestion
{
    string Prompt { get; }
    int CorrectAnswer { get; }
    bool IsCorrect(int guess) => guess == CorrectAnswer;
}
