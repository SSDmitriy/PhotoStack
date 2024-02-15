using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoStack.Persistence.Entities;

namespace PhotoStack.Persistence.Configurations
{
    public class PhotoCardConfiguration : IEntityTypeConfiguration<PhotoCardEntity>
    {
        public void Configure(EntityTypeBuilder<PhotoCardEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Description)
                .HasMaxLength(1000);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasDefaultValue(0.1);

            builder
                .HasOne(p => p.Image)
                .WithOne(i => i.PhotoCard)
                .HasForeignKey<PhotoCardEntity>(p => p.ImageId);
        }
    }
}
