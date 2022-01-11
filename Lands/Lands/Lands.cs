using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Lands.LandsPiece;

namespace Lands {
    class Lands : Game {

        internal List<LandsTile> availableTiles = new List<LandsTile>();
        internal readonly LandsTile blank = new LandsTile(PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank);
        internal LandsUserInterface userInterface;

        internal Lands(int boardWidth, int boardHeight, List<PlayerInput> players, LandsUserInterface userInterface) { 
            this.userInterface = userInterface;
            this.turnsMediator = new DefaultTurnsMediator(Handler, IsWon, Won);
            for(int i = 0; i < players.Count; i++) {
                this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, i, players[i].name, players[i].color, userInterface));
            }
            this.Board = new Board(boardWidth, boardHeight);
            for (int i = 0; i < Board.GetHeight() * Board.GetWidth(); ++i) {
                Board.SetTile(blank, i);
            }
            for(int i = 0; i < Board.GetHeight() * Board.GetWidth(); i++) {
                availableTiles.Add(LandsTile.GenerateRandom());
            }
            this.userInterface.DrawRound(this.Board, this.availableTiles);
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
            userInterface.Clear();
            userInterface.DrawRound(this.Board, this.availableTiles);
        }

        private void Won() {
            userInterface.Clear();
            userInterface.DrawRound(this.Board, this.availableTiles);
            List<int> results = turnsMediator.players.Select(x => 0).ToList();
            foreach (LandsTile tile in Board.Tiles) {
                foreach (LandsPiece piece in tile.Pieces) {
                    results[piece.meeple.owner.id] += (int) piece.type;
                }
            }
            userInterface.WriteLine("Results:");
            for (int i = 0; i < results.Count; ++i) { 
                userInterface.WriteLine($"{turnsMediator.players[i].name}: {results[i]}");
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

    }
}

