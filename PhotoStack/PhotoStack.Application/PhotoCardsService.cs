using PhotoStack.Domain.Interfaces;
using PhotoStack.Domain.Models;

namespace PhotoStack.Application
{
    public class PhotoCardsService : IPhotoCardsService
    {
        private readonly IPhotoCardsRepository _photoCardsRepository;

        public PhotoCardsService(IPhotoCardsRepository photoCardsRepository)
        {
            _photoCardsRepository = photoCardsRepository;
        }

        //метод для создания фото
        public async Task Create(PhotoCard photoCard)
        {
            await _photoCardsRepository.Add(photoCard);
        }

    }
}
