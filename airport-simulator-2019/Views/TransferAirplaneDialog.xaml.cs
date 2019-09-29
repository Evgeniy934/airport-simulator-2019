using System.Windows;

namespace airport_simulator_2019
{
    public partial class TransferAirplaneDialog : Window
    {
        public TransferAirplaneDialog()
        {
            InitializeComponent();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
