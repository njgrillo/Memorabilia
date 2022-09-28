﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeBrandRepository
    {
        Task Add(ItemTypeBrand itemTypeBrand, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeBrand itemTypeBrand, CancellationToken cancellationToken = default);

        Task<ItemTypeBrand> Get(int id);

        Task<IEnumerable<ItemTypeBrand>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeBrand itemTypeBrand, CancellationToken cancellationToken = default);
    }
}
