namespace MathGame.Core
{
    public class IntegerAdditionQuestionGenerator : IIntegerAdditionQuestionGenerator
    {
        private readonly IRandomNumberGenerator rng;

        public IntegerAdditionQuestionGenerator(IRandomNumberGenerator rng)
        {
            this.rng = rng;
        }

        public IntegerAdditionQuestion Generate()
        {
            var first = rng.Generate(1, 20);
            var second = rng.Generate(1, 20);

            return new IntegerAdditionQuestion
            {
                FirstNumber = first,
                SecondNumber = second,
                CorrectAnswer = first + second
            };
        }
    }
}
