namespace Framework {
     public abstract class Move {

        public Game game;

        public Move(Game game) { 
            this.game = game;
        }
        
        public abstract void Make(string command);

        public abstract bool IsPossible(string command);
     }
}