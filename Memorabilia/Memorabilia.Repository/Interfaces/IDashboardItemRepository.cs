using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IDashboardItemRepository
    {
        Task Add(DashboardItem dashboardItem, CancellationToken cancellationToken = default);

        Task Delete(DashboardItem dashboardItem, CancellationToken cancellationToken = default);

        Task<DashboardItem> Get(int id);

        Task<IEnumerable<DashboardItem>> GetAll();

        Task Update(DashboardItem dashboardItem, CancellationToken cancellationToken = default);
    }
}
