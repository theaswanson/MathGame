// using NUnit.Framework;
// using MathGame.Core;
// using Moq;

// namespace MathGame.Tests;

// public class The_game
// {
//     protected Game game;
//     protected Mock<IIntegerAdditionQuestionGenerator> questionGenerator;
//     protected Mock<IConsole> prompter;

//     public The_game()
//     {
//         Setup();
//     }

//     [SetUp]
//     public virtual void Setup()
//     {
//         questionGenerator = new Mock<IIntegerAdditionQuestionGenerator>();
//         prompter = new Mock<IConsole>();
//         game = new Game(questionGenerator.Object, prompter.Object);
//     }

//     [TestFixture]
//     public class When_playing : The_game
//     {
//         public override void Setup()
//         {
//             base.Setup();
//             questionGenerator.Setup(g => g.Generate()).Returns(new IntegerAdditionQuestion
//             {
//                 FirstNumber = 1,
//                 SecondNumber = 1,
//                 CorrectAnswer = 2
//             });
//         }

//         protected void Act() => game.Play();

//         [Test]
//         public void It_generates_a_question()
//         {
//             Act();
//             questionGenerator.Verify(g => g.Generate(), Times.Once);
//         }

//         public void It_prompts_the_user()
//         {
//             Act();
//             prompter.Verify(p => p.Print("What is 1 + 1?"), Times.Once);
//         }

//         [Test]
//         public void It_reads_input()
//         {
//             Act();
//             reader.Verify(r => r.Read(), Times.Once);
//         }

//         [Test]
//         public void Returns_message_on_win()
//         {
//             reader.Setup(r => r.Read()).Returns("2");
//             Act();
//             prompter.Verify(p => p.Print("You win!"), Times.Once);
//         }

//         [Test]
//         public void Returns_message_on_lose()
//         {
//             reader.Setup(r => r.Read()).Returns("1");
//             Act();
//             prompter.Verify(p => p.Print("You lost."), Times.Once);
//         }
//     }
// }