using ConsoleTables;
using MathGame.Core.Questions;
using MathGame.Core.Utilities;

namespace MathGame.Core;

public class GameResults
{
    private readonly IConsole console;

    public GameResults(IConsole console)
    {
        this.console = console;
    }

    public void Print(IDictionary<int, QuestionResult> results)
    {
        console.Print($"Accuracy: {Accuracy(results):0.0}%");
        console.Print($"Average time to guess: {AverageTimeToAnswer(results):0.0} seconds");

        var resultsToPrint = results.Select(result => new QuestionResultOutput
        {
            QuestionNumber = result.Key,
            Prompt = result.Value.Question.Prompt,
            Guess = result.Value.Guess,
            CorrectAnswer = result.Value.Question.CorrectAnswer,
            TimeInSeconds = result.Value.TimeElapsed.TotalSeconds.ToString("0.0")
        });

        ConsoleTable
            .From(resultsToPrint)
            .Configure(options => options.Columns = new List<string> { "#", "Question", "Guess", "Answer", "Time (sec.)" })
            .Write(Format.Minimal);
    }

    protected static decimal Accuracy(IDictionary<int, QuestionResult> results) =>
        (decimal)CorrectAnswers(results) / results.Count * 100;

    protected static int CorrectAnswers(IDictionary<int, QuestionResult> results) =>
        results.Values.Count(r => r.Guess == r.Question.CorrectAnswer);
    
    protected static double AverageTimeToAnswer(IDictionary<int, QuestionResult> results) =>
        results.Values.Average(result => result.TimeElapsed.TotalSeconds);
}