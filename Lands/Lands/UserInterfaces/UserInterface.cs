using Framework;
using System.Collections.Generic;

namespace Lands {
    internal interface ILandsUserInterface {
        public void WriteLine(string data);
        public void Write(char data);
        public void Clear();
        public string ReadCommand();

        public void DrawRound(Board board, List<LandsTile> tiles);
        public void DrawAvailableTiles(List<LandsTile> tiles);
        public void DrawBoard(Board board);
    }
}