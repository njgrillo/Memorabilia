namespace Memorabilia.Application.Features.Admin.DashboardItems;

public record GetDashboardItems() : IQuery<Entity.DashboardItem[]>
{
    public class Handler(IDomainRepository<Entity.DashboardItem> dashboardItemRepository) 
        : QueryHandler<GetDashboardItems, Entity.DashboardItem[]>
    {
        protected override async Task<Entity.DashboardItem[]> Handle(GetDashboardItems query)
            => await dashboardItemRepository.GetAll();
    }
}
