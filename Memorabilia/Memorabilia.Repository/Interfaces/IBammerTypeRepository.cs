﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IBammerTypeRepository
    {
        Task Add(BammerType BammerType, CancellationToken cancellationToken = default);

        Task Delete(BammerType BammerType, CancellationToken cancellationToken = default);

        Task<BammerType> Get(int id);

        Task<IEnumerable<BammerType>> GetAll();

        Task Update(BammerType BammerType, CancellationToken cancellationToken = default);
    }
}
