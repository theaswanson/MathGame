using MathGame.Core.Questions;
using MathGame.Core.Utilities;
using Console = MathGame.Core.Utilities.Console;

var rng = new RandomNumberGenerator();
var additionQuestionGenerator = new IntegerAdditionQuestionGenerator(rng);
var divisionQuestionGenerator = new DivisionQuestionGenerator(rng);
var console = new Console();

var playAgain = false;
do
{
    console.Print("Select a game:");
    console.Print("[1] Addition");
    console.Print("[2] Division");

    var selectedGame = Convert.ToInt32(console.Read());

    switch (selectedGame)
    {
        case 1:
            PlayAddition(additionQuestionGenerator, console);
            break;
        case 2:
            PlayDivision(divisionQuestionGenerator, console);
            break;
    }

    console.Print("Play again? (Y/N)");
    var playAgainResponse = console.Read();
    playAgain = string.Equals(playAgainResponse, "Y", StringComparison.InvariantCultureIgnoreCase);
}
while (playAgain);

static void PlayAddition(IntegerAdditionQuestionGenerator additionQuestionGenerator, Console console)
{
    console.Print("Number of questions:");
    var numberOfQuestions = Convert.ToInt32(console.Read());

    new Game<IntegerAdditionQuestion>(additionQuestionGenerator, console).Play(numberOfQuestions);
}

static void PlayDivision(DivisionQuestionGenerator divisionQuestionGenerator, Console console)
{
    console.Print("Number of questions:");
    var numberOfQuestions = Convert.ToInt32(console.Read());

    new Game<DivisionQuestion>(divisionQuestionGenerator, console).Play(numberOfQuestions);
}