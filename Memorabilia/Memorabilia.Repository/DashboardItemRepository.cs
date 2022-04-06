using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class DashboardItemRepository : BaseRepository<DashboardItem>, IDashboardItemRepository
    {
        private readonly DomainContext _context;

        public DashboardItemRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<DashboardItem> DashboardItem => _context.Set<DashboardItem>();

        public async Task Add(DashboardItem dashboardItem, CancellationToken cancellationToken = default)
        {
            _context.Add(dashboardItem);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(DashboardItem dashboardItem, CancellationToken cancellationToken = default)
        {
            _context.Set<DashboardItem>().Remove(dashboardItem);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<DashboardItem> Get(int id)
        {
            return await DashboardItem.SingleOrDefaultAsync(DashboardItem => DashboardItem.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<DashboardItem>> GetAll()
        {
            return (await DashboardItem.ToListAsync().ConfigureAwait(false)).OrderBy(dashboardItem => dashboardItem.Name);
        }

        public async Task Update(DashboardItem dashboardItem, CancellationToken cancellationToken = default)
        {
            _context.Set<DashboardItem>().Update(dashboardItem);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
