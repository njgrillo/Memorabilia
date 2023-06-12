namespace Memorabilia.Application.Features.Admin.DashboardItems;

public record GetDashboardItem(int Id) : IQuery<Entity.DashboardItem>
{
    public class Handler : QueryHandler<GetDashboardItem, Entity.DashboardItem>
    {
        private readonly IDomainRepository<Entity.DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<Entity.DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task<Entity.DashboardItem> Handle(GetDashboardItem query)
            => await _dashboardItemRepository.Get(query.Id);
    }
}
