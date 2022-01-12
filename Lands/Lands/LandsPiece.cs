using Framework;

namespace Lands {
    internal class LandsPiece : Piece {

        public Meeple meeple;
        public PieceType type;

        public enum PieceType : int { 
            City = 15,
            Road = 10,
            Grass = 3,
            Blank = 0
        }

        public LandsPiece(PieceType pieceType) { 
            this.type = pieceType;
        }

        public void SetMeeple(Meeple meeple) {
            if (this.meeple == null) {
                this.meeple = meeple;
            }
        }
    }
}
