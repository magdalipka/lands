namespace Framework {
    public abstract class Player {

        protected TurnsMediator turnsMediator;
        protected int id;

        public string name;

        public Player(TurnsMediator turnsMediator, int id, string name) {
            this.turnsMediator = turnsMediator;
            this.id = id;
            this.name = name;
        }

        public abstract void Move();
    }
}
