using MathGame.Core.Utilities;

namespace MathGame.Core.Questions;

public class IntegerAdditionQuestionGenerator(IRandomNumberGenerator rng) : IIntegerAdditionQuestionGenerator
{
    public IntegerAdditionQuestion Generate()
    {
        var (first, second) = (rng.Generate(1, 20), rng.Generate(1, 20));

        return new IntegerAdditionQuestion
        {
            FirstNumber = first,
            SecondNumber = second,
            CorrectAnswer = first + second
        };
    }
}
