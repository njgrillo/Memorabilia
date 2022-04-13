using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FranchiseHallOfFameTypeRepository : BaseRepository<FranchiseHallOfFameType>, IFranchiseHallOfFameTypeRepository
    {
        private readonly DomainContext _context;

        public FranchiseHallOfFameTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<FranchiseHallOfFameType> FranchiseHallOfFameType => _context.Set<FranchiseHallOfFameType>();

        public async Task Add(FranchiseHallOfFameType franchiseHallOfFameType, CancellationToken cancellationToken = default)
        {
            _context.Add(franchiseHallOfFameType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(FranchiseHallOfFameType franchiseHallOfFameType, CancellationToken cancellationToken = default)
        {
            _context.Set<FranchiseHallOfFameType>().Remove(franchiseHallOfFameType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<FranchiseHallOfFameType> Get(int id)
        {
            return await FranchiseHallOfFameType.SingleOrDefaultAsync(franchiseHallOfFameType => franchiseHallOfFameType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<FranchiseHallOfFameType>> GetAll()
        {
            return (await FranchiseHallOfFameType.ToListAsync().ConfigureAwait(false)).OrderBy(franchiseHallOfFameType => franchiseHallOfFameType.Name);
        }

        public async Task Update(FranchiseHallOfFameType franchiseHallOfFameType, CancellationToken cancellationToken = default)
        {
            _context.Set<FranchiseHallOfFameType>().Update(franchiseHallOfFameType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
