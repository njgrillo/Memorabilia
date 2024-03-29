﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IInscriptionTypeRepository
    {
        Task Add(InscriptionType inscriptionType, CancellationToken cancellationToken = default);

        Task Delete(InscriptionType inscriptionType, CancellationToken cancellationToken = default);

        Task<InscriptionType> Get(int id);

        Task<IEnumerable<InscriptionType>> GetAll();

        Task Update(InscriptionType inscriptionType, CancellationToken cancellationToken = default);
    }
}
