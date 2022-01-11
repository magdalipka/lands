
using System;
using System.Collections.Generic;

namespace Lands {
  class LandsCreator {
    private List<PlayerInput> players = new List<PlayerInput>();
    private int boardWith = 0;
    private int boardHeight = 0;
    private LandsUserInterface userInterface = new ConsoleInterface();

    internal void AddPlayer(string name, ConsoleColor color) {
      PlayerInput input = new PlayerInput(name, color);
      this.players.Add(input);
    }

    internal void SetBoard(int width, int height) {
      this.boardWith = width;
      this.boardHeight = height;
    }

    internal Lands build() {
      return new Lands(this.boardWith, this.boardHeight, this.players, this.userInterface );
    }
  }
}
