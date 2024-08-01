using ConsoleTables;
using MathGame.Core.Questions;
using MathGame.Core.Utilities;

namespace MathGame.Core;

public class GameResults(IConsole console)
{
    public void Print(IDictionary<int, QuestionAndAnswer<IQuestion, int>> results)
    {
        console.Print($"Accuracy: {Accuracy(results.Select(result => result.Value)):0.0}%");
        console.Print($"Average time to guess: {AverageTimeToAnswer(results.Select(result => result.Value.Answer)):0.0} seconds");

        var resultsToPrint = results.Select(result => new QuestionResultOutput
        {
            QuestionNumber = result.Key,
            Prompt = result.Value.Question.Prompt,
            Guess = result.Value.Answer.Guess,
            CorrectAnswer = result.Value.Question.CorrectAnswer,
            TimeInSeconds = result.Value.Answer.TimeElapsed.TotalSeconds.ToString("0.0")
        });

        ConsoleTable
            .From(resultsToPrint)
            .Configure(options => options.Columns = ["#", "Question", "Guess", "Answer", "Time (sec.)"])
            .Write(Format.Minimal);
    }

    protected static decimal Accuracy(IEnumerable<QuestionAndAnswer<IQuestion, int>> results) =>
        (decimal)CorrectAnswers(results) / results.Count() * 100;

    protected static int CorrectAnswers(IEnumerable<QuestionAndAnswer<IQuestion, int>> results) =>
        results.Count(result => result.Answer.Guess == result.Question.CorrectAnswer);
    
    protected static double AverageTimeToAnswer<T>(IEnumerable<Answer<T>> answers) =>
        answers.Average(answer => answer.TimeElapsed.TotalSeconds);
}