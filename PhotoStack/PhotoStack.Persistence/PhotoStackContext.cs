using Microsoft.EntityFrameworkCore;
using PhotoStack.Domain.Models;
using PhotoStack.Persistence.Configurations;

namespace PhotoStack.Persistence
{
    public class PhotoStackContext(DbContextOptions<PhotoStackContext> options)
        : DbContext(options)
    {
        public DbSet<PhotoCard> PhotoCards { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PhotoCardConfiguration());
        }
    }
}
