
using Microsoft.EntityFrameworkCore;
using PhotoStack.Persistence.Entities;

namespace PhotoStack.Persistence
{
    public class PhotoStackContext : DbContext
    {
        public DbSet<PhotoCardEntity> PhotoCards { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
    }
}
