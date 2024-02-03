namespace PhotoStack.Domain.Models
{
    public class PhotoCard
    {
        public PhotoCard(
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

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public string? Description { get; set; }
        public Image Image { get; set; }

        


    }
}
