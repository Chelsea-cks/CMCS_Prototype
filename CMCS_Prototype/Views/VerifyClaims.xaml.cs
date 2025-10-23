using System.Windows;
<<<<<<< HEAD
using Assignment_part_2.Models;
using Assignment_part_2.Logic;


namespace Assignment_part_2.Views
=======
using CMCS_Prototype.Models;
using CMCS_Prototype.Logic;

namespace CMCS_Prototype.Views
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
{
    public partial class VerifyClaims : Window
    {
        private readonly ClaimService _claimService;

        public VerifyClaims()
        {
            InitializeComponent();
            _claimService = new ClaimService();
            LoadClaims();
        }

        private void LoadClaims()
        {
            ClaimsDataGrid.ItemsSource = null;
            ClaimsDataGrid.ItemsSource = _claimService.GetAllClaims();
        }

        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsDataGrid.SelectedItem is Claim selected)
            {
                _claimService.ApproveClaim(selected.Id);
                LoadClaims();
                MessageBox.Show($"Claim by {selected.LecturerName} approved.", "Approved", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a claim to approve.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RejectClaim_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsDataGrid.SelectedItem is Claim selected)
            {
                _claimService.RejectClaim(selected.Id);
                LoadClaims();
                MessageBox.Show($"Claim by {selected.LecturerName} rejected.", "Rejected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Please select a claim to reject.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new LoginWindow();
            dashboard.Show();
            this.Close();
        }
    }
}
