using airport_simulator_2019.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace airport_simulator_2019.Engine
{
    public static class DateTimeExtensions
    {
        public static bool EqualsUpToMinutes(this DateTime dt1, DateTime dt2)
        {
            return dt1.Year == dt2.Year && dt1.Month == dt2.Month && dt1.Day == dt2.Day &&
                   dt1.Hour == dt2.Hour && dt1.Minute == dt2.Minute;
        }
    }

    public class Game
    {
        private static readonly Game _instance = new Game();
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private bool _pause;

        public DateTime Time { get; private set; }
        public int GameSpeed { get; set; }
        public Player Player { get; private set; }
        public Shop Shop { get; private set; }
        public FlightBoard FlightBoard { get; private set; }
        
        public Action Tick;
        public Action NoMoney;
        public Action GameOver;

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

            FlightBoard = new FlightBoard();
            Player = new Player();
            Shop = new Shop();

            _timer.Tick += new EventHandler(OnTick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        public void RegisterObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public void Pause() => _pause = true;

        public void Unpause() => _pause = false;

        private void OnTick(object sender, EventArgs e)
        {
            if (_pause)
            {
                return;
            }

            int seconds = (int)Math.Pow(60.0, GameSpeed);
            if (GameSpeed > 2)
            {
                seconds = (int) TimeSpan.FromDays(1).TotalSeconds;
            }

            for (int i = 0; i < seconds; i++)
            {
                if (Time.Second == 0)
                {
                    for (int j = _gameObjects.Count - 1; j >= 0; j--)
                    {
                        _gameObjects[j].OnMinute();
                    }
                }

                if (Time.Hour == 0 && Time.Minute == 0 && Time.Second == 0)
                {
                    for (int j = _gameObjects.Count - 1; j >= 0; j--)
                    {
                        _gameObjects[j].OnDayBegin();
                    }
                    OnDayBegin();
                }

                Time = Time.AddSeconds(1);
            }

            Tick?.Invoke();
        }

        private void OnDayBegin()
        {
            if (Player.Balance < 0)
            {
                if (Player.Airplanes.Count == 0)
                {
                    GameOver?.Invoke();
                }
                else
                {
                    NoMoney?.Invoke();
                }
            }
        }
    }
}
