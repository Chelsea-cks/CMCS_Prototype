using System.Configuration;
using System.Data;
using System.Windows;

namespace CMCS_Prototype
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Start with Lecturer Dashboard
            LecturerDashboard lecturerDashboard = new LecturerDashboard();
            lecturerDashboard.Show();
        }
    }

}
