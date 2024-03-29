﻿using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IFigureSpecialtyTypeRepository
    {
        Task Add(FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default);

        Task Delete(FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default);

        Task<FigureSpecialtyType> Get(int id);

        Task<IEnumerable<FigureSpecialtyType>> GetAll();

        Task Update(FigureSpecialtyType figureSpecialtyType, CancellationToken cancellationToken = default);
    }
}
