using Microsoft.EntityFrameworkCore;
using NooshApp.Models;

namespace NooshApp.Data
{
    /// <summary>
    /// The EF Core database session. Represents a connection to the database
    /// and exposes each entity as a queryable DbSet.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<RewardHistory> RewardHistories { get; set; }
        public DbSet<RewardMilestone> RewardMilestones { get; set; }
        public DbSet<CateringRequest> CateringRequests { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enforce that no two users can share the same phone number.
            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
        }
    }
}