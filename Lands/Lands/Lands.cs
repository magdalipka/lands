using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lands {
    internal class Lands : Game {

        internal Lands() { 
            this.turnsMediator = new DefaultTurnsMediator(Handler);
            this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, 0, "Player1"));
            this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, 1, "Player2"));
            this.turnsMediator.Start();
        }

        private void Handler(int id, string content) {
            Console.WriteLine($"{id}: {content}");
        }
    }
}
