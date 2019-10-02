using airport_simulator_2019.Engine;
using airport_simulator_2019.GameObjects;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

            MyAirplanesGrid.ItemsSource = _game.Player.Airplanes;
            ShopDataGrid.ItemsSource = _game.Shop.Airplanes;
            FlightBoardGrid.ItemsSource = _game.FlightBoard.Flights;
            MyFlighsGrid.ItemsSource = _game.Player.Flights;
            ScheduleGrid.ItemsSource = _game.Player.Schedule.Flights;

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
                return;
            }
            if (airplane.InRent)
            {
                MessageBox.Show("Нельзя продать арендованный самолет!");
                return;
            }
            if (airplane.InFly)
            {
                MessageBox.Show("Нельзя продать летящий самолет!");
                return;
            }

            switch (MessageBox.Show("Вы уверены, что хотите продать этот самолет?", "Подтверждение продажи", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    _game.Player.SaleAirplane(airplane);
                    UpdateUI();
                    break;
            }
        }

        private void RentAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = (Airplane)ShopDataGrid.SelectedItem;
            if (airplane != null)
            {
                _game.Pause();
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
                _game.Unpause();
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
                        break;
                }
            }
        }

        private void AddToSchedule_Click(object sender, RoutedEventArgs e)
        {
            Flight flight = (Flight)MyFlighsGrid.SelectedItem;
            if (flight != null && !flight.InFly)
            {
                _game.Pause();

                var dialog = new AddToScheduleDialog(_game.Player.Airplanes);
                if ((bool)dialog.ShowDialog())
                {
                    DateTime? date = dialog.DateComboBox.SelectedDate;
                    Airplane airplane = (Airplane) dialog.AirplaneComboBox.SelectedItem;
                    if (date.HasValue && airplane != null)
                    {
                        var hours = int.Parse(dialog.HoursText.Text);
                        var minutes = int.Parse(dialog.MinutesText.Text);
                        date += new TimeSpan(hours, minutes, 0);

                        _game.Player.ScheduleFlight(flight, airplane, date.Value);

                        UpdateUI();
                    }
                }
                _game.Unpause();
            }
        }

        private void RemoveFromSchedule_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Вы уверены, что хотите удалить этот рейс из расписания?", "Подтверждение удаления рейса", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    break;
            }
        }

        private void RefuseFlight_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Вы уверены, что хотите отказаться от этого рейса?", "Подтверждение отказа от рейса", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    break;
            }
        }

        private void TransferAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = (Airplane)MyAirplanesGrid.SelectedItem;
            if (airplane != null)
            {
                _game.Pause();

                var dialog = new TransferAirplaneDialog(
                    CityCatalog.Cities.Where(x => x != _game.Player.HomeCity));
                if ((bool)dialog.ShowDialog())
                {
                    City city = (City) dialog.CitiesComboBox.SelectedItem;
                    DateTime? date = dialog.DateComboBox.SelectedDate;
                    if (city != null && date.HasValue)
                    {
                        var hours = int.Parse(dialog.HoursText.Text);
                        var minutes = int.Parse(dialog.MinutesText.Text);
                        date += new TimeSpan(hours, minutes, 0);

                        _game.Player.TransferAirplane(airplane, city, date.Value);

                        UpdateUI();
                    }
                }
                _game.Unpause();
            }
        }

        private void OnTick()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            Balance.Text = $"Бюджет Аэропорта: {_game.Player.Balance} руб.";
            CurrentTime.Text = $"{_game.Time:dd.MM.yyyy HH:mm:ss}";
        }

        private void OnDayBegin()
        {
        }
    }
}
