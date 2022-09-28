﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IHelmetTypeRepository
    {
        Task Add(HelmetType helmetType, CancellationToken cancellationToken = default);

        Task Delete(HelmetType helmetType, CancellationToken cancellationToken = default);

        Task<HelmetType> Get(int id);

        Task<IEnumerable<HelmetType>> GetAll();

        Task Update(HelmetType helmetType, CancellationToken cancellationToken = default);
    }
}
