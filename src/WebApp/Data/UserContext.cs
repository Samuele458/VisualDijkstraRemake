using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<GraphModel> Graphs { get; set; }

        public DbSet<Verification> Verifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasIndex(e => e.Email)
                    .IsUnique();

                entity
                    .HasOne(u => u.Verification)
                    .WithOne(v => v.User)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .IsRequired(false)
                    .HasForeignKey<Verification>(v => v.UserId);

                entity
                    .HasMany(u => u.Graphs)
                    .WithOne(g => g.User)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .IsRequired();


            });

            /*
            modelBuilder.Entity<GraphModel>()
                .HasOne(g => g.User)
                .WithMany(u => u.Graphs)
                .IsRequired();*/

            //modelBuilder.Entity<Verification>(entity => { entity.HasIndex(e => e.Token).IsUnique(); });
            /*
            modelBuilder.Entity<User>()
                .HasOne(u => u.Verification)
                .WithOne(v => v.User)
                //.IsRequired(false)
                .HasForeignKey<Verification>(v => v.UserId);*/


            //modelBuilder.Entity<User>().
        }
    }
}
