﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPrivacyTypeRepository
    {
        Task Add(PrivacyType privacyType, CancellationToken cancellationToken = default);

        Task Delete(PrivacyType privacyType, CancellationToken cancellationToken = default);

        Task<PrivacyType> Get(int id);

        Task<IEnumerable<PrivacyType>> GetAll();

        Task Update(PrivacyType privacyType, CancellationToken cancellationToken = default);
    }
}
