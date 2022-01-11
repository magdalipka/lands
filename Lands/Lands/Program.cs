using System;
using System.Linq;

namespace Lands {
    internal class Program {
        
        static void Main(string[] args) {
            LandsCreator landsCreator = new LandsCreator();

            ConsoleColor[] colors = (ConsoleColor[]) Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>()
                .Where(x => x != ConsoleColor.Black && x != ConsoleColor.White)
                .ToArray();
            int maxPlayers = colors.Length;
            int players = GetPlayers(maxPlayers);
            for (int i = 0; i < players; ++i) {
                Console.WriteLine($"Player {i + 1} name:");
                landsCreator.AddPlayer(Console.ReadLine(), colors[i]);
            }
            landsCreator.SetBoard(5, 5);

            Lands game = landsCreator.Build();

        }

        private static int GetPlayers(int maxPlayers) {
            try {
                Console.WriteLine($"How many players are playing? (2 - {maxPlayers})");
                int players = int.Parse(Console.ReadLine());
                if (players >= 2 && players <= maxPlayers) {
                    return players;
                } else {
                    Console.WriteLine("Something went wrong");
                    return GetPlayers(maxPlayers);
                }
            } catch {
                Console.WriteLine("Something went wrong");
                return GetPlayers(maxPlayers);
            }
        }

    }
}
