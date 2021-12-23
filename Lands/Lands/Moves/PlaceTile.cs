using Framework;

namespace Lands {

    //availableTileIndex;onBoardIndex
    public class PlaceTile : Move {
        public PlaceTile(Game game) : base(game) {}

        public override void Make(string command) {
            string[] content = command.Split(';');
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }
    }
}