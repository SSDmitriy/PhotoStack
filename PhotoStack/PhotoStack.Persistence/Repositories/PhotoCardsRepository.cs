using Microsoft.EntityFrameworkCore;
using PhotoStack.Domain.Models;
using PhotoStack.Persistence.Entities;
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
            var photoCardEntity = new PhotoCardEntity
            {
                Id = photoCard.Id,
                Title = photoCard.Title,
                Price = photoCard.Price,
                Description = photoCard.Description
            };

            // dbCONTEXT->dbSET->вызов метода
            await _photoStackContext.PhotoCards.AddAsync(photoCardEntity);


            //обязательно вызывать метод save
            await _photoStackContext.SaveChangesAsync();
        }

        public async Task<PhotoCard> GetById(Guid id)
        {
            //db context --> db set --> method()
            var entity = await _photoStackContext.PhotoCards
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            PhotoCard photoCard = MapToDomainModel(entity);

            return photoCard;
        }

        //получить ВСЕ карточки
        public async Task<List<PhotoCard>> Get(int pageNumber, int pageSize)
        {
            List<PhotoCardEntity> entities = await _photoStackContext.PhotoCards
                .AsNoTracking()
                .ToListAsync();

            var photoCards = new List<PhotoCard>();

            foreach (var entity in entities)
            {
                var photoCard = MapToDomainModel(entity);
                photoCards.Add(photoCard);
            }

            return photoCards;
        }

        //маппинг сущностей БД в доменную модель
        private PhotoCard MapToDomainModel(PhotoCardEntity photoCardEntity)
        {
            var photoCard = GetEmptyCard();

            photoCard.Id = photoCardEntity.Id;
            photoCard.Title = photoCardEntity.Title;
            photoCard.Price = photoCardEntity.Price;
            photoCard.Description = photoCardEntity.Description;
            photoCard.Image = new Image("add real filepath");

            return photoCard;
        }

        //вернуть пустую карточку
        private PhotoCard GetEmptyCard()
        {
            return new PhotoCard(Guid.Empty, null, decimal.Zero, null, null);
        }       

    }
}

