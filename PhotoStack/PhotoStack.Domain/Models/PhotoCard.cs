namespace PhotoStack.Domain.Models
{
    public class PhotoCard
    {
        private PhotoCard(
            Guid id,
            string title,
            decimal price,
            string? description,
            Image image)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Image = image;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public decimal Price { get; } = decimal.Zero;
        public string? Description { get; }
        public Image Image { get; }

        public static (PhotoCard? photoCard, Error? error) Create(
            Guid id,
            string title,
            decimal price,
            string? description,
            Image image)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length >= 100) // 100 заменить на const
            {
                return (null, GeneralErrors.IsInvalid(nameof(title)));
            }

            var photoCard = new PhotoCard(id, title, price, description, image);

            return (photoCard, null);
        }
    }
}
