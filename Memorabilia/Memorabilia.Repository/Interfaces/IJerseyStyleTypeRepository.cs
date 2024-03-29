﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IJerseyStyleTypeRepository
    {
        Task Add(JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default);

        Task Delete(JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default);

        Task<JerseyStyleType> Get(int id);

        Task<IEnumerable<JerseyStyleType>> GetAll();

        Task Update(JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default);
    }
}
