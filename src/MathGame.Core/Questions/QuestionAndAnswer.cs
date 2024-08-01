namespace MathGame.Core.Questions;

public record QuestionAndAnswer<IQuestion, TAnswer>(IQuestion Question, Answer<TAnswer> Answer);
