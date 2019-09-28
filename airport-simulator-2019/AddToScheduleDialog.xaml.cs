using System.Windows;

namespace airport_simulator_2019
{
    public partial class AddToScheduleDialog : Window
    {
        public AddToScheduleDialog()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
