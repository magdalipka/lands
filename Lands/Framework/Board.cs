using System.Collections.Generic;

namespace Framework {
    public class Board {

        public List<Tile> Tiles { get; set; }
        protected int width;
        protected int height;

        public Board(int width, int height) { 
            this.width = width;
            this.height = height;
            Tiles = new List<Tile>();
            for (int i = 0; i < width * height; ++i) { 
                Tiles.Add(new Tile());
            } 
        }

        public void SetTile(Tile tile, int index) {
            Tiles[index] = tile;
        }

        public Tile GetTile(int x, int y) {
            return Tiles[width * x + y];
        }

        public int GetWidth() {
            return width;
        }

        public int GetHeight() { 
            return height;
        }
    }
}
