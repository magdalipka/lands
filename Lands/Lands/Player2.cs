using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lands {
    internal class Player2 : Player {
        public Player2(TurnsMediator turnsMediator, int id) : base(turnsMediator, id) {}

        public override void Move() {
            Console.WriteLine("Hello I'm 2");
            turnsMediator.Notify(id, Console.ReadLine());
        }
    }
}
