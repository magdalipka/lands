using Framework;
using System;
using System.Collections.Generic;
using static Lands.LandsPiece;

namespace Lands {
    internal class Lands : Game {

        internal List<LandsTile> availableTiles = new List<LandsTile>() {
            new LandsTile(PieceType.Road, PieceType.Road, PieceType.Road, PieceType.Grass, PieceType.Grass), //-'
            new LandsTile(PieceType.Road, PieceType.City, PieceType.Road, PieceType.Road, PieceType.Grass), //'-
            new LandsTile(PieceType.City, PieceType.Grass, PieceType.Road, PieceType.Road, PieceType.Road), //,-
            new LandsTile(PieceType.Grass, PieceType.Road, PieceType.Road, PieceType.Grass, PieceType.Road) //-,
        };

        private readonly LandsTile blank = new LandsTile(PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank, PieceType.Blank);

        internal Lands() { 
            this.turnsMediator = new DefaultTurnsMediator(Handler);
            this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, 0, "Player1", ConsoleColor.Red));
            this.turnsMediator.AddPlayer(new LandsPlayer(this.turnsMediator, 1, "Player2", ConsoleColor.Green));
            this.Board = new Board(2, 2);
            for (int i = 0; i < Board.GetHeight() * Board.GetWidth(); ++i) {
                Board.SetTile(blank, i);
            }
            Draw.DrawBoard(Board);
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
            Draw.DrawBoard(Board);
        }
    }
}
