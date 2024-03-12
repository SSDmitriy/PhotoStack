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
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new Exception("Not found");

            PhotoCard photoCard = MapToDomainModel(entity);

            return photoCard;
        }

        //получить ВСЕ карточки
        public async Task<List<PhotoCard>> Get(int pageNumber, int pageSize)
        {
            var entities = await _photoStackContext.PhotoCards
                .AsNoTracking()
                .Skip(pageNumber  * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var photoCards = entities.Select(MapToDomainModel).ToList();

            return photoCards;
        }

        //маппинг сущностей БД в доменную модель
        private PhotoCard MapToDomainModel(PhotoCardEntity photoCardEntity) =>
            PhotoCard.Create(
                photoCardEntity.Id,
                photoCardEntity.Title,
                photoCardEntity.Price,
                photoCardEntity.Description,
                new Image("add real filepath")).photoCard!;

        //вернуть пустую карточку
        private PhotoCard GetEmptyCard()
        {
            //return new PhotoCard(Guid.Empty, null, decimal.Zero, null, null);
            return PhotoCard.Create(Guid.Empty, null, decimal.Zero, null, null).photoCard!;
        }       

    }
}

