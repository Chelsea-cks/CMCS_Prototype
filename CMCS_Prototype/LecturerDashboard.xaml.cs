using System;
using System.Windows;

namespace CMCS_Prototype
{
  
    public partial class LecturerDashboard : Window
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void CoordinatorButton_Click(object sender, RoutedEventArgs e)
        {
            CoordinatorDashboard cd = new CoordinatorDashboard();
            cd.Show();
            this.Close();
        }
    }
}
