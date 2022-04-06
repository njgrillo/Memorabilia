using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.DashboardItems
{
    public class SaveDashboardItem
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IDashboardItemRepository _dashboardItemRepository;

            public Handler(IDashboardItemRepository dashboardItemRepository)
            {
                _dashboardItemRepository = dashboardItemRepository;
            }

            protected override async Task Handle(Command command)
            {
                DashboardItem dashboardItem;

                if (command.IsNew)
                {
                    dashboardItem = new DashboardItem(command.Name, command.Description);

                    await _dashboardItemRepository.Add(dashboardItem).ConfigureAwait(false);

                    return;
                }

                dashboardItem = await _dashboardItemRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _dashboardItemRepository.Delete(dashboardItem).ConfigureAwait(false);

                    return;
                }

                dashboardItem.Set(command.Name, command.Description);

                await _dashboardItemRepository.Update(dashboardItem).ConfigureAwait(false);
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
}
