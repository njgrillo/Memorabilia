using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class CommissionerRepository : BaseRepository<Domain.Entities.Commissioner>, ICommissionerRepository
    {
        private readonly Context _context;

        public CommissionerRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Commissioner> Commissioner => _context.Set<Domain.Entities.Commissioner>()
                                                                                 .Include(commissioner => commissioner.Person);

        public async Task Add(Domain.Entities.Commissioner commissioner, CancellationToken cancellationToken = default)
        {
            _context.Add(commissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Commissioner commissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Commissioner>().Remove(commissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Commissioner> Get(int id)
        {
            return await Commissioner.SingleOrDefaultAsync(commissioner => commissioner.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Commissioner>> GetAll(int? sportLeagueLevelId = null)
        {
            return !sportLeagueLevelId.HasValue
                ? (await Commissioner.ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                                            .ThenByDescending(commissioner => commissioner.BeginYear)
                : (await Commissioner.Where(commissioner => commissioner.SportLeagueLevelId == sportLeagueLevelId)
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                                            .ThenByDescending(commissioner => commissioner.BeginYear);
        }

        public async Task Update(Domain.Entities.Commissioner commissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Commissioner>().Update(commissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
