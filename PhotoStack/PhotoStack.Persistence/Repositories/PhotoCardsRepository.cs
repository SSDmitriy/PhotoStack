using Microsoft.EntityFrameworkCore;
using PhotoStack.Persistence.Entities;

namespace PhotoStack.Persistence.Repositories
{
    public class PhotoCardsRepository
    {
        private readonly PhotoStackContext _photoStackContext;

        public PhotoCardsRepository(PhotoStackContext photoStackContext)
        {
            _photoStackContext = photoStackContext;
        }
        public async Task Add(Guid id, string title, decimal price, string description)
        {
            var photoCardEntity = new PhotoCardEntity
            {
                Id = id,
                Title = title,
                Price = price,
                Description = description
            };

            await _photoStackContext.PhotoCards.AddAsync(photoCardEntity);

            //обязательно вызывать метод save
            await _photoStackContext.SaveChangesAsync();
        }

        public async Task<PhotoCardEntity?> GetById(Guid id)
        {
            //db context --> db set --> method()
            var card = await _photoStackContext.PhotoCards
                .FirstOrDefaultAsync(p => p.Id == id);

            return card;
        }

        //получить ВСЕ карточки
        public async Task<List<PhotoCardEntity>> Get()
        {
            var cards = await _photoStackContext.PhotoCards.ToListAsync();

            return cards;
        }

    }
}

