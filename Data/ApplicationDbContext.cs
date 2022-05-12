using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCollection.Models;

namespace MyCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Collection>()
                .HasOne(p => p.CollectionAppUser)
                .WithMany(t => t.AppUserCollection)
                .HasForeignKey(p => p.AppUserId);
            base.OnModelCreating(builder);

            builder.Entity<Item>()
                .HasOne(p => p.ItemCollection)
                .WithMany(t => t.CollectionItem)
                .HasForeignKey(p => p.CollectionId);
            base.OnModelCreating(builder);

            builder.Entity<Item>()
                .HasOne(p => p.ItemAppUser)
                .WithMany(t => t.AppUserItem)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
    }
}