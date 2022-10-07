using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public class SaveSport
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<Sport> _sportRepository;

        public Handler(IDomainRepository<Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task Handle(Command command)
        {
            Sport sport;

            if (command.IsNew)
            {
                sport = new Sport(command.Name, command.AlternateName);

                await _sportRepository.Add(sport);

                return;
            }

            sport = await _sportRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _sportRepository.Delete(sport);

                return;
            }

            sport.Set(command.Name, command.AlternateName);

            await _sportRepository.Update(sport);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveSportViewModel _viewModel;

        public Command(SaveSportViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string AlternateName => _viewModel.AlternateName;

        public int Id => _viewModel.Id;

        public string ImagePath => _viewModel.ImagePath;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public string Name => _viewModel.Name;
    }
}
