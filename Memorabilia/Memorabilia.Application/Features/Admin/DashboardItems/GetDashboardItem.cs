namespace Memorabilia.Application.Features.Admin.DashboardItems;

public record GetDashboardItem(int Id) : IQuery<Entity.DashboardItem>
{
    public class Handler(IDomainRepository<Entity.DashboardItem> dashboardItemRepository) 
        : QueryHandler<GetDashboardItem, Entity.DashboardItem>
    {
        protected override async Task<Entity.DashboardItem> Handle(GetDashboardItem query)
            => await dashboardItemRepository.Get(query.Id);
    }
}
