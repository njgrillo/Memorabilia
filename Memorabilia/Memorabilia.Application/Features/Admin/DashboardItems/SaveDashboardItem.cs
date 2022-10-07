using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class SaveDashboardItem
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task Handle(Command command)
        {
            DashboardItem dashboardItem;

            if (command.IsNew)
            {
                dashboardItem = new DashboardItem(command.Name, command.Description);

                await _dashboardItemRepository.Add(dashboardItem);

                return;
            }

            dashboardItem = await _dashboardItemRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _dashboardItemRepository.Delete(dashboardItem);

                return;
            }

            dashboardItem.Set(command.Name, command.Description);

            await _dashboardItemRepository.Update(dashboardItem);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveDashboardItemViewModel _viewModel;

        public Command(SaveDashboardItemViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string Description => _viewModel.Description;

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public string Name => _viewModel.Name;
    }
}
