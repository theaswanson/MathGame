namespace MathGame.Core.Questions;

public record Answer<T>(T Guess, TimeSpan TimeElapsed);
