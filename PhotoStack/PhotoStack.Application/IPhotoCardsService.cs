using PhotoStack.Domain.Models;

namespace PhotoStack.Application
{
    public interface IPhotoCardsService
    {
        Task Create(PhotoCard photoCard);
        Task<List<PhotoCard>> Get(int pageNumber, int pageSize);
    }
}