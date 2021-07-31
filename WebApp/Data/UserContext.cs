using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<GraphModel> Graphs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<GraphModel>(entity => { entity.HasIndex(e => e.Name).IsUnique(); });

            modelBuilder.Entity<GraphModel>()
                .HasOne(g => g.User)
                .WithMany(u => u.Graphs)
                .IsRequired();
        }
    }
}
