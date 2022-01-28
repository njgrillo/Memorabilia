﻿using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaPersonRepository
    {
        Task Add(Entities.MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaPerson> Get(int id);

        Task Update(Entities.MemorabiliaPerson memorabiliaPerson, CancellationToken cancellationToken = default);
    }
}
