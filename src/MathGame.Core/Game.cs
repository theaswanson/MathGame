using System.Diagnostics;
using MathGame.Core.Questions;

namespace MathGame.Core.Utilities;

public class Game<T>(IQuestionGenerator<T> questionGenerator, IConsole console) where T : IQuestion
{
    private readonly Dictionary<int, QuestionAndAnswer<IQuestion, int>> questionHistory = [];

    public void Play(int numberOfQuestions)
    {
        if (numberOfQuestions <= 0)
        {
            return;
        }

        for (int i = 0; i < numberOfQuestions; i++)
        {
            var result = AskQuestion();
            questionHistory.Add(questionHistory.Count + 1, result);
        }

        var results = new GameResults(console);
        results.Print(questionHistory);
    }

    private QuestionAndAnswer<IQuestion, int> AskQuestion()
    {
        var question = questionGenerator.Generate();

        console.Print(question.Prompt);

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var guess = GetUserGuess();
        stopwatch.Stop();

        console.Print(question.IsCorrect(guess) ? "Correct!" : "Incorrect.");

        return new QuestionAndAnswer<IQuestion, int>(question, new Answer<int>(guess, stopwatch.Elapsed));
    }

    private int GetUserGuess()
    {
        try
        {
            var guess = console.Read();
            return Convert.ToInt32(guess);
        }
        catch (Exception)
        {
            console.Print("Invalid guess, try again:");
            return GetUserGuess();
        }
    }
}
