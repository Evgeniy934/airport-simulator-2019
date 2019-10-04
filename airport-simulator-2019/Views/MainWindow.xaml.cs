using airport_simulator_2019.Engine;
using airport_simulator_2019.GameObjects;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace airport_simulator_2019
{
    public partial class MainWindow : Window
    {
        private Game _game = Game.GetInstance();

        CollectionViewSource _scheduleViewSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
            _game.Run();

            _game.Tick = OnTick;
            _game.NoMoney = OnNoMoney;
            _game.GameOver = OnGameOver;

            _scheduleViewSource = new CollectionViewSource();
            _scheduleViewSource.Source = _game.Player.Schedule.Flights;

            _scheduleViewSource.SortDescriptions.Add(new SortDescription("DepartureTime", ListSortDirection.Ascending));


            MyAirplanesGrid.ItemsSource = _game.Player.Airplanes;
            ShopDataGrid.ItemsSource = _game.Shop.Airplanes;
            FlightBoardGrid.ItemsSource = _game.FlightBoard.Flights;
            MyFlighsGrid.ItemsSource = _game.Player.Flights;
            ScheduleGrid.ItemsSource = _scheduleViewSource.View;
        }

        private void RealTime_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = false;
            Fast.IsEnabled = true;
            VeryFast.IsEnabled = true;
            ExtremelyFast.IsEnabled = true;

            _game.GameSpeed = 0;
        }

        private void Fast_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = true;
            Fast.IsEnabled = false;
            VeryFast.IsEnabled = true;
            ExtremelyFast.IsEnabled = true;

            _game.GameSpeed = 1;
        }

        private void VeryFast_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = true;
            Fast.IsEnabled = true;
            VeryFast.IsEnabled = false;
            ExtremelyFast.IsEnabled = true;

            _game.GameSpeed = 2;
        }

        private void ExtremelyFast_Click(object sender, RoutedEventArgs e)
        {
            RealTime.IsEnabled = true;
            Fast.IsEnabled = true;
            VeryFast.IsEnabled = true;
            ExtremelyFast.IsEnabled = false;

            _game.GameSpeed = 3;
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
                    }
                }
                _game.Unpause();
            }
        }

        private void TakeFlight_Click(object sender, RoutedEventArgs e)
        {
            if (_game.Player.Balance < 0)
            {
                ShowBalanceForm();
                return;
            }

            Flight flight = (Flight)FlightBoardGrid.SelectedItem;
            if (flight != null)
            {
                switch (MessageBox.Show("Вы уверены, что хотите взять этот рейс?", "Подтверждение взятия рейса", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        _game.Player.TakeFromFlightBoard(flight);
                        break;
                }
            }
        }

        private void AddToSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (_game.Player.Balance < 0)
            {
                ShowBalanceForm();
                return;
            }

            Flight flight = (Flight)MyFlighsGrid.SelectedItem;
            if (flight != null && !flight.InFly && flight.PlayerHasSuitableAirplane)
            {
                _game.Pause();

                var dialog = new AddToScheduleDialog(_game.Player.Airplanes.Where(a => a.IsAvailableForFlight(flight)), flight);
                if ((bool)dialog.ShowDialog())
                { 
                    DateTime? date = dialog.DateComboBox.SelectedDate;
                    Airplane airplane = (Airplane) dialog.AirplaneComboBox.SelectedItem;

                    if (airplane.Location != flight.DepartureCity)
                    {
                        MessageBox.Show("Требуется перегнать самолет!");
                    }

                    if (date.HasValue && airplane != null)
                    {
                        var hours = int.Parse(dialog.HoursText.Text);
                        var minutes = int.Parse(dialog.MinutesText.Text);
                        date += new TimeSpan(hours, minutes, 0);

                        _game.Player.ScheduleFlight(flight, airplane, date.Value);
                        _scheduleViewSource.View.Refresh();
                    }
                }
                _game.Unpause();
            }
        }

        private void RemoveFromSchedule_Click(object sender, RoutedEventArgs e)
        {
            Flight flight = (Flight)ScheduleGrid.SelectedItem;
            if (flight != null)
            {
                switch (MessageBox.Show("Вы уверены, что хотите удалить этот рейс из расписания?", "Подтверждение удаления рейса", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        _game.Player.RemoveFromSchedule(flight);
                        break;
                }
            }
        }

        private void RefuseFlight_Click(object sender, RoutedEventArgs e)
        {
            Flight flight = (Flight)MyFlighsGrid.SelectedItem;
            if (flight != null)
            {
                switch (MessageBox.Show("Вы уверены, что хотите отказаться от этого рейса?", "Подтверждение отказа от рейса", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        _game.Player.RefuseFlight(flight);
                        break;
                }
            }
        }

        private void TransferAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = (Airplane)MyAirplanesGrid.SelectedItem;
            if (airplane != null)
            {
                _game.Pause();
                
                var dialog = new TransferAirplaneDialog(CityCatalog.Cities.Where(x => airplane.CanFlyTo(x)));
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
                    }
                }
                _game.Unpause();
            }
        }

        private void ShowBalanceForm()
        {
            MessageBox.Show("Пополните баланс чтобы продолжить!");
        }

        private void OnTick()
        {
            Balance.Text = $"Бюджет Аэропорта: {_game.Player.Balance} руб.";
            CurrentTime.Text = $"{_game.Time:dd.MM.yyyy HH:mm:ss}";
        }

        private void OnNoMoney()
        {
            MessageBox.Show("Вы на грани банкротства! Арендодатели забирают свои самолеты обратно. Вам необходимо продать свое имущество (самолеты), чтобы восстановить бюджет");
        }

        private void OnGameOver()
        {
            MessageBox.Show("Вы банкрот! Конец игры!");
            this.Close();
        }
    }
}
