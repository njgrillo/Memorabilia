﻿using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class HelmetTypeRepository : BaseRepository<Domain.Entities.HelmetType>, IHelmetTypeRepository
    {
        private readonly Context _context;

        public HelmetTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.HelmetType> HelmetType => _context.Set<Domain.Entities.HelmetType>();

        public async Task Add(Domain.Entities.HelmetType helmetType, CancellationToken cancellationToken = default)
        {
            _context.Add(helmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.HelmetType helmetType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HelmetType>().Remove(helmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.HelmetType> Get(int id)
        {
            return await HelmetType.SingleOrDefaultAsync(helmetType => helmetType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.HelmetType>> GetAll()
        {
            return (await HelmetType.ToListAsync().ConfigureAwait(false)).OrderBy(helmetType => helmetType.Name);
        }

        public async Task Update(Domain.Entities.HelmetType helmetType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.HelmetType>().Update(helmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
