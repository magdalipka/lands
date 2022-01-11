using System;

namespace Lands {
    internal class Program {
        
        static void Main(string[] args) {
            LandsCreator landsCreator = new LandsCreator();

            landsCreator.AddPlayer("Player 1", ConsoleColor.Blue);
            landsCreator.AddPlayer("Player 2", ConsoleColor.Red);
            landsCreator.SetBoard(5, 5);

            Lands game = landsCreator.build();

        }
    }
}
