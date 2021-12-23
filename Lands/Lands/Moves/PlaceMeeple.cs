using Framework;

namespace Lands {
    public class PlaceMeeple : Move {
        public PlaceMeeple(Game game) : base(game) {}

        public override void Make(string command) {
            string[] content = command.Split(';');
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }
    }
}