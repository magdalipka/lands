using Framework;

namespace Lands {

    //tile:availableTileIndex;tileX;tileY
    public class PlaceTile : Move {
        
        public PlaceTile(Game game) : base(game) {}

        public override void Make(string command) {
            string[] content = command.Split(';');
            Lands lands = (Lands) game;
            int tileIndex = int.Parse(content[0]);
            int x = int.Parse(content[1]);
            int y = int.Parse(content[2]);
            if (x >= 0 && x < game.Board.GetWidth() && y >= 0 && y < game.Board.GetHeight()) {
                if (lands.Board.GetTile(x, y) == lands.blank) {
                    lands.Board.SetTile(lands.availableTiles[tileIndex], x, y);
                    lands.availableTiles.RemoveAt(tileIndex);
                }
            }
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }
    }
}