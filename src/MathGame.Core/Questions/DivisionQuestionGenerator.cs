using MathGame.Core.Utilities;

namespace MathGame.Core.Questions;

public class DivisionQuestionGenerator(IRandomNumberGenerator rng) : IQuestionGenerator<DivisionQuestion>
{
    public DivisionQuestion Generate()
    {
        var (first, second) = (rng.Generate(1, 10), rng.Generate(1, 20));

        return new DivisionQuestion(first * second, second, first);
    }
}
