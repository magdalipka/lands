using System;
using System.Linq;
using Framework;
using static Lands.LandsPiece;

namespace Lands {

    // 0 
    //123
    // 4 

    internal class LandsTile : Tile {

        public LandsTile(PieceType upper, PieceType left, PieceType central, PieceType right, PieceType lower) {
            Pieces.Add(new LandsPiece(upper));
            Pieces.Add(new LandsPiece(left));
            Pieces.Add(new LandsPiece(central));
            Pieces.Add(new LandsPiece(right));
            Pieces.Add(new LandsPiece(lower));
        }

        public static LandsTile GenerateRandom() {
            PieceType[] types = Enum.GetValues(typeof(PieceType)).Cast<PieceType>().Where(x => x != PieceType.Blank).ToArray();
            PieceType GetRandom() {
                return types[new Random().Next(0, types.Length)];
            }
            return new LandsTile(GetRandom(), GetRandom(), GetRandom(), GetRandom(), GetRandom());
        }

    }
}
