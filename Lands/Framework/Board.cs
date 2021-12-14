using System.Collections.Generic;

namespace Framework {
    public class Board {

        public List<Tile> tiles { get; set; }
        protected int width;
        protected int height;

        public Board(int width, int height) { 
            this.width = width;
            this.height = height;
            tiles = new List<Tile>();
            for (int i = 0; i < width * height; ++i) { 
                tiles.Add(new Tile());
            } 
        }

        public Tile GetTile(int x, int y) {
            return tiles[width * x + y];
        }

        public int GetWidth() {
            return width;
        }

        public int GetHeight() { 
            return height;
        }
    }
}
