using System.Windows;

<<<<<<< HEAD
namespace Assignment_part_2.Views
=======
namespace CMCS_Prototype.Views
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            var loginWindow = new LoginWindow();
            loginWindow.Show();
=======
            var login = new LoginWindow();
            login.Show();
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
            this.Close();
        }
    }
}
