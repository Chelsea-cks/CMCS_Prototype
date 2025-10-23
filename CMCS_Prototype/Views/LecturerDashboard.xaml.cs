using System.Windows;

namespace Assignment_part_2.Views
{
    public partial class LecturerDashboard : Window
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            var claimForm = new ClaimForm();
            claimForm.Show();
            this.Close();
        }

        private void ViewClaims_Click(object sender, RoutedEventArgs e)
        {
            var verifyClaims = new VerifyClaims();
            verifyClaims.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
