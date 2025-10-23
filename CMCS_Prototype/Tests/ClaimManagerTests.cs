using System;
using System.Linq;
using Assignment_part_2.Models;
using Assignment_part_2.Logic;
using Xunit;

namespace Assignment_part_2.Tests
{
    public class ClaimManagerTests
    {
        [Fact]
        public void AddClaim_ShouldIncreaseClaimCount()
        {
            var initialCount = ClaimManager.Claims.Count;

            var newClaim = new Claim
            {
                LecturerName = "Test Lecturer",
                ClaimName = "Test Claim",
                Description = "Testing",
                HoursWorked = 2,
                HourlyRate = 100
            };

            ClaimManager.AddClaim(newClaim);

            Assert.Equal(initialCount + 1, ClaimManager.Claims.Count);
        }

        [Fact]
        public void ApproveClaim_ShouldSetStatusApproved()
        {
            var claim = new Claim { LecturerName = "Dr Test", ClaimName = "Approve Test" };
            ClaimManager.AddClaim(claim);

            ClaimManager.ApproveClaim(claim.Id);

            var updatedClaim = ClaimManager.Claims.First(c => c.Id == claim.Id);
            Assert.Equal("Approved", updatedClaim.Status);
        }

        [Fact]
        public void RejectClaim_ShouldSetStatusRejected()
        {
            var claim = new Claim { LecturerName = "Dr Test", ClaimName = "Reject Test" };
            ClaimManager.AddClaim(claim);

            ClaimManager.RejectClaim(claim.Id);

            var updatedClaim = ClaimManager.Claims.First(c => c.Id == claim.Id);
            Assert.Equal("Rejected", updatedClaim.Status);
        }
    }
}
