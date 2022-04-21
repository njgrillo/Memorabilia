using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class CollegeRepository : BaseRepository<College>, ICollegeRepository
    {
        private readonly DomainContext _context;

        public CollegeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<College> College => _context.Set<College>();

        public async Task Add(College college, CancellationToken cancellationToken = default)
        {
            _context.Add(college);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(College college, CancellationToken cancellationToken = default)
        {
            _context.Set<College>().Remove(college);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<College> Get(int id)
        {
            return await College.SingleOrDefaultAsync(college => college.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<College>> GetAll()
        {
            return (await College.ToListAsync().ConfigureAwait(false)).OrderBy(college => college.Name);
        }

        public async Task Update(College college, CancellationToken cancellationToken = default)
        {
            _context.Set<College>().Update(college);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
