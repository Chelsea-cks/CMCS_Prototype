using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment_part_2.Models;
using Assignment_part_2.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment_part_2.Logic
{
    public class ClaimService
    {
        private readonly ClaimDbContext _context;

        public ClaimService()
        {
            _context = new ClaimDbContext();
            _context.Database.EnsureCreated(); //  DB is created
        }

        // Get all claims safely, avoiding NULL errors
        public List<Claim> GetAllClaims()
        {
            return _context.Claims
                           .AsNoTracking()
                           .Select(c => new Claim
                           {
                               Id = c.Id,
                               ClaimName = c.ClaimName ?? "",
                               LecturerName = c.LecturerName ?? "",
                               Description = c.Description ?? "",
                               HoursWorked = c.HoursWorked,
                               HourlyRate = c.HourlyRate,
                               Status = c.Status ?? "Pending",
                               SubmittedOn = c.SubmittedOn,
                               Notes = c.Notes ?? "",
                               SupportingDocumentPath = c.SupportingDocumentPath ?? ""
                           })
                           .ToList();
        }

        // Add a claim
        public void AddClaim(Claim claim)
        {
            if (claim != null)
            {
                claim.Id = Guid.NewGuid();
                claim.Status = "Pending";
                claim.SubmittedOn = DateTime.UtcNow;

                _context.Claims.Add(claim);
                _context.SaveChanges();
            }
        }

        // Approve a claim
        public void ApproveClaim(Guid id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
        }

        // Reject a claim
        public void RejectClaim(Guid id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();
            }
        }

        // File upload validation
        public string ValidateAndSaveFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new FileNotFoundException("File does not exist.");

            string[] allowedExtensions = { ".pdf", ".docx", ".xlsx" };
            string ext = Path.GetExtension(filePath).ToLower();
            if (!allowedExtensions.Contains(ext))
                throw new InvalidOperationException("Only PDF, DOCX, or XLSX files are allowed.");

            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string destPath = Path.Combine(folder, Path.GetFileName(filePath));
            File.Copy(filePath, destPath, true);

            return destPath;
        }
    }
}
