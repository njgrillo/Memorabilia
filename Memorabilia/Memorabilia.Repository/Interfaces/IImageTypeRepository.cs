﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IImageTypeRepository
    {
        Task Add(ImageType imageType, CancellationToken cancellationToken = default);

        Task Delete(ImageType imageType, CancellationToken cancellationToken = default);

        Task<ImageType> Get(int id);

        Task<IEnumerable<ImageType>> GetAll();

        Task Update(ImageType imageType, CancellationToken cancellationToken = default);
    }
}
