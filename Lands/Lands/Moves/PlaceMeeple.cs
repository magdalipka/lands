using Framework;
using System;

namespace Lands {

    //pieceIndex;tileX;tileY;ownerId
    public class PlaceMeeple : Move {
        public PlaceMeeple(Game game) : base(game) {}

        public override void Make(string command) {
            string[] content = command.Split(';');
            Lands lands = (Lands) this.game;
            int pieceIndex = int.Parse(content[0]);
            int x = int.Parse(content[1]);
            int y = int.Parse(content[2]);
            int ownerId = int.Parse(content[3]);
            LandsTile landsTile = (LandsTile) game.Board.GetTile(x, y);
            LandsPiece landsPiece = (LandsPiece) landsTile.Pieces[pieceIndex];
            landsPiece.SetMeeple(new Meeple((LandsPlayer) game.turnsMediator.players[ownerId]));
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }
    }
}