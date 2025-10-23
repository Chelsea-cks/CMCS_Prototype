<<<<<<< HEAD
﻿using Assignment_part_2.Logic;
using Assignment_part_2.Models;
using Microsoft.Win32;
using System;
using System.Windows;

namespace Assignment_part_2.Views
=======
﻿using System;
using System.Windows;
using Microsoft.Win32;
using CMCS_Prototype.Models;
using CMCS_Prototype.Logic;

namespace CMCS_Prototype.Views
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
{
    public partial class ClaimForm : Window
    {
        private readonly ClaimService _claimService;

        public ClaimForm()
        {
            InitializeComponent();
            _claimService = new ClaimService();
        }

        private void UploadBtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Documents (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx"
            };

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    var savedPath = _claimService.ValidateAndSaveFile(dlg.FileName);
                    FileNameDisplay.Text = System.IO.Path.GetFileName(savedPath);
<<<<<<< HEAD
=======
                    // store on temporary backing field or in Claim object when submit
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
                    FileNameDisplay.Tag = savedPath; // store the saved full path
                }
                catch (Exception ex)
                {
<<<<<<< HEAD
                    MessageBox.Show(ex.Message, "Upload Error", MessageBoxButton.OK, MessageBoxImage.Error);
=======
                    MessageBox.Show(ex.Message, "Upload error", MessageBoxButton.OK, MessageBoxImage.Error);
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
                }
            }
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
<<<<<<< HEAD
                // Validation
                if (string.IsNullOrWhiteSpace(LecturerNameBox.Text) ||
                    string.IsNullOrWhiteSpace(ClaimNameBox.Text) ||
                    string.IsNullOrWhiteSpace(HoursWorkedBox.Text) ||
                    string.IsNullOrWhiteSpace(HourlyRateBox.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create Claim
                var claim = new Claim
                {
                    LecturerName = LecturerNameBox.Text,
                    ClaimName = ClaimNameBox.Text,
=======
                var claim = new Claim
                {
                    LecturerName = LecturerNameBox.Text,
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
                    HoursWorked = double.Parse(HoursWorkedBox.Text),
                    HourlyRate = double.Parse(HourlyRateBox.Text),
                    Notes = NotesBox.Text,
                    SupportingDocumentPath = FileNameDisplay.Tag as string ?? string.Empty,
                    Status = "Pending",
                    SubmittedOn = DateTime.UtcNow
                };

<<<<<<< HEAD
                // Save to database
=======
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
                _claimService.AddClaim(claim);

                MessageBox.Show($"Claim for {claim.LecturerName} submitted successfully!\nTotal: R{claim.TotalAmount}",
                                "Success", MessageBoxButton.OK, MessageBoxImage.Information);

<<<<<<< HEAD
                // Clear form
                LecturerNameBox.Clear();
                ClaimNameBox.Clear();
=======
                // clear
                LecturerNameBox.Clear();
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
                HoursWorkedBox.Clear();
                HourlyRateBox.Clear();
                NotesBox.Clear();
                FileNameDisplay.Text = "No file selected";
                FileNameDisplay.Tag = null;
            }
            catch (FormatException)
            {
<<<<<<< HEAD
                MessageBox.Show("Please enter valid numeric values for hours and rate.", "Validation Error",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
=======
                MessageBox.Show("Please enter valid numeric values for hours and rate.", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new LecturerDashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
