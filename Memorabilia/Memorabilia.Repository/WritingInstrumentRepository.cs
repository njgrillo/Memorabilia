﻿using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class WritingInstrumentRepository : BaseRepository<Domain.Entities.WritingInstrument>, IWritingInstrumentRepository
    {
        private readonly Context _context;

        public WritingInstrumentRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.WritingInstrument> WritingInstrument => _context.Set<Domain.Entities.WritingInstrument>();

        public async Task Add(Domain.Entities.WritingInstrument writingInstrument, CancellationToken cancellationToken = default)
        {
            _context.Add(writingInstrument);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.WritingInstrument writingInstrument, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.WritingInstrument>().Remove(writingInstrument);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.WritingInstrument> Get(int id)
        {
            return await WritingInstrument.SingleOrDefaultAsync(writingInstrument => writingInstrument.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.WritingInstrument>> GetAll()
        {
            return (await WritingInstrument.ToListAsync().ConfigureAwait(false)).OrderBy(writingInstrument => writingInstrument.Name);
        }

        public async Task Update(Domain.Entities.WritingInstrument writingInstrument, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.WritingInstrument>().Update(writingInstrument);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
