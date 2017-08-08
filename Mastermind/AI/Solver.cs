using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.AI
{
    public class Solver
    {
        private readonly Board _board;
        private readonly MoveGenerator _moveGenerator;

        public Solver(Board board)
        {
            _board = board;
            _moveGenerator = new MoveGenerator(board.Size);
        }

        public bool NextMove()
        {
            var move = _moveGenerator.GetRandomMove();
            var res = MakeMove(move);
            return IsWinner(res);
        }

        private bool IsWinner(ResultPin[] result)
        {
            return result.Length == _board.Size && result.All(r => r == ResultPin.CorrectPlace);
        }

        private ResultPin[] MakeMove(Pin[] move)
        {
            var resultPins = _board.Play(move).ToArray();
            _moveGenerator.AddMove(move, resultPins);
            return resultPins;
        }

        public Pin[] Solve()
        {
            while(!NextMove()) { }
            return _moveGenerator.LastMove;
        }
    }
}
