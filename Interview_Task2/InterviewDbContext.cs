using Interview_Task2.Configuration;
using Interview_Task2.Entity;
using Microsoft.EntityFrameworkCore;

namespace Interview_Task2
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
