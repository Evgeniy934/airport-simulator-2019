using airport_simulator_2019.Engine;
using airport_simulator_2019.GameObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace airport_simulator_2019
{
    public partial class AddToScheduleDialog : Window
    {
        public AddToScheduleDialog(IEnumerable<Airplane> airplanes)
        {
            InitializeComponent();

            AirplaneComboBox.ItemsSource = airplanes;
            AirplaneComboBox.SelectedItem = airplanes.FirstOrDefault();

            var now = Game.GetInstance().Time;
            DateComboBox.SelectedDate = now;
            DateComboBox.DisplayDateStart = now;
            HoursText.Text = $"{now.Hour}";
            MinutesText.Text = $"{now.Minute + 1}";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
