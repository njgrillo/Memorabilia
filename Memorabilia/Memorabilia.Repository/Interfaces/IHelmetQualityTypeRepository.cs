﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IHelmetQualityTypeRepository
    {
        Task Add(HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default);

        Task Delete(HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default);

        Task<HelmetQualityType> Get(int id);

        Task<IEnumerable<HelmetQualityType>> GetAll();

        Task Update(HelmetQualityType helmetQualityType, CancellationToken cancellationToken = default);
    }
}
