using System;
using System.IO;
using System.Linq;
using Assignment_part_2.Models;
using Assignment_part_2.Logic;
using Xunit;

namespace Assignment_part_2.Tests
{
    public class ClaimServiceTests
    {
        private readonly ClaimService _service;

        public ClaimServiceTests()
        {
            _service = new ClaimService();
        }

        [Fact]
        public void AddClaim_ShouldIncreaseClaimCount()
        {
            var initialCount = _service.GetAllClaims().Count;

            var newClaim = new Claim
            {
                LecturerName = "Test Lecturer",
                ClaimName = "Test Claim",
                Description = "Testing",
                HoursWorked = 2,
                HourlyRate = 100
            };

            _service.AddClaim(newClaim);

            var finalCount = _service.GetAllClaims().Count;
            Assert.Equal(initialCount + 1, finalCount);
        }

        [Fact]
        public void ApproveClaim_ShouldSetStatusApproved()
        {
            var claim = new Claim { LecturerName = "Dr Test", ClaimName = "Approve Test" };
            _service.AddClaim(claim);

            _service.ApproveClaim(claim.Id);

            var updatedClaim = _service.GetAllClaims().First(c => c.Id == claim.Id);
            Assert.Equal("Approved", updatedClaim.Status);
        }

        [Fact]
        public void RejectClaim_ShouldSetStatusRejected()
        {
            var claim = new Claim { LecturerName = "Dr Test", ClaimName = "Reject Test" };
            _service.AddClaim(claim);

            _service.RejectClaim(claim.Id);

            var updatedClaim = _service.GetAllClaims().First(c => c.Id == claim.Id);
            Assert.Equal("Rejected", updatedClaim.Status);
        }

        [Fact]
        public void ValidateAndSaveFile_ShouldCopyFile()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "test.pdf");
            File.WriteAllText(tempFile, "Test content");

            string savedPath = _service.ValidateAndSaveFile(tempFile);

            Assert.True(File.Exists(savedPath));

            File.Delete(tempFile);
            File.Delete(savedPath);
        }

        [Fact]
        public void ValidateAndSaveFile_InvalidExtension_ShouldThrow()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "test.txt");
            File.WriteAllText(tempFile, "Test content");

            Assert.Throws<InvalidOperationException>(() => _service.ValidateAndSaveFile(tempFile));

            File.Delete(tempFile);
        }
    }
}
