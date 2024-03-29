﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IGloveTypeRepository
    {
        Task Add(GloveType gloveType, CancellationToken cancellationToken = default);

        Task Delete(GloveType gloveType, CancellationToken cancellationToken = default);

        Task<GloveType> Get(int id);

        Task<IEnumerable<GloveType>> GetAll();

        Task Update(GloveType gloveType, CancellationToken cancellationToken = default);
    }
}
