﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IHelmetFinishRepository
    {
        Task Add(HelmetFinish helmetFinish, CancellationToken cancellationToken = default);

        Task Delete(HelmetFinish helmetFinish, CancellationToken cancellationToken = default);

        Task<HelmetFinish> Get(int id);

        Task<IEnumerable<HelmetFinish>> GetAll();

        Task Update(HelmetFinish helmetFinish, CancellationToken cancellationToken = default);
    }
}
