namespace Lands.UserInterfaces {
    internal class UserInterfaceFactoryMethod {
        
        public static IUserInterface CreateUserInterface(string interfaceType) {
            return interfaceType switch {
                "console" => new ConsoleUserInterface(),
                _ => null,
            };
        }
    }
}
