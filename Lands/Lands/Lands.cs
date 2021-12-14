using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lands {
    internal class Lands : Game {

        internal Lands() { 
            this.turnsMediator = new TurnsMediator(Handler);
            this.turnsMediator.AddPlayer(new Player1(this.turnsMediator, 0));
            this.turnsMediator.AddPlayer(new Player2(this.turnsMediator, 1));
            this.turnsMediator.Start();
        }

        private void Handler(int id, string content) {
            Console.WriteLine($"{id}: {content}");
        }
    }
}
