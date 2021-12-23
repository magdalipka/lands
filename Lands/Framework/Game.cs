using System.Collections.Generic;
using System.Text.Json;

namespace Framework {
    public class Game {

        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        
        protected TurnsMediator turnsMediator;

        public Game() {
            Players = new List<Player>();
        }

        public void AddPlayer(Player player) { 
            Players.Add(player);
        }

        public string GameJSON() {
            return JsonSerializer.Serialize(this);
        }
    }
}
