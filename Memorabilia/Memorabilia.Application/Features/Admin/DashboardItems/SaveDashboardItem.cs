namespace Memorabilia.Application.Features.Admin.DashboardItems;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveDashboardItem(DashboardItemEditModel DashboardItem) : ICommand
{
    public class Handler : CommandHandler<SaveDashboardItem>
    {
        private readonly IDomainRepository<Entity.DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<Entity.DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task Handle(SaveDashboardItem request)
        {
            Entity.DashboardItem dashboardItem;

            if (request.DashboardItem.IsNew)
            {
                dashboardItem = new Entity.DashboardItem(request.DashboardItem.Name,
                                                         request.DashboardItem.Description);

                await _dashboardItemRepository.Add(dashboardItem);

                return;
            }

            dashboardItem = await _dashboardItemRepository.Get(request.DashboardItem.Id);

            if (request.DashboardItem.IsDeleted)
            {
                await _dashboardItemRepository.Delete(dashboardItem);

                return;
            }

            dashboardItem.Set(request.DashboardItem.Name, 
                              request.DashboardItem.Description);

            await _dashboardItemRepository.Update(dashboardItem);
        }
    }
}
