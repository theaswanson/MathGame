namespace MathGame.Core.Questions;

public interface IQuestionGenerator<T> where T : IQuestion
{
    T Generate();
}
