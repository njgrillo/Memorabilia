namespace Memorabilia.Application.Features.Admin.DashboardItems;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveDashboardItem(DashboardItemEditModel DashboardItem) : ICommand
{
    public class Handler(IDomainRepository<Entity.DashboardItem> dashboardItemRepository) 
        : CommandHandler<SaveDashboardItem>
    {
        protected override async Task Handle(SaveDashboardItem request)
        {
            Entity.DashboardItem dashboardItem;

            if (request.DashboardItem.IsNew)
            {
                dashboardItem = new Entity.DashboardItem(request.DashboardItem.Name,
                                                         request.DashboardItem.Description);

                await dashboardItemRepository.Add(dashboardItem);

                return;
            }

            dashboardItem = await dashboardItemRepository.Get(request.DashboardItem.Id);

            if (request.DashboardItem.IsDeleted)
            {
                await dashboardItemRepository.Delete(dashboardItem);

                return;
            }

            dashboardItem.Set(request.DashboardItem.Name, 
                              request.DashboardItem.Description);

            await dashboardItemRepository.Update(dashboardItem);
        }
    }
}
