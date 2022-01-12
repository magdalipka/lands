using Framework;
using System;

namespace Lands {
    internal class LandsPlayer : Player {

        public ConsoleColor consoleColor;
        private IUserInterface userInterface;
        
        public LandsPlayer(TurnsMediator turnsMediator, int id, string name, ConsoleColor consoleColor, IUserInterface userInterface) : base(turnsMediator, id, name) {
            this.consoleColor = consoleColor;
            this.userInterface = userInterface;
        }

        public override void Move() {
            turnsMediator.Notify(id, userInterface.GetCommand(this));
        }
    }
}
