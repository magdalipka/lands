using Framework;
using System;

namespace Lands {
    internal class LandsPlayer : Player {

        public ConsoleColor consoleColor;
        public int meeplesLeft = 2;
        
        public LandsPlayer(TurnsMediator turnsMediator, int id, string name, ConsoleColor consoleColor) : base(turnsMediator, id, name) {
            this.consoleColor = consoleColor;
        }

        public override void Move() {
            Console.WriteLine($"{name} command: ");
            turnsMediator.Notify(id, Console.ReadLine());
        }
    }
}
