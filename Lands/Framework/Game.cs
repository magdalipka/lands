using System.Collections.Generic;
using System.Text.Json;

namespace Framework {
    public class Game {

        public Board Board { get; set; }
        
        public TurnsMediator turnsMediator;

        public string GameJSON() {
            return JsonSerializer.Serialize(this);
        }
    }
}
