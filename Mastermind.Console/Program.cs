using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.AI;

namespace Mastermind.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new MoveGenerator(5);
            solver.AddMove(new[] {Pin.Black, Pin.White, Pin.Blue, Pin.Brown, Pin.Orange}, new [] { ResultPin.IncorrectPlace, ResultPin.IncorrectPlace });
            solver.AddMove(new[] { Pin.Orange, Pin.Blue, Pin.Orange, Pin.Yellow, Pin.Red }, new[] { ResultPin.IncorrectPlace, ResultPin.IncorrectPlace, ResultPin.IncorrectPlace, ResultPin.CorrectPlace });
            while (true)
            {
                var move = solver.GetRandomMove();
                System.Console.WriteLine(string.Join(", ", move.Select(m => m.ToString())));
                System.Console.Write("Enter result: ");
                try
                {
                    var res = System.Console.ReadLine().Select(c => c == 'b' ? ResultPin.IncorrectPlace : ResultPin.CorrectPlace ).ToArray();
                    solver.AddMove(move, res);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
        }
    }
}
