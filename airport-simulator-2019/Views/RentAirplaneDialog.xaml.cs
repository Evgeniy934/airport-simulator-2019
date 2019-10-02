using airport_simulator_2019.Engine;
using System.Windows;

namespace airport_simulator_2019
{
    public partial class RentAirplaneDialog : Window
    {
        private Game game;
        private int dailyRent;

        private int GetTotalRent()
        { 
            return ((int)(RentDateSelect.SelectedDate - game.Time)?.TotalDays + 1) * dailyRent;
        }

        public RentAirplaneDialog(Game game, int dailyRent)
        {
            InitializeComponent();
            this.game = game;
            this.dailyRent = dailyRent;

            var now = Game.GetInstance().Time;
            RentDateSelect.SelectedDate = now.AddDays(1);
            RentDateSelect.DisplayDateStart = now.AddDays(1);
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void DateChanged(object sender, RoutedEventArgs e)
        {
            TotalRentPrice.Text = $"Полная стоимость аренды: {GetTotalRent()} руб.";
        }
    }
}
