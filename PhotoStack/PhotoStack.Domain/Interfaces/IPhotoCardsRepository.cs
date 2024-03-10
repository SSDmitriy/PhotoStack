using PhotoStack.Domain.Models;
//using PhotoStack.Persistence.Entities;


namespace PhotoStack.Domain.Interfaces
{
    public interface IPhotoCardsRepository
    {
        Task Add(PhotoCard photoCard);
        Task<List<PhotoCard>> Get(int pageNumber, int pageSize);
        Task<PhotoCard> GetById(Guid id);
    }
}