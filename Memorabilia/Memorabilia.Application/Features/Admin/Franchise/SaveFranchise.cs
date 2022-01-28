using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Franchise
{
    public class SaveFranchise
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IFranchiseRepository _franchiseRepository;

            public Handler(IFranchiseRepository franchiseRepository)
            {
                _franchiseRepository = franchiseRepository;
            }

            protected override async Task Handle(Command command)
            {
                Domain.Entities.Franchise franchise;

                if (command.IsNew)
                {
                    franchise = new Domain.Entities.Franchise(command.SportId, command.Name, command.Location, command.FoundYear);
                    await _franchiseRepository.Add(franchise).ConfigureAwait(false);

                    return;
                }

                franchise = await _franchiseRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _franchiseRepository.Delete(franchise).ConfigureAwait(false);

                    return;
                }

                franchise.Set(command.Name, command.Location, command.FoundYear);

                await _franchiseRepository.Update(franchise).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveFranchiseViewModel _viewModel;

            public Command(SaveFranchiseViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int FoundYear => _viewModel.FoundYear;

            public int Id => _viewModel.Id;

            public string ImagePath => _viewModel.ImagePath;

            public bool IsDeleted => _viewModel.IsDeleted;

            public bool IsModified => _viewModel.IsModified;

            public bool IsNew => _viewModel.IsNew;

            public string Location => _viewModel.Location;

            public string Name => _viewModel.Name;

            public int SportId => _viewModel.SportId;
        }
    }
}
