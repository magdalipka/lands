using System.Collections.Generic;

namespace Framework {
    public class DefaultTurnsMediator : TurnsMediator {
        
        public DefaultTurnsMediator(Handler handler) {
            this.handler = handler;
        }

        public override void AddPlayer(Player player) {
            players.Add(player);
        }

        public override void Start() {
            players[waitingFor].Move();
        }

        public override void Notify(int id, string content) {
            if (id == waitingFor) {
                waitingFor = (waitingFor + 1) % players.Count;
                handler(id, content);
                players[waitingFor].Move();
            }
        }

    }
}
