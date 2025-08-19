using System;
<<<<<<< HEAD

namespace Assignment_part_2.Models
{
    public class Claim
    {
        public Guid Id { get; set; }
        public string LecturerName { get; set; } = string.Empty;
        public string ClaimName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double HoursWorked { get; set; }        
        public double HourlyRate { get; set; }         
        public string Status { get; set; } = "Pending";
        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; } = string.Empty;
        public string SupportingDocumentPath { get; set; } = string.Empty;
        public double TotalAmount => HoursWorked * HourlyRate;
=======
using System.ComponentModel;

namespace CMCS_Prototype.Models
{
    public class Claim : INotifyPropertyChanged
    {
        public Guid Id { get; } = Guid.NewGuid();

        private string _lecturerName = string.Empty;
        public string LecturerName
        {
            get => _lecturerName;
            set { _lecturerName = value; OnPropertyChanged(nameof(LecturerName)); }
        }

        private string _claimName = string.Empty;
        public string ClaimName
        {
            get => _claimName;
            set { _claimName = value; OnPropertyChanged(nameof(ClaimName)); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        private string _supportingDocumentPath = string.Empty;
        public string SupportingDocumentPath
        {
            get => _supportingDocumentPath;
            set { _supportingDocumentPath = value; OnPropertyChanged(nameof(SupportingDocumentPath)); }
        }

        private double _hoursWorked;
        public double HoursWorked
        {
            get => _hoursWorked;
            set { _hoursWorked = value; OnPropertyChanged(nameof(HoursWorked)); OnPropertyChanged(nameof(TotalAmount)); }
        }

        private double _hourlyRate;
        public double HourlyRate
        {
            get => _hourlyRate;
            set { _hourlyRate = value; OnPropertyChanged(nameof(HourlyRate)); OnPropertyChanged(nameof(TotalAmount)); }
        }

        public double TotalAmount => Math.Round(HoursWorked * HourlyRate, 2);

        private string _notes = string.Empty;
        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(nameof(Notes)); }
        }

        private string _status = "Pending";
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
    }
}
