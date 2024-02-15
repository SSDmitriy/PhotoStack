using PhotoStack.Domain.Models;

namespace PhotoStack.Domain.Interfaces
{
    public interface IPhotoCardsRepository
    {
        Task Add(PhotoCard photoCard);
        //Task<List<PhotoCard>> Get();
        //Task<PhotoCardEntity?> GetById(Guid id);
    }
}