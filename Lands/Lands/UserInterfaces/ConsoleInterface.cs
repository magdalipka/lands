using System;
using System.Collections.Generic;
using Framework;
using static Lands.LandsPiece;

namespace Lands {
  internal class ConsoleInterface : LandsUserInterface {
    public void WriteLine(string data) {
      Console.WriteLine(data);
    }

    public void Write(char data) {
      Console.Write(data);
    }

    public void Clear() {
      Console.Clear();
    }

    public string ReadCommand() {
      return Console.ReadLine();
    }

    public void DrawRound(Board board, List<LandsTile> availableTiles) {
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
          DrawPiece((LandsPiece)tile.Pieces[4]);
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
  }
}
