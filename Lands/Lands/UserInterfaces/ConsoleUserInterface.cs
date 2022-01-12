using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Lands.LandsPiece;

namespace Lands {
    internal class ConsoleUserInterface : IUserInterface {

        public List<LandsPlayerData> GetPlayersData() { 
            List<LandsPlayerData> data = new List<LandsPlayerData>();
            ConsoleColor[] colors = (ConsoleColor[]) Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>()
                .Where(x => x != ConsoleColor.Black && x != ConsoleColor.White)
                .ToArray();
            int maxPlayers = colors.Length;
            int players = GetInt("How many players are playing?", 2, maxPlayers);
            for (int i = 0; i < players; ++i) {
                Console.WriteLine($"Player {i + 1} name:");
                data.Add(new LandsPlayerData(Console.ReadLine(), colors[i]));
            }
            return data;
        }

        public int GetBoardWidth() {
            return GetInt("Board width:", 1, 8);
        }

        public int GetBoardHeight() {
            return GetInt("Board height:", 1, 8);
        }

        public void DrawResults(List<int> results, List<Player> players) {
            Console.WriteLine("Results:");
            for (int i = 0; i < results.Count; ++i) {
                Console.WriteLine($"{players[i].name}: {results[i]}");
            }
        }

        public string GetCommand(LandsPlayer player) {
            ConsoleColor oldColor = Console.BackgroundColor;
            Console.BackgroundColor = player.consoleColor;
            Console.WriteLine($"{player.name} command: ");
            Console.BackgroundColor = oldColor;
            return Console.ReadLine();
        }

        public void DrawRound(Board board, List<LandsTile> availableTiles) {
            Console.Clear();
            DrawBoard(board);
            if (availableTiles.Count > 0) {
                DrawAvailableTiles(availableTiles);
            }
        }

        public void DrawAvailableTiles(List<LandsTile> tiles) {
            Console.WriteLine("Available Tiles:");
            DrawLine(tiles.ToArray(), " | ");
        }

        //(x,y)

        //(0,0)(1,0)
        //(0,1)(1,2)
        //(0,2)(1,2)
        public void DrawBoard(Board board) {
            for (int i = 0; i < board.GetHeight(); ++i) {
                List<LandsTile> line = new List<LandsTile>();
                for (int j = 0; j < board.GetWidth(); ++j) {
                    line.Add((LandsTile) board.GetTile(j, i));
                }
                DrawLine(line.ToArray());
            }
        }

        private void DrawLine(LandsTile[] tiles, string spacing = "") {
            DrawUpper(tiles, spacing);
            Console.WriteLine();
            DrawMiddle(tiles, spacing);
            Console.WriteLine();
            DrawLower(tiles, spacing);
            Console.WriteLine();
        }
        private void DrawUpper(LandsTile[] tiles, string spacing) {
            foreach (LandsTile tile in tiles) {
                Console.Write(' ');
                DrawPiece((LandsPiece) tile.Pieces[0]);
                Console.Write(' ');
                if (tile != tiles[^1]) {
                    Console.Write(spacing);
                }
            }
        }

        private void DrawMiddle(LandsTile[] tiles, string spacing) {
            foreach (LandsTile tile in tiles) {
                DrawPiece((LandsPiece) tile.Pieces[1]);
                DrawPiece((LandsPiece) tile.Pieces[2]);
                DrawPiece((LandsPiece) tile.Pieces[3]);
                if (tile != tiles[^1]) {
                    Console.Write(spacing);
                }
            }
        }

        private void DrawLower(LandsTile[] tiles, string spacing) {
            foreach (LandsTile tile in tiles) {
                Console.Write(' ');
                DrawPiece((LandsPiece) tile.Pieces[4]);
                Console.Write(' ');
                if (tile != tiles[^1]) {
                    Console.Write(spacing);
                }
            }
        }

        private void DrawPiece(LandsPiece landsPiece) {
            ConsoleColor oldColor = Console.BackgroundColor;
            if (landsPiece.meeple != null) {
                Console.BackgroundColor = landsPiece.meeple.owner.consoleColor;
            }
            Console.Write(PieceCode(landsPiece));
            Console.BackgroundColor = oldColor;
        }

        private char PieceCode(LandsPiece landsPiece) {
            return landsPiece.type switch {
                PieceType.Road => 'R',
                PieceType.Grass => 'G',
                PieceType.City => 'C',
                _ => 'X',
            };
        }

        private int GetInt(string query, int min, int max) {
            try {
                Console.WriteLine($"{query} ({min} - {max})");
                int num = int.Parse(Console.ReadLine());
                if (num >= min && num <= max) {
                    return num;
                } else {
                    Console.WriteLine("Something went wrong");
                    return GetInt(query, min, max);
                }
            } catch {
                Console.WriteLine("Something went wrong");
                return GetInt(query, min, max);
            }
        }
    }
}
