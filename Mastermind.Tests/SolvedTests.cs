using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.AI;
using NUnit.Framework;

namespace Mastermind.Tests
{
    [TestFixture]
    public class SolvedTests
    {
        [TestCase(Pin.Blue)]
        [TestCase(Pin.Blue, Pin.Red)]
        [TestCase(Pin.Blue, Pin.Red, Pin.Green, Pin.Orange, Pin.Yellow)]
        public void Solve(params Pin[] board)
        {
            var solver = new Solver(new Board(board));
            var correctMove = solver.Solve();
            Assert.That(correctMove, Is.EqualTo(board));
        }

        [Test]
        public void GenerateMove()
        {
            var solver = new MoveGenerator(5);
            solver.AddMove(new[] { Pin.Black, Pin.White, Pin.Blue, Pin.Brown, Pin.Orange }, new[] { ResultPin.IncorrectPlace, ResultPin.IncorrectPlace });
            solver.AddMove(new[] { Pin.Orange, Pin.Blue, Pin.Orange, Pin.Yellow, Pin.Red }, new[] { ResultPin.CorrectPlace, ResultPin.IncorrectPlace, ResultPin.IncorrectPlace, ResultPin.IncorrectPlace });
            var next = solver.GetRandomMove();
        }
    }
}
