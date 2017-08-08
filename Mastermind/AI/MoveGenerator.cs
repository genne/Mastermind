using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.AI
{
    public class MoveGenerator
    {
        private readonly int _size;

        private class MoveWithResult
        {
            public Pin[] Pins { get; set; }
            public ResultPin[] Result { get; set; }
        }

        private List<MoveWithResult> _moves = new List<MoveWithResult>();
        private Random _random = new Random();

        public MoveGenerator(int size)
        {
            _size = size;
        }

        public int NumMoves => _moves.Count;
        public Pin[] LastMove => _moves.Last().Pins;

        public void AddMove(Pin[] move, ResultPin[] result)
        {
            _moves.Add(new MoveWithResult
            {
                Pins = move,
                Result = result.OrderByDescending(r => r).ToArray()
            });
        }

        public Pin[] GetRandomMove()
        {
            while (true)
            {
                var move = GenerateRandomMove();
                if (IsValidMove(move))
                {
                    return move;
                }
            }
        }

        private bool IsValidMove(Pin[] move)
        {
            return _moves.All(m => IsValidMove(m, move));
        }

        private bool IsValidMove(MoveGenerator.MoveWithResult m, Pin[] move)
        {
            var expectedResult = new Board(move).Play(m.Pins);
            return expectedResult.SequenceEqual(m.Result);
        }

        private Pin[] GenerateRandomMove()
        {
            return Enumerable.Range(0, _size).Select(_ => GetRandomPin()).ToArray();
        }

        private Pin GetRandomPin()
        {
            return (Pin)_random.Next(Enum.GetValues(typeof(Pin)).Length);
        }
    }
}