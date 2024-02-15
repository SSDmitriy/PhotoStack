

namespace PhotoStack.Persistence.Entities
{
    public class PhotoCardEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.One;
        public string? Description { get; set; }
        public Guid ImageId { get; set; }
        public ImageEntity? Image { get; set; }

    }
}
