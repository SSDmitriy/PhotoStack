using Microsoft.EntityFrameworkCore;
using PhotoStack.Persistence.Configurations;
using PhotoStack.Persistence.Entities;

namespace PhotoStack.Persistence
{
    public class PhotoStackContext(DbContextOptions<PhotoStackContext> options)
        : DbContext(options)
    {
        public DbSet<PhotoCardEntity> PhotoCards { get; set; }
        public DbSet<ImageEntity> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PhotoCardConfiguration());

            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }
    }
}
