﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface ICollegeRepository
    {
        Task Add(College college, CancellationToken cancellationToken = default);

        Task Delete(College college, CancellationToken cancellationToken = default);

        Task<College> Get(int id);

        Task<IEnumerable<College>> GetAll();

        Task Update(College college, CancellationToken cancellationToken = default);
    }
}
