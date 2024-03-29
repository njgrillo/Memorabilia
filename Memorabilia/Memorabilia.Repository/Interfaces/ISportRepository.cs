﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ISportRepository
    {
        Task Add(Sport sport, CancellationToken cancellationToken = default);

        Task Delete(Sport sport, CancellationToken cancellationToken = default);

        Task<Sport> Get(int id);

        Task<IEnumerable<Sport>> GetAll();

        Task Update(Sport sport, CancellationToken cancellationToken = default);
    }
}
