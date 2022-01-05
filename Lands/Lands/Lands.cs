using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Lands.LandsPiece;

namespace Lands {
    internal class Lands : Game {

        internal List<LandsTile> availableTiles = new List<LandsTile>() {
            new LandsTile(PieceType.Road, PieceType.Road, PieceType.Road, PieceType.Grass, PieceType.Grass), //-'
            new LandsTile(PieceType.Road, PieceType.City, PieceType.Road, PieceType.Road, PieceType.Grass), //'-
            new LandsTile(PieceType.City, PieceType.Grass, PieceType.Road, PieceType.Road, PieceType.Road), //,-
            new LandsTile(PieceType.Grass, PieceType.Road, PieceType.Road, PieceType.Grass, PieceType.Road) //-,
        };

        internal readonly LandsTile blank = new LandsTile(PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank);

        internal Lands() { 
            this.turnsMediator = new DefaultTurnsMediator(Handler, IsWon, Won);
            this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, 0, "Player1", ConsoleColor.Red));
            this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, 1, "Player2", ConsoleColor.Green));
            this.Board = new Board(2, 2);
            for (int i = 0; i < Board.GetHeight() * Board.GetWidth(); ++i) {
                Board.SetTile(blank, i);
            }
            DrawRound();
            this.turnsMediator.Start();
        }

        private void Handler(int id, string content) {
            string[] command = content.Split(':');
            switch (command[0]) {
                case "tile":
                    new PlaceTile(this).Make(command[1]);
                    break;
                case "meeple":
                    new PlaceMeeple(this).Make($"{command[1]};{id}");
                    break;
            }
            Console.Clear();
            DrawRound();
        }

        private void Won() {
            Console.Clear();
            DrawRound();
            List<int> results = turnsMediator.players.Select(x => 0).ToList();
            foreach (LandsTile tile in Board.Tiles) {
                foreach (LandsPiece piece in tile.Pieces) {
                    results[piece.meeple.owner.id] += (int) piece.type;
                }
            }
            Console.WriteLine("Results:");
            for (int i = 0; i < results.Count; ++i) { 
                Console.WriteLine($"{turnsMediator.players[i].name}: {results[i]}");
            }
        }

        private bool IsWon() {
            foreach (LandsTile tile in Board.Tiles) {
                foreach (LandsPiece piece in tile.Pieces) {
                    if (piece.meeple == null) {
                        return false;
                    }
                }
            }
            return true;
        }

        private void DrawRound() {
            Draw.DrawBoard(Board);
            if (availableTiles.Count > 0) {
                Draw.DrawAvailableTiles(availableTiles);
            }
        }
    }
}
