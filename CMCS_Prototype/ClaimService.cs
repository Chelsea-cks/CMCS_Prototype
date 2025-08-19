using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CMCS_Prototype.Models;

namespace CMCS_Prototype.Logic
{
    public class ClaimService
    {
        private readonly List<Claim> _claims;

        public ClaimService()
        {
            _claims = new List<Claim>
            {
                new Claim { LecturerName = "Dr. Smith", ClaimName = "Travel Reimbursement", Description="Travel to conference", HoursWorked=5, HourlyRate=200, Status="Pending" },
                new Claim { LecturerName = "Prof. Jones", ClaimName = "Overtime Payment", Description="Extra lab hours", HoursWorked=3, HourlyRate=150, Status="Pending" }
            };
        }

        public List<Claim> GetAllClaims()
        {
            return _claims;
        }

        public void ApproveClaim(Guid id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim != null) claim.Status = "Approved";
        }

        public void RejectClaim(Guid id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim != null) claim.Status = "Rejected";
        }

        public void AddClaim(Claim claim)
        {
            if (claim != null)
            {
                _claims.Add(claim);
            }
        }
        public string ValidateAndSaveFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new FileNotFoundException("File does not exist.");

            var allowedExtensions = new[] { ".pdf", ".docx" };
            var ext = Path.GetExtension(filePath).ToLower();
            if (!allowedExtensions.Contains(ext))
                throw new InvalidOperationException("Only PDF and DOCX files are allowed.");

            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string destPath = Path.Combine(folder, Path.GetFileName(filePath));
            File.Copy(filePath, destPath, true);

            return destPath; 
        }
    }
}
