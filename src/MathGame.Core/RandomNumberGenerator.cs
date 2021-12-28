namespace MathGame.Core
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        protected Random rng;

        public RandomNumberGenerator()
        {
            rng = new Random();
        }

        public int Generate(int min, int max)
        {
            return rng.Next(min, max);
        }
    }
}
