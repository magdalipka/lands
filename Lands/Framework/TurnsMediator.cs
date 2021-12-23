using System.Collections.Generic;

namespace Framework {
    public abstract class TurnsMediator {

        public int waitingFor = 0;
        public delegate void Handler(int id, string content);

        public readonly List<Player> players = new List<Player>();
        public Handler handler;

        public abstract void AddPlayer(Player player);

        public abstract void Start();

        public abstract void Notify(int id, string content);
    }
}
