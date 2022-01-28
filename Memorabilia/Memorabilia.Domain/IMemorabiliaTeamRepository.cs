﻿using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IMemorabiliaTeamRepository
    {
        Task Add(Entities.MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default);

        Task Delete(Entities.MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default);

        Task<Entities.MemorabiliaTeam> Get(int id);

        Task Update(Entities.MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default);
    }
}
