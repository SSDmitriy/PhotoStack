using CSharpFunctionalExtensions;
using PhotoStack.Domain.Common;

namespace PhotoStack.Domain.Models
{
    public class PhotoCard
    {
        //константы модели
        public const int MAX_TITLE_LENGTH = 100;
        public const decimal MIN_PRICE = 0.01M;
        public const decimal MAX_PRICE = 100.00M;
        public const int MAX_DESCRIPTION_LENGTH = 1000;

        //пустой конструктор нужен для работы EF-Core
        private PhotoCard() { }

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
        public decimal Price { get; } = MIN_PRICE;
        public string? Description { get; }
        public Image Image { get; } = null!;
        
        public static Result<PhotoCard, Error> Create(
            Guid id,
            string title,
            decimal price,
            string? description,
            Image image)
        {
            //валидация title
            if (string.IsNullOrWhiteSpace(title))
                return GeneralErrors.CannotBeEmpty(nameof(title));
            if (title.Length > MAX_TITLE_LENGTH)
                return GeneralErrors.LongerThan(nameof(title), MAX_TITLE_LENGTH);

            //валидация price
            //if(price == null) return (null, GeneralErrors.CannotBeEmpty(nameof(title)));
            if (price <  MIN_PRICE)
                return GeneralErrors.LessThan(nameof(price), MIN_PRICE);
            if(price > MAX_PRICE)
                return GeneralErrors.GreaterThan(nameof(price), MAX_PRICE);

            //валидация description
            if (description?.Length > MAX_DESCRIPTION_LENGTH)
                return GeneralErrors.LongerThan(nameof(title), MAX_DESCRIPTION_LENGTH);

            //валидация image
            if(image is null)
                return GeneralErrors.CannotBeEmpty(nameof(title));

            var photoCard = new PhotoCard(id, title, price, description, image);

            return photoCard;
        }
    }
}
