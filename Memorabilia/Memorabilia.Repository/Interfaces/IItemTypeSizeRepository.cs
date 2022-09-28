﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeSizeRepository
    {
        Task Add(ItemTypeSize itemTypeSize, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeSize itemTypeSize, CancellationToken cancellationToken = default);

        Task<ItemTypeSize> Get(int id);

        Task<IEnumerable<ItemTypeSize>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeSize itemTypeSize, CancellationToken cancellationToken = default);
    }
}
