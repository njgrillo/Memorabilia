using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public class SaveChampionType
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task Handle(Command command)
        {
            ChampionType championType;

            if (command.IsNew)
            {
                championType = new ChampionType(command.Name, command.Abbreviation);

                await _championTypeRepository.Add(championType);

                return;
            }

            championType = await _championTypeRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _championTypeRepository.Delete(championType);

                return;
            }

            championType.Set(command.Name, command.Abbreviation);

            await _championTypeRepository.Update(championType);
        }
    }

    public class Command : DomainEntityCommand
    {
        public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
    }
}
