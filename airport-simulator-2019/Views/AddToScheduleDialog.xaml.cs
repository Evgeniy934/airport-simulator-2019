using airport_simulator_2019.GameObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace airport_simulator_2019
{
    public partial class AddToScheduleDialog : Window
    {
        public AddToScheduleDialog(List<Airplane> airplanes)
        {
            InitializeComponent();

            AirplaneComboBox.ItemsSource = airplanes;
            AirplaneComboBox.SelectedItem = airplanes.FirstOrDefault();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
