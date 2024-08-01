namespace MathGame.Core.Questions;

public record QuestionResult(IntegerAdditionQuestion Question, int Guess, TimeSpan TimeElapsed);
