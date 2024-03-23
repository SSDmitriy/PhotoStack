using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoStack.Domain.Models;

namespace PhotoStack.Persistence.Configurations
{
    public class PhotoCardConfiguration : IEntityTypeConfiguration<PhotoCard>
    {
        public void Configure(EntityTypeBuilder<PhotoCard> builder)
        {
            builder.ToTable("PhotoCards");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(PhotoCard.MAX_TITLE_LENGTH);

            builder
                .Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(PhotoCard.MAX_DESCRIPTION_LENGTH);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasDefaultValue(PhotoCard.MIN_PRICE);

            builder
                .ComplexProperty(p => p.Image, b =>
                {
                    b.Property(i => i.FilePath).HasColumnName("FilePath").IsRequired();
                });
        }
    }
}
