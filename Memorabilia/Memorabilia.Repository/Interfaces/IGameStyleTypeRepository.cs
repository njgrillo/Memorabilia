﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IGameStyleTypeRepository
    {
        Task Add(GameStyleType gameStyleType, CancellationToken cancellationToken = default);

        Task Delete(GameStyleType gameStyleType, CancellationToken cancellationToken = default);

        Task<GameStyleType> Get(int id);

        Task<IEnumerable<GameStyleType>> GetAll();

        Task Update(GameStyleType gameStyleType, CancellationToken cancellationToken = default);
    }
}
