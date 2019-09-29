using airport_simulator_2019.GameObjects;
using System;
using System.Windows.Threading;

namespace airport_simulator_2019.Engine
{
    public class Game
    {
        private static readonly Game _instance = new Game();

        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _currentDay;

        public DateTime Time { get; private set; }
        public int GameSpeed { get; set; }
        public Player Player { get; private set; }
        public Shop Shop { get; private set; }


        public Action Tick;

        private Game()
        {
        }


        public static Game GetInstance()
        {
            return _instance;
        }

        public void Run()
        {
            GameSpeed = 0;
            Time = DateTime.Now;

            Player = new Player();
            Shop = new Shop();

            _timer.Tick += new EventHandler(OnTick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            int seconds = (int)Math.Pow(60.0, GameSpeed);
            Time = Time.AddSeconds(seconds);

            Tick?.Invoke();
        }
    }
}
