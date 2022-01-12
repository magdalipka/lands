using Lands.UserInterfaces;

namespace Lands {
    internal class Program {
        
        static void Main(string[] args) {
            IUserInterface userInterface = UserInterfaceFactoryMethod.CreateUserInterface("console");
            new Lands(userInterface.GetBoardWidth(), userInterface.GetBoardHeight(), userInterface.GetPlayersData(), userInterface);
        }
    }
}
