using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Mastermind
{
    public class Board
    {
        private Pin[] _pins;

        public Board(params Pin[] pins)
        {
            _pins = pins;
        }

        public int Size => _pins.Length;

        public IEnumerable<ResultPin> Play(params Pin[] pins)
        {
            var boardPins = ToOptionalPins(_pins);
            var playedPins = ToOptionalPins(pins);

            var correctPins = FindCorrectPins(boardPins, playedPins);
            var incorrectPins = FindIncorrectPins(boardPins, playedPins);

            return correctPins.Concat(incorrectPins);
        }

        private IEnumerable<ResultPin> FindIncorrectPins(Pin?[] boardPins, Pin?[] playedPins)
        {
            for (int i = 0; i < boardPins.Length; i++)
            {
                var pin = playedPins[i];
                if (pin == null) continue;

                if (FindAndRemove(boardPins, pin.Value))
                {
                    playedPins[i] = null;
                    yield return ResultPin.IncorrectPlace;
                }
            }
        }

        private static IEnumerable<ResultPin> FindCorrectPins(Pin?[] boardPins, Pin?[] playedPins)
        {
            for (int i = 0; i < boardPins.Length; i++)
            {
                if (playedPins[i] == boardPins[i])
                {
                    playedPins[i] = null;
                    boardPins[i] = null;

                    yield return ResultPin.CorrectPlace;
                }
            }
        }

        private Pin?[] ToOptionalPins(Pin[] pins)
        {
            return pins.Select(p => (Pin?)p).ToArray();
        }

        private bool FindAndRemove(Pin?[] availablePins, Pin pin)
        {
            for (int i = 0; i < availablePins.Length; i++)
            {
                if (availablePins[i] == pin)
                {
                    availablePins[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}