using Framework;
using System;
using System.Collections.Generic;
using static Lands.LandsPiece;

namespace Lands {
    internal class Lands : Game {

        private List<LandsTile> availableTiles = new List<LandsTile>() {
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
            Board.SetTile(availableTiles[2], 0);
            Board.SetTile(availableTiles[3], 1);
            Board.SetTile(availableTiles[1], 2);
            Board.SetTile(availableTiles[0], 3);
            Draw.DrawBoard(Board);
            this.turnsMediator.Start();
        }

        private void Handler(int id, string content) {
            Console.WriteLine($"{id}: {content}");
        }
    }
}
