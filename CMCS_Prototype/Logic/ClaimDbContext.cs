using Microsoft.EntityFrameworkCore;
using Assignment_part_2.Models;

namespace Assignment_part_2.Data
{
    public class ClaimDbContext : DbContext
    {
        public DbSet<Claim> Claims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Update connection string to your SQL Server instance
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CMCS_PrototypeDB;Trusted_Connection=True;");
        }
    }
}
