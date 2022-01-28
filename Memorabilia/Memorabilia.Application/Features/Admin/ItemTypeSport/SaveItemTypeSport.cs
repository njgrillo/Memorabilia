using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class SaveItemTypeSport
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IItemTypeSportRepository _itemTypeSportRepository;

            public Handler(IItemTypeSportRepository itemTypeSportRepository)
            {
                _itemTypeSportRepository = itemTypeSportRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.ItemTypeSport itemTypeSport;

                if (command.IsNew)
                {
                    itemTypeSport = new Domain.Entities.ItemTypeSport(command.ItemTypeId, command.SportId);

                    await _itemTypeSportRepository.Add(itemTypeSport).ConfigureAwait(false);

                    return;
                }

                itemTypeSport = await _itemTypeSportRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _itemTypeSportRepository.Delete(itemTypeSport).ConfigureAwait(false);

                    return;
                }

                itemTypeSport.Set(command.SportId);

                await _itemTypeSportRepository.Update(itemTypeSport).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveItemTypeSportViewModel _viewModel;

            public Command(SaveItemTypeSportViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int Id => _viewModel.Id;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public int ItemTypeId => _viewModel.ItemTypeId;

            public int SportId => _viewModel.SportId;
        }
    }
}
