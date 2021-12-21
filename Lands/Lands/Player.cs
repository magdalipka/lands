using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lands {
    internal class LandsPlayer : Player {

        
        public LandsPlayer(TurnsMediator turnsMediator, int id, string name) : base(turnsMediator, id, name) {
        }



        public override void Move() {
            Console.WriteLine("Hello I'm 2");
            turnsMediator.Notify(id, Console.ReadLine());
        }
    }
}
