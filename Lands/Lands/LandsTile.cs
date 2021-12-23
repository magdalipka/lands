using Framework;
using static Lands.LandsPiece;

namespace Lands {
    internal class LandsTile : Tile {

        public LandsTile(PieceType upper, PieceType left, PieceType central, PieceType right, PieceType lower) {
            Pieces.Add(new LandsPiece(upper));
            Pieces.Add(new LandsPiece(left));
            Pieces.Add(new LandsPiece(central));
            Pieces.Add(new LandsPiece(right));
            Pieces.Add(new LandsPiece(lower));
        }
    }
}
