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
        private LandsUserInterface userInterface;
        
        public LandsPlayer(TurnsMediator turnsMediator, int id, string name, ConsoleColor consoleColor, LandsUserInterface userInterface) : base(turnsMediator, id, name) {
            this.consoleColor = consoleColor;
            this.userInterface = userInterface;
        }

        public override void Move() {
            userInterface.WriteLine($"{name} command: ");
            turnsMediator.Notify(id, userInterface.ReadCommand());
        }
    }
}
