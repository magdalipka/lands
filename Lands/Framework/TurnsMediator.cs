using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework {
    public interface TurnsMediator {


        public void AddPlayer(Player player);

        public void Start();

        public void Notify(int id, string content);
    }

    public class DefaultTurnsMediator: TurnsMediator {
       public int waitingFor = 0;
        public delegate void Handler(int id, string content);
        
        protected readonly List<Player> players = new List<Player>();
        protected Handler handler;

        public DefaultTurnsMediator(Handler handler) {
            this.handler = handler;
        }

        public void AddPlayer(Player player) { 
            players.Add(player);
        }

        public void Start() {
            players[waitingFor].Move();
        }

        public void Notify(int id, string content) {
            if (id == waitingFor) {
                waitingFor = (waitingFor + 1) % players.Count;
                handler(id, content);
                players[waitingFor].Move();
            }
        }

    }
}
