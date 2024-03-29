﻿using Domain.Models.Shelf;

namespace Infrastructure.Repositories.ShelfRepo
{
    public interface IShelfRepository
    {
        Task<ShelfModel> AddShelfAsync(ShelfModel shelfToCreate);
        Task DeleteShelfAsync(Guid shelfId);
        Task<IEnumerable<ShelfModel>> GetAllAsync();
        Task<ShelfModel> GetShelfByIdAsync(Guid shelfId);
        Task<ShelfModel> UpdateShelfAsync(ShelfModel shelfToUpdate);
    }
}
