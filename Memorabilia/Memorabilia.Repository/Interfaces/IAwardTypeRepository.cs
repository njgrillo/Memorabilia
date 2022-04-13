﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IAwardTypeRepository
    {
        Task Add(AwardType awardType, CancellationToken cancellationToken = default);

        Task Delete(AwardType awardType, CancellationToken cancellationToken = default);

        Task<AwardType> Get(int id);

        Task<IEnumerable<AwardType>> GetAll();

        Task Update(AwardType awardType, CancellationToken cancellationToken = default);
    }
}
