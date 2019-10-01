using airport_simulator_2019.Engine;
using airport_simulator_2019.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace airport_simulator_2019
{
    public partial class TransferAirplaneDialog : Window
    {
        public TransferAirplaneDialog(IEnumerable<City> cities)
        {
            InitializeComponent();

            CitiesComboBox.ItemsSource = cities;
            CitiesComboBox.SelectedItem = cities.FirstOrDefault();

            var now = Game.GetInstance().Time;
            DateComboBox.SelectedDate = now;
            HoursText.Text = now.Hour.ToString();
            MinutesText.Text = now.Minute.ToString();

        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
