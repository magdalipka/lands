using System.Collections.Generic;

namespace Framework {
  public class Turn {
    public List<Move> moves;

    public void makeMoves() {
      this.moves.ForEach(move => move.make());
    }    

  }
}