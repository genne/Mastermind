using Mastermind;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [TestCase(new[] { Pin.Black, Pin.Blue }, new[] { Pin.Blue, Pin.Black }, new[] { ResultPin.IncorrectPlace, ResultPin.IncorrectPlace })]
        [TestCase(new[] { Pin.Black, Pin.Blue }, new[] { Pin.Black, Pin.Black }, new[] { ResultPin.CorrectPlace })]
        [TestCase(new[] { Pin.Black, Pin.Blue }, new[] { Pin.Red, Pin.Red }, new ResultPin[] { })]
        [TestCase(new[] { Pin.Black, Pin.Black }, new[] { Pin.Black, Pin.Blue }, new [] { ResultPin.CorrectPlace })]
        public void Play(Pin[] board, Pin[] played, ResultPin[] result)
        {
            var res = new Board(board).Play(played).ToArray();
            Assert.That(res, Is.EqualTo(result));
        }
    }
}
