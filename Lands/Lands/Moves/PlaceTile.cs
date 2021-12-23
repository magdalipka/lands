using Framework;

namespace Lands {

    //availableTileIndex;tileX;tileY
    public class PlaceTile : Move {
        
        public PlaceTile(Game game) : base(game) {}

        public override void Make(string command) {
            string[] content = command.Split(';');
            Lands lands = (Lands) this.game;
            int tileIndex = int.Parse(content[0]);
            int x = int.Parse(content[1]);
            int y = int.Parse(content[2]);
            lands.Board.SetTile(lands.availableTiles[tileIndex], x, y);
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }
    }
}