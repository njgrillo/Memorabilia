﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeSportRepository
    {
        Task Add(ItemTypeSport itemTypeSport, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeSport itemTypeSport, CancellationToken cancellationToken = default);

        Task<ItemTypeSport> Get(int id);

        Task<IEnumerable<ItemTypeSport>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeSport itemTypeSport, CancellationToken cancellationToken = default);
    }
}
