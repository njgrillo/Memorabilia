using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public record SaveDashboardItem(SaveDashboardItemViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveDashboardItem>
    {
        private readonly IDomainRepository<DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task Handle(SaveDashboardItem request)
        {
            DashboardItem dashboardItem;

            if (request.ViewModel.IsNew)
            {
                dashboardItem = new DashboardItem(request.ViewModel.Name, request.ViewModel.Description);

                await _dashboardItemRepository.Add(dashboardItem);

                return;
            }

            dashboardItem = await _dashboardItemRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _dashboardItemRepository.Delete(dashboardItem);

                return;
            }

            dashboardItem.Set(request.ViewModel.Name, request.ViewModel.Description);

            await _dashboardItemRepository.Update(dashboardItem);
        }
    }
}
