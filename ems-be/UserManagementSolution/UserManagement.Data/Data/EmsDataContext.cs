using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Data
{
    internal class EmsDataContext : DbContext
    {
        public EmsDataContext(DbContextOptions<EmsDataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.AdB2CId).IsUnique(); // Unique index on AdB2CId
                entity.HasIndex(e => e.Email).IsUnique(); // Unique index on Email
            });
        }
    }
}
