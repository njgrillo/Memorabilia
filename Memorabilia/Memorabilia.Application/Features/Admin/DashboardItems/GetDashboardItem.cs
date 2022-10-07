using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class GetDashboardItem
{
    public class Handler : QueryHandler<Query, DashboardItemViewModel>
    {
        private readonly IDomainRepository<DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task<DashboardItemViewModel> Handle(Query query)
        {
            return new DashboardItemViewModel(await _dashboardItemRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<DashboardItemViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
