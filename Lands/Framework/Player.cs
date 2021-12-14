namespace Framework {
    public abstract class Player {

        protected TurnsMediator turnsMediator;
        protected int id;

        public Player(TurnsMediator turnsMediator, int id) {
            this.turnsMediator = turnsMediator;
            this.id = id;
        }

        public abstract void Move();
    }
}
