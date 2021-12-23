namespace Framework {
    public interface TurnsMediator {

        public void AddPlayer(Player player);

        public void Start();

        public void Notify(int id, string content);
    }
}
