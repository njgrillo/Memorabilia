namespace Memorabilia.Application.Features.Admin.ChampionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveChampionType(DomainEditModel ChampionType) : ICommand
{
    public class Handler(IDomainRepository<Entity.ChampionType> championTypeRepository) 
        : CommandHandler<SaveChampionType>
    {
        protected override async Task Handle(SaveChampionType request)
        {
            Entity.ChampionType championType;

            if (request.ChampionType.IsNew)
            {
                championType = new Entity.ChampionType(request.ChampionType.Name, 
                                                       request.ChampionType.Abbreviation);

                await championTypeRepository.Add(championType);

                return;
            }

            championType = await championTypeRepository.Get(request.ChampionType.Id);

            if (request.ChampionType.IsDeleted)
            {
                await championTypeRepository.Delete(championType);

                return;
            }

            championType.Set(request.ChampionType.Name, 
                             request.ChampionType.Abbreviation);

            await championTypeRepository.Update(championType);
        }
    }
}
