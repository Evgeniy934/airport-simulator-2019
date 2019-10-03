using airport_simulator_2019.Engine;
using airport_simulator_2019.GameObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace airport_simulator_2019
{
    public partial class AddToScheduleDialog : Window
    {
        public AddToScheduleDialog(IEnumerable<Airplane> airplanes, System.DateTime ExpireDate)
        {
            InitializeComponent();

            AirplaneComboBox.ItemsSource = airplanes;
            AirplaneComboBox.SelectedItem = airplanes.FirstOrDefault();
            
            var now = Game.GetInstance().Time;
            DateComboBox.SelectedDate = ExpireDate;
            DateComboBox.DisplayDateStart = ExpireDate;
            HoursText.Text = $"{now.Hour}";
            MinutesText.Text = $"{now.Minute + 1}";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
