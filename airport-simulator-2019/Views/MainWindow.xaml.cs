using airport_simulator_2019.Engine;
using airport_simulator_2019.GameObjects;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace airport_simulator_2019
{
    public partial class MainWindow : Window
    {
        private Game _game = Game.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
            _game.Run();

            _game.Tick = OnTick;
            _game.DayBegin = OnDayBegin;

            UpdateUI();
        }

        private void RealTime_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = false;
            Fast.IsEnabled = true;
            VeryFast.IsEnabled = true;

            _game.GameSpeed = 0;
        }

        private void Fast_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = true;
            Fast.IsEnabled = false;
            VeryFast.IsEnabled = true;

            _game.GameSpeed = 1;
        }

        private void VeryFast_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = true;
            Fast.IsEnabled = true;
            VeryFast.IsEnabled = false;

            _game.GameSpeed = 2;
        }

        private void BuyAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = (Airplane)ShopDataGrid.SelectedItem;
            if (airplane == null)
            {
                MessageBox.Show("Выберете самолет!");
            }
            else
            {
                switch (MessageBox.Show("Вы уверены, что хотите выкупить этот самолет?", "Подтверждение покупки", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        _game.Player.BuyAirplane(airplane);
                        UpdateUI();
                        break;
                }
            }
        }

        private void SellAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = (Airplane)MyAirplanesGrid.SelectedItem;
            if (airplane == null)
            {
                MessageBox.Show("Выберете самолет!");
            } else
            { if (airplane.RentDays != -1)
                {
                    MessageBox.Show("Нельзя продать арендованный самолет!");
                }
                else
                {
                    switch (MessageBox.Show("Вы уверены, что хотите продать этот самолет?", "Подтверждение продажи", MessageBoxButton.YesNo))
                    {
                        case MessageBoxResult.Yes:
                            _game.Player.SaleAirplane(airplane);
                            UpdateUI();
                            break;

                    }
                }
            }
        }

        private void RentAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = (Airplane)ShopDataGrid.SelectedItem;
            if (airplane != null)
            {
                var dialog = new RentAirplaneDialog(_game, airplane.PriceRent);
                if ((bool)dialog.ShowDialog())
                {
                    DateTime? dateEnd = dialog.RentDateSelect.SelectedDate;
                    if (dateEnd.HasValue)
                    {
                        _game.Player.RentAirplane(airplane, dateEnd.Value);
                        UpdateUI();
                    }
                }
            }
        }

        private void TakeFlight_Click(object sender, RoutedEventArgs e)
        {
            Flight flight = (Flight)FlightBoardGrid.SelectedItem;
            if (flight != null)
            {
                switch (MessageBox.Show("Вы уверены, что хотите взять этот рейс?", "Подтверждение взятия рейса", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        _game.Player.TakeFromFlightBoard(flight);
                        UpdateUI();
                        MessageBox.Show("Успех");
                        break;
                }
            }
        }

        private void AddToSchedule_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddToScheduleDialog();
            if ((bool)dialog.ShowDialog())
            {
                MessageBox.Show("Успех");
            }
        }

        private void RemoveFromSchedule_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Вы уверены, что хотите удалить этот рейс из расписания?", "Подтверждение удаления рейса", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Успех");
                    break;
            }
        }

        private void RefuseFlight_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Вы уверены, что хотите отказаться от этого рейса?", "Подтверждение отказа от рейса", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Успех");
                    break;
            }
        }

        private void TransferAirplane_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TransferAirplaneDialog();
            if ((bool)dialog.ShowDialog())
            {
                MessageBox.Show("Успех");
            }
        }

        private void UpdateUI()
        {
            ShopDataGrid.Items.Clear();
            foreach (var item in _game.Shop.Airplanes)
            {
                ShopDataGrid.Items.Add(item);
            }

            MyAirplanesGrid.Items.Clear();
            foreach (var item in _game.Player.Airplanes)
            {
                MyAirplanesGrid.Items.Add(item);
            }

            FlightBoardGrid.Items.Clear();
            foreach (var item in _game.FlightBoard.Flights)
            {
                FlightBoardGrid.Items.Add(item);
            }

            MyFlighsGrid.Items.Clear();
            foreach (var item in _game.Player.Flights)
            {
                MyFlighsGrid.Items.Add(item);
            }

            Balance.Text = $"Бюджет Аэропорта: {_game.Player.Balance} руб.";

        }

        private void OnTick()
        {
            UpdateTime();
        }

        private void OnDayBegin()
        {
            UpdateUI();
        }

        private void UpdateTime()
        {
            CurrentTime.Text = $"{_game.Time:dd.MM.yyyy HH:mm:ss}";
        }
    }
}
