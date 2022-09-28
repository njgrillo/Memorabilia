using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes
{
    public class SaveChampionType
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IChampionTypeRepository _championTypeRepository;

            public Handler(IChampionTypeRepository championTypeRepository)
            {
                _championTypeRepository = championTypeRepository;
            }

            protected override async Task Handle(Command command)
            {
                ChampionType championType;

                if (command.IsNew)
                {
                    championType = new ChampionType(command.Name, command.Abbreviation);
                    await _championTypeRepository.Add(championType).ConfigureAwait(false);

                    return;
                }

                championType = await _championTypeRepository.Get(command.Id).ConfigureAwait(false);

                if (command.IsDeleted)
                {
                    await _championTypeRepository.Delete(championType).ConfigureAwait(false);

                    return;
                }

                championType.Set(command.Name, command.Abbreviation);

                await _championTypeRepository.Update(championType).ConfigureAwait(false);
            }
        }

        public class Command : DomainEntityCommand
        {
            public Command(SaveDomainViewModel viewModel) : base(viewModel) { }
        }
    }
}
