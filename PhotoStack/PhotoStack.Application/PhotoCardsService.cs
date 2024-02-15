using PhotoStack.Domain.Interfaces;
using PhotoStack.Domain.Models;

namespace PhotoStack.Application
{
    public class PhotoCardsService
    {
        private readonly IPhotoCardsRepository _photoCardsRepository;

        //метод для создания фото
        public PhotoCardsService(IPhotoCardsRepository photoCardsRepository)
        {
            _photoCardsRepository = photoCardsRepository;
        }

        public async Task Create(PhotoCard photoCard)
        {
            await _photoCardsRepository.Add(photoCard);
        }
        
    }
}
