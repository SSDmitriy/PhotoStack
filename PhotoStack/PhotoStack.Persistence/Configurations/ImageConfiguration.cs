using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoStack.Persistence.Entities;

namespace PhotoStack.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder
                .HasKey(i => i.PhotoCardId);

            builder
                .HasOne(i => i.PhotoCard)
                .WithOne(p => p.Image)
                .HasForeignKey<ImageEntity>(i => i.PhotoCardId);
        }
    }
}
