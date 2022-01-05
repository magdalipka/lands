using Framework;
using System;

namespace Lands {

    //meeple:pieceIndex;tileX;tileY;ownerId
    public class PlaceMeeple : Move {
        public PlaceMeeple(Game game) : base(game) { }

        public override void Make(string command) {
            string[] content = command.Split(';');
            int pieceIndex = int.Parse(content[0]);
            int x = int.Parse(content[1]);
            int y = int.Parse(content[2]);
            int ownerId = int.Parse(content[3]);
            if (x >= 0 && x < game.Board.GetWidth() && y >= 0 && y < game.Board.GetHeight()) {
                LandsTile landsTile = (LandsTile) game.Board.GetTile(x, y);
                LandsPiece landsPiece = (LandsPiece) landsTile.Pieces[pieceIndex];
                if (landsPiece.meeple == null) {
                    LandsPiece.PieceType pieceType = landsPiece.type;
                    landsPiece.SetMeeple(new Meeple((LandsPlayer) game.turnsMediator.players[ownerId]));
                    MakeOthers(x, y, pieceIndex, ownerId, pieceType, game.Board);
                }
            }
        }

        public override bool IsPossible(string command) {
            throw new System.NotImplementedException();
        }

        private void MakeOthers(int x, int y, int pieceIndex, int ownerId, LandsPiece.PieceType pieceType, Board board) {
            switch (pieceIndex) {
                case 0:
                    if (CheckPieceType(board, x, y - 1, 4, pieceType)) {
                        Make($"4;{x};{y - 1};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 2, pieceType)) {
                        Make($"2;{x};{y};{ownerId}");
                    }
                    break;
                case 1:
                    if (CheckPieceType(board, x - 1, y, 3, pieceType)) {
                        Make($"3;{x - 1};{y};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 2, pieceType)) {
                        Make($"2;{x};{y};{ownerId}");
                    }
                    break;
                case 2:
                    if (CheckPieceType(board, x, y, 0, pieceType)) {
                        Make($"0;{x};{y};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 1, pieceType)) {
                        Make($"1;{x};{y};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 3, pieceType)) {
                        Make($"3;{x};{y};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 4, pieceType)) {
                        Make($"4;{x};{y};{ownerId}");
                    }
                    break;
                case 3:
                    if (CheckPieceType(board, x + 1, y, 1, pieceType)) {
                        Make($"1;{x + 1};{y};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 2, pieceType)) {
                        Make($"2;{x};{y};{ownerId}");
                    }
                    break;
                case 4:
                    if (CheckPieceType(board, x, y + 1, 0, pieceType)) {
                        Make($"0;{x};{y + 1};{ownerId}");
                    }
                    if (CheckPieceType(board, x, y, 2, pieceType)) {
                        Make($"2;{x};{y};{ownerId}");
                    }
                    break;
            }
        }

        private bool CheckPieceType(Board board, int x, int y, int pieceIndex, LandsPiece.PieceType pieceType) {
            if (x >= 0 && x < board.GetWidth() && y >= 0 && y < board.GetHeight()) {
                LandsTile landsTile = (LandsTile) board.GetTile(x, y);
                LandsPiece landsPiece = (LandsPiece) landsTile.Pieces[pieceIndex];
                if (landsPiece.meeple == null && landsPiece.type == pieceType) {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}