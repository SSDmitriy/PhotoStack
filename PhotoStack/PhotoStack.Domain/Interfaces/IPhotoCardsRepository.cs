﻿using PhotoStack.Domain.Models;
using PhotoStack.Persistence.Entities;


namespace PhotoStack.Domain.Interfaces
{
    public interface IPhotoCardsRepository
    {
        Task Add(PhotoCard photoCard);
        Task<List<PhotoCardEntity>> Get(int pageNumber, int pageSize);
        //Task<PhotoCardEntity?> GetById(Guid id);
    }
}