using System.Collections.Generic;

namespace Framework {
    public class Tile {

        public string TexturePath { get; set; }

        public List<Piece> Pieces { get; set; }

        public Tile() {
            Pieces = new List<Piece>();
        }
    }
}
