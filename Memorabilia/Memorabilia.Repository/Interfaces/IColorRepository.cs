﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IColorRepository
    {
        Task Add(Color color, CancellationToken cancellationToken = default);

        Task Delete(Color color, CancellationToken cancellationToken = default);

        Task<Color> Get(int id);

        Task<IEnumerable<Color>> GetAll();

        Task Update(Color color, CancellationToken cancellationToken = default);
    }
}
