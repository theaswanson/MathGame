using MathGame.Core.Questions;
using MathGame.Core.Utilities;
using Console = MathGame.Core.Utilities.Console;

var questionGenerator = new IntegerAdditionQuestionGenerator(new RandomNumberGenerator());
var console = new Console();

var playAgain = false;
do
{
    console.Print("Number of questions:");
    var numberOfQuestions = Convert.ToInt32(console.Read());
    new Game(questionGenerator, console).Play(numberOfQuestions);
    console.Print("Play again? (Y/N)");
    var playAgainResponse = console.Read();
    playAgain = string.Equals(playAgainResponse, "Y", StringComparison.InvariantCultureIgnoreCase);
}
while (playAgain);
