using System.Diagnostics;
using ConsoleTables;

namespace MathGame.Core;

public class Game
{
    protected Dictionary<int, QuestionResult> questionHistory = new Dictionary<int, QuestionResult>();

    private readonly IIntegerAdditionQuestionGenerator questionGenerator;
    private readonly IConsole console;

    public Game(
        IIntegerAdditionQuestionGenerator questionGenerator,
        IConsole console
    )
    {
        this.questionGenerator = questionGenerator;
        this.console = console;
    }

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

    protected QuestionResult AskQuestion()
    {
        var question = questionGenerator.Generate();

        console.Print(question.Prompt);

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var guess = GetUserGuess();
        stopwatch.Stop();

        console.Print(question.IsCorrect(guess) ? "Correct!" : "Incorrect.");

        return new QuestionResult
        {
            Question = question,
            Guess = guess,
            TimeElapsed = stopwatch.Elapsed
        };
    }

    protected int GetUserGuess()
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

public class GameResults
{
    private readonly IConsole console;

    public GameResults(IConsole console)
    {
        this.console = console;
    }

    public void Print(Dictionary<int, QuestionResult> results)
    {
        console.Print($"Accuracy: {Accuracy(results).ToString("0.0")}%");
        console.Print($"Average time to guess: {AverageTimeToAnswer(results).Value.ToString("0.0")} seconds");

        var resultsForOutput = new Dictionary<int, QuestionResultOutput>();
        foreach (var result in results)
        {
            resultsForOutput.Add(result.Key, new QuestionResultOutput
            {
                QuestionNumber = result.Key,
                Prompt = result.Value.Question.Prompt,
                Guess = result.Value.Guess,
                CorrectAnswer = result.Value.Question.CorrectAnswer,
                TimeInSeconds = result.Value.TimeElapsed.TotalSeconds.ToString("0.0")
            });
        }

        ConsoleTable
            .From(resultsForOutput.Select(r => r.Value))
            .Configure(o => o.Columns = new List<string> { "#", "Question", "Guess", "Answer", "Time (sec.)" })
            .Write(Format.Minimal);
    }

    protected decimal Accuracy(Dictionary<int, QuestionResult> results) =>
        (decimal)CorrectAnswers(results) / (decimal)results.Count * 100;

    protected int CorrectAnswers(Dictionary<int, QuestionResult> results) =>
        results.Values.Count(r => r.Guess == r.Question.CorrectAnswer);
    
    protected double? AverageTimeToAnswer(Dictionary<int, QuestionResult> results) =>
        results.Values.Average(r => r.TimeElapsed.TotalSeconds);
}