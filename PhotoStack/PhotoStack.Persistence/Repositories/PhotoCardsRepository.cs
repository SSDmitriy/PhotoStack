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

        public async Task<PhotoCardEntity?> GetById(Guid id)
        {
            //db context --> db set --> method()
            var card = await _photoStackContext.PhotoCards
                .AsNoTracking() //НЕ отслеживать средствами EF -для повышения производительности. Т.к. это Get-метод, только запрашивает данные
                .FirstOrDefaultAsync(p => p.Id == id);

            return card;
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
            var photoCard = new PhotoCard(Guid.Empty, null, decimal.Zero, null, null);

            photoCard.Id = photoCardEntity.Id;
            photoCard.Title = photoCardEntity.Title;
            photoCard.Price = photoCardEntity.Price;
            photoCard.Description = photoCardEntity.Description;
            photoCard.Image = new Image("add real filepath");

            return photoCard;
        }
    }
}

