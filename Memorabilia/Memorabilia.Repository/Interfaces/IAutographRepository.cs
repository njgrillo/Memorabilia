﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IAutographRepository
    {
        Task Add(Autograph autograph, CancellationToken cancellationToken = default);

        Task Delete(Autograph autograph, CancellationToken cancellationToken = default);

        Task<Autograph> Get(int id);

        Task<IEnumerable<Autograph>> GetAll(int? memorabiliaId = null, int? userId = null);

        Task Update(Autograph autograph, CancellationToken cancellationToken = default);
    }
}
