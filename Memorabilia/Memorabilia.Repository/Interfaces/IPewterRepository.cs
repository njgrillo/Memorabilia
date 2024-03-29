﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPewterRepository
    {
        Task Add(Pewter pewter, CancellationToken cancellationToken = default);

        Task Delete(Pewter pewter, CancellationToken cancellationToken = default);

        Task<Pewter> Get(int id);

        Task<IEnumerable<Pewter>> GetAll();

        Task Update(Pewter pewter, CancellationToken cancellationToken = default);
    }
}
