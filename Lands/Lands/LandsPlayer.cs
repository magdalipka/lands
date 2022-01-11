using Framework;
using System;

namespace Lands {

    struct PlayerInput {
        public string name;
        public ConsoleColor color;

        public PlayerInput(string name, ConsoleColor color) {
            this.name = name;
            this.color = color;
        }
    }
    internal class LandsPlayer : Player {

        public ConsoleColor consoleColor;
        private ILandsUserInterface userInterface;
        
        public LandsPlayer(TurnsMediator turnsMediator, int id, string name, ConsoleColor consoleColor, ILandsUserInterface userInterface) : base(turnsMediator, id, name) {
            this.consoleColor = consoleColor;
            this.userInterface = userInterface;
        }

        public override void Move() {
            ConsoleColor oldColor = Console.BackgroundColor;
            Console.BackgroundColor = consoleColor;
            userInterface.WriteLine($"{name} command: ");
            Console.BackgroundColor = oldColor;
            turnsMediator.Notify(id, userInterface.ReadCommand());
        }
    }
}
