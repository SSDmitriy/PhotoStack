using Microsoft.EntityFrameworkCore;
using PhotoStack.Domain.Models;
using PhotoStack.Domain.Interfaces;

namespace PhotoStack.Persistence.Repositories
{
    public class PhotoCardsRepository : IPhotoCardsRepository
    {
        private readonly PhotoStackContext _photoStackContext;

        public PhotoCardsRepository(PhotoStackContext photoStackContext)
        {
            _photoStackContext = photoStackContext;
        }

        public async Task Add(PhotoCard photoCard)
        {         
            // dbCONTEXT->dbSET->вызов метода
            await _photoStackContext.PhotoCards.AddAsync(photoCard);

            //обязательно вызывать метод save
            await _photoStackContext.SaveChangesAsync();
        }

        public async Task<PhotoCard> GetById(Guid id)
        {
            //db context --> db set --> method()
            var photoCard = await _photoStackContext.PhotoCards
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new Exception("Not found");

            return photoCard;
        }

        //получить ВСЕ карточки
        public async Task<List<PhotoCard>> Get(int pageNumber, int pageSize)
        {
            var photoCards = await _photoStackContext.PhotoCards
                .AsNoTracking()
                .Skip(pageNumber  * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return photoCards;
        }
    }
}

