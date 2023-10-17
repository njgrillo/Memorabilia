namespace Memorabilia.Application.Features.Admin.ChampionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveChampionType(DomainEditModel ChampionType) : ICommand
{
    public class Handler : CommandHandler<SaveChampionType>
    {
        private readonly IDomainRepository<Entity.ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<Entity.ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task Handle(SaveChampionType request)
        {
            Entity.ChampionType championType;

            if (request.ChampionType.IsNew)
            {
                championType = new Entity.ChampionType(request.ChampionType.Name, 
                                                       request.ChampionType.Abbreviation);

                await _championTypeRepository.Add(championType);

                return;
            }

            championType = await _championTypeRepository.Get(request.ChampionType.Id);

            if (request.ChampionType.IsDeleted)
            {
                await _championTypeRepository.Delete(championType);

                return;
            }

            championType.Set(request.ChampionType.Name, 
                             request.ChampionType.Abbreviation);

            await _championTypeRepository.Update(championType);
        }
    }
}
