using airport_simulator_2019.GameObjects;

namespace airport_simulator_2019.Engine
{
    public class Game
    {
        private static readonly Game _instance = new Game();

        public Player Player { get; private set; }
        public Shop Shop { get; private set; }

        private Game()
        {
        }


        public static Game GetInstance()
        {
            return _instance;
        }

        public void Run()
        {
            Player = new Player();
            Shop = new Shop();
        }
    }
}
