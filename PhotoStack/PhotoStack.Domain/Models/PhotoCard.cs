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
            // создать валидацию, проверить параметры на пустую строку, на пробелы, на отрицительную цену
            // в случае ошибки, выбрасывать exception

            // if (price < 0) 
            // {
            //     throw new Exception();
            // }

            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Image = image;
        }

        // везде убрать set
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public string? Description { get; set; }
        public Image Image { get; set; }
    }
}
