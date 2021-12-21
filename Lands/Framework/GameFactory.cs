using System;
using System.Collections.Generic;
using System.Text.Json;
// using Framework;

namespace Framework {
    public abstract class GameFactory {

      private List<Player> players;
      private List<Tile> tiles;
      private (int, int) boardSize;
      private TurnsMediator turnsMediator;

      GameFactory() {
        this.players = new List<Player>();
        this.tiles = new List<Tile>();
        this.boardSize = (0, 0);
        this.turnsMediator = null;
      }

      public GameFactory addPlayer(Player player) {
        this.players.Add(player);
        return this;
      }

      public GameFactory addPlayer(IEnumerable<Player> players) {
        this.players.AddRange(players);
        return this;
      }

      public GameFactory addTile(Tile tile) {
        this.tiles.Add(tile);
        return this;
      }

      public GameFactory addTile(IEnumerable<Tile> tiles) {
        this.tiles.AddRange(tiles);
        return this;
      }

      public GameFactory declareTurnsMediator(TurnsMediator turnsMediator) {
        if(this.turnsMediator != null) {
          throw new System.Exception("Turns mediator already declared.");
        }
        this.turnsMediator = turnsMediator;
        return this;
      } 

      private void DefaultTurnsHandler(int id, string content) {
        Console.WriteLine($"{id}: {content}");
      }

      public Game createGame() {
        Game game = new Game();

        if(this.players.Count == 0) {
          throw new System.Exception("No players in game.");
        }
        if(this.boardSize.Item1 == 0 || this.boardSize.Item2 == 0) {
          throw new System.Exception("Board must be at least one by one size.");
        }
        if(this.turnsMediator == null) {
          this.turnsMediator = new DefaultTurnsMediator(DefaultTurnsHandler);
        }

        game.Players = this.players;
        this.players.ForEach(player => this.turnsMediator.AddPlayer(player) );
        
        game.Board = new Board(this.boardSize.Item1, this.boardSize.Item2);

        game.Board.tiles = this.tiles;

        return game;
      }

    }
}
