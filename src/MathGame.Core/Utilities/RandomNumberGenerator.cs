namespace MathGame.Core.Utilities;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random rng;

    public RandomNumberGenerator() => rng = new Random();
    public RandomNumberGenerator(int seed) => rng = new Random(seed);
    public RandomNumberGenerator(Random random) => rng = random;

    public int Generate(int min, int max) => rng.Next(min, max);
}
