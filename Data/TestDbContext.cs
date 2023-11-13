using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Test_Case_API.Models.Entities;

namespace Test_Case_API.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
