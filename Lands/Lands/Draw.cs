using Framework;
using System;
using System.Collections.Generic;
using static Lands.LandsPiece;

namespace Lands {
    internal class Draw {
        
        //(x,y)

        //(0,0)(1,0)
        //(0,1)(1,2)
        //(0,2)(1,2)

        public static void DrawBoard(Board board) {
            for (int i = 0; i < board.GetHeight(); ++i) {
                List<LandsTile> line = new List<LandsTile>();
                for (int j = 0; j < board.GetWidth(); ++j) {
                    line.Add((LandsTile) board.GetTile(j, i));
                }
                DrawLine(line.ToArray());
            }
        }

        private static void DrawLine(LandsTile[] tiles) {
            DrawUpper(tiles);
            Console.WriteLine();
            DrawMiddle(tiles);
            Console.WriteLine();
            DrawLower(tiles);
            Console.WriteLine();
        }

        private static void DrawUpper(LandsTile[] tiles) {
            foreach (LandsTile tile in tiles) {
                Console.Write(' ');
                DrawPiece((LandsPiece) tile.Pieces[0]);
                Console.Write(' ');
            }
        }

        private static void DrawMiddle(LandsTile[] tiles) {
            foreach (LandsTile tile in tiles) {
                DrawPiece((LandsPiece) tile.Pieces[1]);
                DrawPiece((LandsPiece) tile.Pieces[2]);
                DrawPiece((LandsPiece) tile.Pieces[3]);
            }
        }

        private static void DrawLower(LandsTile[] tiles) {
            foreach (LandsTile tile in tiles) {
                Console.Write(' ');
                DrawPiece((LandsPiece)tile.Pieces[4]);
                Console.Write(' ');
            }
        }

        private static void DrawPiece(LandsPiece landsPiece) {
            ConsoleColor oldColor = Console.BackgroundColor;
            if (landsPiece.meeple != null) {
                Console.BackgroundColor = landsPiece.meeple.owner.consoleColor;
            }
            Console.Write(PieceCode(landsPiece));
            Console.BackgroundColor = oldColor;
        }

        private static char PieceCode(LandsPiece landsPiece) {
            return landsPiece.type switch {
                PieceType.Road => 'R',
                PieceType.Grass => 'G',
                PieceType.City => 'C',
                _ => 'X',
            };
        }
    }
}
